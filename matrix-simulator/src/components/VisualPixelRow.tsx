import { useEffect, useState } from "react";
import { Pixel } from "../models/Pixel";
import VisualPixel from "./VisualPixel";

function VisualPixelRow(pixels: Array<Pixel>) {
    const [pixelData, setPixelData] = useState(Object.keys(pixels).map(i => pixels[Number.parseInt(i)]));
    return <>
        <div style={{ display: 'flex', flexWrap: 'wrap' }}>
            {pixelData.map((x, i) => <VisualPixel key={i} {...x} />)}
        </div>
        <br />
    </>
}

export default VisualPixelRow;