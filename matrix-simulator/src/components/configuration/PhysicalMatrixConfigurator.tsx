import { Button, Input, Typography } from "@mui/material";
import { ConfigurationCallbackModel } from "./ConfigurationCallbackModel";
import { addVirtualMatrixDialogWidth, defaultPaddingSize } from "../../infra/constants";
import { PhysicalMatrixLocator } from "./PhysicalMatrixLocator";
import { ChangeEvent, ChangeEventHandler, useState } from 'react';
import { AutodiscoverPartial } from "./AutodiscoverPartial";


export function PhysicalMatrixConfigurator() {
    const [url, setUrl] = useState("");
    const [urlValid, setUrlValid] = useState(false);
    const returnValue = () => {
        let value = new PhysicalMatrixLocator(url);
        //TODO validation
        //callbackModel.physicalMatrixConfiguredCallback(value);
    };
    return <>
        <Typography>
            Add a physical matrix to the canvas. You will be able to see what is being displayed and control it.
        </Typography>
        <br />
        <Input
            style={{ width: addVirtualMatrixDialogWidth - defaultPaddingSize * 5 }}
            placeholder="http://"
            type="url"
            value={url}
            onChange={(e: ChangeEvent<HTMLInputElement | HTMLTextAreaElement> | undefined) => setUrl("")}></Input>
        <br /> <br />
        <AutodiscoverPartial/>
        <br/>
        <Button
            disabled={!urlValid}
            sx={{
                width: addVirtualMatrixDialogWidth - defaultPaddingSize * 5,
                color: 'text.primary',
                backgroundColor: '#ff7043'
            }}
            onClick={returnValue}>
            Add
        </Button>
    </>;
}
