import React, { useState } from "react";
import Matrix from "../components/Matrix";
import { VirtualMatrixConfiguration } from "../components/configuration/VirtualMatrixConfiguration";
import Draggable from "react-draggable";
import { Resizable } from "re-resizable";
import { MatrixConfigurator } from "../components/configuration/MatrixConfigurator";
import { ConfigurationCallbackModel } from "../components/configuration/ConfigurationCallbackModel";
import { PhysicalMatrixLocator } from '../components/configuration/PhysicalMatrixLocator';
import { useSelector } from "react-redux";
import { selectVirtualMatrices } from '../infra/slices/MatricesSlice';
import { useEffect } from 'react';

function Main() {
    const defaultWidth: number = 300;
    const [width, setWidth] = useState(defaultWidth);

    const matrices = useSelector(selectVirtualMatrices);
    const virtualMatrixConfigured = new ConfigurationCallbackModel(
        (virtualMatrix: VirtualMatrixConfiguration) => {

        },
        (physicalMatrixLocator: PhysicalMatrixLocator) => {

        });
    let visualMatrices = [<></>];
    useEffect(() => {
        if (matrices.map === undefined)
            return;
        visualMatrices = matrices?.map((config, i) =>
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
            </Resizable>);
    });
    return <>
        {visualMatrices}
        <Draggable key={1}>
            <div>
                <MatrixConfigurator />
            </div>
        </Draggable>
    </>
};

export default Main;