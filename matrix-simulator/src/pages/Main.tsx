import React, { useState } from "react";
import Matrix from "../components/Matrix";
import { VirtualMatrixConfiguration } from "../components/configuration/VirtualMatrixConfiguration";
import Draggable from "react-draggable";
import { Resizable } from "re-resizable";
import { VirtualMatrixConfigurator } from "../components/configuration/VirtualMatrixConfigurator";
import { ConfigurationCallbackModel } from "../components/configuration/ConfigurationCallbackModel";

function Main() {
    const defaultWidth: number = 300;
    const [width, setWidth] = useState(defaultWidth);

    const [matrices, setMatrices] = React.useState(Array<VirtualMatrixConfiguration>)
    const virtualMatrixConfigured = new ConfigurationCallbackModel(
        (virtualMatrix: VirtualMatrixConfiguration) => {
            setMatrices([...matrices, virtualMatrix]);
        });
    return <>
        {matrices.map((config, i) =>
            <Resizable key={i}
                enable={{
                    top: false, right: false, bottom: false, left: false, topRight: false, bottomRight: false, bottomLeft: false, topLeft: false
                }}
                defaultSize={{
                    width: width,
                    height: config.getHeight()
                }}
                style={{ display: 'inline-block' }}>
                <div style={{ cursor: 'grabbing', border: `${config.paddingThickness}px solid red` }}>
                    <Matrix {...config} />
                </div>
            </Resizable>)}
        <Draggable key={1}>
            <div>
                <VirtualMatrixConfigurator {...virtualMatrixConfigured} />
            </div>
        </Draggable>
    </>
};

export default Main;