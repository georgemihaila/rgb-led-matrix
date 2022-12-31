import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import { Button, Typography } from '@mui/material';
import { VirtualMatrixConfiguration } from './VirtualMatrixConfiguration';
import { ReactNode } from 'react';
import { addVirtualMatrixDialogWidth, defaultPaddingSize } from '../../infra/constants';
import { ConfigurationCallbackModel } from './ConfigurationCallbackModel';

function MatrixConfigurator(callbackModel: ConfigurationCallbackModel) {
  const [matrixWidth, setMatrixWidth] = React.useState(64);
  const handleMatrixWidthChange = (event: SelectChangeEvent, child: ReactNode) => {
    setMatrixWidth(Number.parseInt(event.target.value));
  };

  const [matrixHeight, setMatrixHeight] = React.useState(64);
  const handleMatrixHeightChange = (event: SelectChangeEvent, child: ReactNode) => {
    setMatrixHeight(Number.parseInt(event.target.value));
  };

  const [virtualMatrix, setVirtualMatrix] = React.useState(new VirtualMatrixConfiguration(128, 128));

  const returnValue = () => {
    let value = new VirtualMatrixConfiguration(matrixWidth, matrixHeight);
    setVirtualMatrix(() => value);
    callbackModel.virtualMatrixConfiguredCallback(value);
  };
  const allowedValues = [16, 32, 64, 128, 256];

  return <>
    <Typography component="div" variant="body1">
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
        <br/>
        <Button sx={{ width: addVirtualMatrixDialogWidth - defaultPaddingSize * 5, color: 'text.primary', backgroundColor: 'secondary.main' }} onClick={returnValue}>
          Add
        </Button>
      </Box>
    </Typography>
  </>
};

export default MatrixConfigurator;