import { useEffect, useState } from "react";
import { Pixel } from "../models/Pixel";

function VisualPixel(pixel: Pixel) {
    const [value, setValue] = useState(pixel);
    useEffect(() => {
        setValue(pixel);
    });
    let size = 10;
    return <div style={{ backgroundColor: `rgb(${value.color.r},${value.color.g},${value.color.b})`, width: `${size}px`, height: `${size}px`, display: 'flex', borderWidth: '0px', marginTop: -size, padding: 0 }} />
}

export default VisualPixel;