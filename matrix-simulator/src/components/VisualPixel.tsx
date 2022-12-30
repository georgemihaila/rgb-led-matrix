import { useEffect, useState } from "react";
import { Pixel } from "../models/Pixel";

function VisualPixel(pixel: Pixel) {
    const [value, setValue] = useState(pixel);
    useEffect(()=>{
        setValue(pixel);
    });
    return <>
        {value.color.r}
        {value.color.g}
        {value.color.b}
    </>
}

export default VisualPixel;