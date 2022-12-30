import * as React from 'react';
import Box from '@mui/material/Box';
import InputLabel from '@mui/material/InputLabel';
import MenuItem from '@mui/material/MenuItem';
import FormControl from '@mui/material/FormControl';
import Select, { SelectChangeEvent } from '@mui/material/Select';
import { Typography } from '@mui/material';

function VirtualMatrixConfigurator() {
  const [matrixWidth, setMatrixWidth] = React.useState('64');
  const handleMatrixWidthChange = (event: SelectChangeEvent) => {
    setMatrixWidth(event.target.value as string);
  };

  const [matrixHeight, setMatrixHeight] = React.useState('64');
  const handleMatrixHeightChange = (event: SelectChangeEvent) => {
    setMatrixHeight(event.target.value as string);
  };

  const allowedValues = [16, 32, 64, 128, 256];

  const width = 250;

  return <>
    <Typography component="div" variant="body1">
      <Box sx={{ maxWidth: width, backgroundColor: 'secondary.main', color: 'text.primary', padding: '5px' }}>
        <center>
          <b>Configure virtual matrix</b>
        </center>
        <br />
        <Box sx={{ maxWidth: width }}>
          <FormControl fullWidth>
            <InputLabel id="width-label" sx={{ color: 'text.primary' }}>Width</InputLabel>
            <Select
              labelId="width-label"
              id="matrix-width-select"
              value={matrixWidth}
              label="Width"
              onChange={handleMatrixWidthChange}>
              {allowedValues.map(x => <MenuItem value={x}>{x}px</MenuItem>)}
            </Select>
          </FormControl>
        </Box>
        <Box sx={{ maxWidth: width }}>
          <FormControl fullWidth>
            <InputLabel id="height-label" sx={{ color: 'text.primary' }}>Height</InputLabel>
            <Select
              labelId="height-label"
              id="matrix-height-select"
              value={matrixHeight}
              label="Height"
              onChange={handleMatrixHeightChange}>
              {allowedValues.map(x => <MenuItem value={x}>{x}px</MenuItem>)}
            </Select>
          </FormControl>
        </Box>
      </Box>
    </Typography>
  </>
};

export default VirtualMatrixConfigurator;