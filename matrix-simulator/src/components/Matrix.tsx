import { useState } from "react";
import { MatrixConfiguration } from "./MatrixConfiguration";
import { VirtualCanvas } from "../models/VirtualCanvas";
import VisualPixelRow from "./VisualPixelRow";

function Matrix(configuration: MatrixConfiguration) {
    const [canvas, setCanvas] = useState(new VirtualCanvas(configuration.width, configuration.height));
    return <div>
        {canvas.pixels.map((x, i) => <div key={i}>
            <VisualPixelRow key={i} {...x} />
        </div>)}
    </div>
}

export default Matrix;