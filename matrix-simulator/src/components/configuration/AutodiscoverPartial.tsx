import { Fingerprint } from "@mui/icons-material";
import { Alert, Box, IconButton, LinearProgress, Stack } from "@mui/material";

export function AutodiscoverPartial() {
    return <>
        <Stack sx={{ width: '100%' }} spacing={2}>
            <Alert severity="info">Searching for LED matrices...</Alert>
            <Box sx={{ width: '100%' }}>
                <LinearProgress />
            </Box>
        </Stack>
    </>
}