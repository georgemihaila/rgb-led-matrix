import { MatrixConfiguration } from "./MatrixConfiguration";

function Matrix(configuration: MatrixConfiguration) {
    return <>
        {configuration.width} x {configuration.height}
        <br/>
    </>
}

export default Matrix;