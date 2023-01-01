import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import { Button, Card, CardActions, CardContent, Container, Typography } from '@mui/material';
import { VirtualMatrixConfiguration } from './VirtualMatrixConfiguration';
import { ReactNode, useEffect } from 'react';
import { addVirtualMatrixDialogWidth, defaultPaddingSize } from '../../infra/constants';
import { ConfigurationCallbackModel } from './ConfigurationCallbackModel';
import { useDispatch } from 'react-redux/es/exports';
import { add1, addVirtualMatrix } from '../../infra/slices/MatricesSlice';
import { store } from '../../configurestore';
import { AppState } from '../../AppState';
import matricesSlice from '../../infra/slices/MatricesSlice';

export function VirtualMatrixConfigurator() {
  const dispatch = useDispatch();
  const [matrixWidth, setMatrixWidth] = React.useState(128);
  const handleMatrixWidthChange = (event: SelectChangeEvent, child: ReactNode) => {
    setMatrixWidth(Number.parseInt(event.target.value));
  };

  const [matrixHeight, setMatrixHeight] = React.useState(128);
  const handleMatrixHeightChange = (event: SelectChangeEvent, child: ReactNode) => {
    setMatrixHeight(Number.parseInt(event.target.value));
  };

  React.useCallback(() => {
    console.log('callback')
    store.dispatch(addVirtualMatrix({ matrixWidth, matrixHeight }));
  }, []);

  console.log("Preloaded state: " + JSON.stringify(store.getState()));
  console.log("^ should be " + JSON.stringify(new AppState([new VirtualMatrixConfiguration(0, 0)], {
    matrices: addVirtualMatrix
  })));
  const allowedValues = [16, 32, 64, 128, 256];
  return <>
    <Typography component="div" variant="body1">
      <Typography>
        Add a virtual matrix to the canvas. It will run exactly the same as a physical matrix, meaning you will be able to test code on it.
      </Typography>
      <Box sx={{ maxWidth: addVirtualMatrixDialogWidth, color: 'text.primary', padding: '5px' }}>
        <br />
        <Box sx={{ maxWidth: addVirtualMatrixDialogWidth }}>
          <FormControl fullWidth>
            <InputLabel id="addVirtualMatrixDialogWidth-label" sx={{ color: 'text.primary' }}>Width</InputLabel>
            <Select
              labelId="addVirtualMatrixDialogWidth-label"
              id="matrix-addVirtualMatrixDialogWidth-select"
              value={matrixWidth.toString()}
              label="Width"
              onChange={handleMatrixWidthChange}>
              {allowedValues.map((x, i) => <MenuItem value={x} key={i}>{x}px</MenuItem>)}
            </Select>
          </FormControl>
        </Box>
        <br />
        <Box sx={{ maxWidth: addVirtualMatrixDialogWidth }}>
          <FormControl fullWidth>
            <InputLabel id="height-label" sx={{ color: 'text.primary' }}>Height</InputLabel>
            <Select
              labelId="height-label"
              id="matrix-height-select"
              value={matrixHeight.toString()}
              label="Height"
              onChange={handleMatrixHeightChange}>
              {allowedValues.map((x, i) => <MenuItem value={x} key={i}>{x}px</MenuItem>)}
            </Select>
          </FormControl>
        </Box>
        <br />
        <Button sx={{ width: addVirtualMatrixDialogWidth - defaultPaddingSize * 5, color: 'text.primary', backgroundColor: '#ff7043' }}
          onClick={() => {
            console.log('Click')
            //add1({ matrixWidth, matrixHeight })(dispatch, store.getState())
            console.log('Dispatch result: ' + JSON.stringify(store.dispatch(addVirtualMatrix)))
            console.log('Dispatch result: ' + JSON.stringify(store.dispatch(() => add1({ matrixWidth, matrixHeight })(addVirtualMatrix, store.getState()))))

            //dispatch()
          }}>
          Add
        </Button>
      </Box>
    </Typography>
  </>
};