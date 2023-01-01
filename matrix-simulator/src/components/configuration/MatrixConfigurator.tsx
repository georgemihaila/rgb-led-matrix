import { TabContext, TabList, TabPanel } from "@mui/lab";
import { ConfigurationCallbackModel } from "./ConfigurationCallbackModel";
import { Box, Button, Card, CardActions, CardContent, Tab, Tabs, Typography } from "@mui/material";
import { useState } from "react";
import { addVirtualMatrixDialogWidth } from "../../infra/constants";
import { VirtualMatrixConfigurator } from "./VirtualMatrixConfigurator";
import { PhysicalMatrixConfigurator } from "./PhysicalMatrixConfigurator";

export function MatrixConfigurator() {
    const [value, setValue] = useState('1');
    const handleChange = (event: React.SyntheticEvent, newValue: string) => {
        setValue(newValue);
    };
    const bull = (
        <Box
            component="span"
            sx={{ display: 'inline-block', mx: '2px', transform: 'scale(0.8)' }}
        >
        </Box>);
    return <>
        <Card sx={{ maxWidth: addVirtualMatrixDialogWidth, backgroundColor: '#7e57c2' }}>
            <CardContent>
                <Typography variant="h5" component="div" style={{ cursor: 'hand', userSelect: 'none' }}>
                    Add matrix
                </Typography>
            </CardContent>
            <Box sx={{ backgroundColor: '#d0d4ed', color: '#f06292', maxWidth: addVirtualMatrixDialogWidth }}>
                <TabContext value={value}>
                    <Box sx={{ backgroundColor: '#a6d4fa', borderBottom: 1, borderColor: 'divider' }}>
                        <TabList onChange={handleChange}>
                            <Tab label="Virtual" value="1" />
                            <Tab label="Physical" value="2" />
                            <Tab label="RMQ" value="3" />
                        </TabList>
                    </Box>
                    <TabPanel value="1">
                        <VirtualMatrixConfigurator />
                    </TabPanel>
                    <TabPanel value="2">
                        <PhysicalMatrixConfigurator />
                    </TabPanel>
                    <TabPanel value="3">
                        RMQ connection
                    </TabPanel>
                </TabContext>
            </Box>
        </Card>
    </>
}