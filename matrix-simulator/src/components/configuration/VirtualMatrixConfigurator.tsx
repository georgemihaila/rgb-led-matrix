import { TabContext, TabList, TabPanel } from "@mui/lab";
import { ConfigurationCallbackModel } from "./ConfigurationCallbackModel";
import MatrixConfigurator from "./MatrixConfigurator";
import { Box, Button, Tab, Tabs } from "@mui/material";
import { useState } from "react";
import { addVirtualMatrixDialogWidth } from "../../infra/constants";

function a11yProps(index: number) {
    return {
        id: `simple-tab-${index}`,
        'aria-controls': `simple-tabpanel-${index}`,
    };
}

export function VirtualMatrixConfigurator(callbackModel: ConfigurationCallbackModel) {
    const [value, setValue] = useState('1');
    const handleChange = (event: React.SyntheticEvent, newValue: string) => {
        setValue(newValue);
    };
    return <>
        <Box sx={{ backgroundColor: '#673ab7', color: '#f06292', maxWidth: addVirtualMatrixDialogWidth }}>
            <TabContext value={value}>
                <Box sx={{ backgroundColor: '#7986cb', borderBottom: 1, borderColor: 'divider' }}>
                    <TabList onChange={handleChange}>
                        <Tab label="Virtual" value="1" />
                        <Tab label="Physical" value="2" />
                        <Tab label="RMQ" value="3" />
                    </TabList>
                </Box>
                <TabPanel value="1">
                    <MatrixConfigurator {...callbackModel} />
                </TabPanel>
                <TabPanel value="2">
                    physical
                </TabPanel>
                <TabPanel value="3">
                    RMQ connection
                </TabPanel>
            </TabContext>
        </Box>
    </>
}