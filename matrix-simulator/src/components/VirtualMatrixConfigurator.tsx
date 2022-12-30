import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import { Button, Typography } from '@mui/material';
import { MatrixConfiguration } from './MatrixConfiguration';
import { ReactNode } from 'react';

function VirtualMatrixConfigurator(callback: any) {
  const [matrixWidth, setMatrixWidth] = React.useState(64);
  const handleMatrixWidthChange = (event: SelectChangeEvent, child: ReactNode) => {
    setMatrixWidth(Number.parseInt(event.target.value));
  };

  const [matrixHeight, setMatrixHeight] = React.useState(64);
  const handleMatrixHeightChange = (event: SelectChangeEvent, child: ReactNode) => {
    setMatrixHeight(Number.parseInt(event.target.value));
  };

  const [virtualMatrix, setVirtualMatrix] = React.useState(new MatrixConfiguration(64, 64));

  const returnValue = () => {
    setVirtualMatrix(() => new MatrixConfiguration(matrixWidth, matrixHeight));
    callback.callback(virtualMatrix);
  };
  const allowedValues = [16, 32, 64, 128, 256];

  const width = 250;

  return <>
    <Typography component="div" variant="body1">
      <Box sx={{ maxWidth: width, backgroundColor: 'primary.main', color: 'text.primary', padding: '5px' }}>
        <center>
          <b>Add virtual matrix</b>
        </center>
        <br />
        <Box sx={{ maxWidth: width }}>
          <FormControl fullWidth>
            <InputLabel id="width-label" sx={{ color: 'text.primary' }}>Width</InputLabel>
            <Select
              labelId="width-label"
              id="matrix-width-select"
              value={matrixWidth.toString()}
              label="Width"
              onChange={handleMatrixWidthChange}>
              {allowedValues.map((x, i) => <MenuItem value={x} key={i}>{x}px</MenuItem>)}
            </Select>
          </FormControl>
        </Box>
        <Box sx={{ maxWidth: width }}>
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
        <Button sx={{ width: width, color: 'text.primary', backgroundColor: 'secondary.main' }} onClick={returnValue}>
          Add
        </Button>
      </Box>
    </Typography>
  </>
};

export default VirtualMatrixConfigurator;