import { useEffect, useRef, useState } from "react";
import { MatrixConfiguration } from "./MatrixConfiguration";
import { VirtualCanvas } from "../models/VirtualCanvas";
import VisualPixelRow from "./VisualPixelRow";
import { Vector2 } from "../models/Vector2";

function Matrix(configuration: MatrixConfiguration) {
    const [virtualCanvas, setVirtualCanvas] = useState(new VirtualCanvas(configuration.width, configuration.height));
    const pixelSize = 2;
    const borderThickness = 2;
    const pb = pixelSize + borderThickness;
    let size: Vector2 = new Vector2(configuration.width * (pixelSize + borderThickness), configuration.height * (pixelSize + borderThickness));
    const canvasRef = useRef(null);
    const draw = (ctx: any) => {
        ctx.fillStyle = '#111111'
        ctx.rect(0, 0, size.x, size.y);
        ctx.fill();
        virtualCanvas.pixels.forEach((row, xi) => {
            row.forEach((value, yi) => {
                ctx.beginPath();
                ctx.fillStyle = `rgb(${value.color.r},${value.color.g},${value.color.b})`;
                console.log(`rgb(${value.color.r},${value.color.g},${value.color.b})`)
                ctx.arc(
                    borderThickness * (xi + 1) + pb * xi, 
                    borderThickness * (yi + 1) + pb * yi, 
                    pixelSize, 
                    0, 
                    2 * Math.PI);
                ctx.fill();
            });
        });
    }

    useEffect(() => {
        const canvas: any = canvasRef.current;
        let context = null;
        if (canvas !== null) {
            context = canvas.getContext('2d')
        }
        draw(context)
    }, [draw])

    return <canvas ref={canvasRef} width={size.x.toString()} height={size.y.toString()} placeholder={virtualCanvas.toString()} />
}

export default Matrix;