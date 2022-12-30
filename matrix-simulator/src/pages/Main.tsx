import React from "react";
import Matrix from "../components/Matrix";
import { MatrixConfiguration } from "../components/MatrixConfiguration";
import VirtualMatrixConfigurator from "../components/VirtualMatrixConfigurator";
import Draggable from "react-draggable";

function Main() {
    const [matrices, setMatrices] = React.useState(Array<MatrixConfiguration>)
    const virtualMatrixConfigured = {
        callback: (virtualMatrix: MatrixConfiguration) => {
            setMatrices([...matrices, virtualMatrix]);
        }
    }
    return <>
        <Draggable>
            <div style={{ cursor: 'grabbing' }}>
                <VirtualMatrixConfigurator {...virtualMatrixConfigured} />
            </div>
        </Draggable>
        {matrices.map((config, i) => 
        <>
        <Draggable key={i}>
            <div style={{ cursor: 'grabbing' }}>
                <Matrix {...config} />
            </div>
        </Draggable>
        </>)}
    </>
};

export default Main;