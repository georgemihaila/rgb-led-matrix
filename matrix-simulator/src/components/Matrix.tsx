import { VirtualMatrixConfiguration } from "./configuration/VirtualMatrixConfiguration";
import MatrixCanvas from "./MatrixCanvas";
import { addVirtualMatrixDialogWidth } from "../infra/constants";

function Matrix(configuration: VirtualMatrixConfiguration) {
    return <>
        <div style={{ maxWidth: addVirtualMatrixDialogWidth, cursor: 'grabbing' }}>
            <MatrixCanvas {...configuration} />
        </div>
    </>
}

export default Matrix;