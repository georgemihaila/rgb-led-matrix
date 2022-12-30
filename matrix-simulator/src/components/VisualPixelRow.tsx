import { useEffect, useState } from "react";
import { Pixel } from "../models/Pixel";
import VisualPixel from "./VisualPixel";

function VisualPixelRow(pixels: Array<Pixel>) {
    const [pixelData, setPixelData] = useState(Object.keys(pixels).map(i => pixels[Number.parseInt(i)]));
    return <>
        <div style={{ borderWidth: '10px', borderColor: 'white' }}>
            {pixelData.map((x, i) => <VisualPixel key={i} {...x} />)}
        </div>
    </>
}

export default VisualPixelRow;