import { useEffect, useRef, useState } from "react";
import { VirtualMatrixConfiguration } from "./configuration/VirtualMatrixConfiguration";
import { VirtualCanvas } from "../models/VirtualCanvas";

function MatrixCanvas(configuration: VirtualMatrixConfiguration) {
    const [virtualCanvas, setVirtualCanvas] = useState(new VirtualCanvas(configuration.widthPixels, configuration.heightPixels));
    const pixelSize = (configuration.canvasWidth - 2 * configuration.paddingThickness) / (configuration.widthPixels);
    const borderThickness = pixelSize / 2;
    const pb = pixelSize + borderThickness;
    const canvasRef = useRef(null);
    const draw = (ctx: any) => {
        ctx.fillStyle = '#111111'
        ctx.rect(0, 0, configuration.getUsableWidth(), configuration.getUsableHeight());
        ctx.fill();
        virtualCanvas.pixels.forEach((row, xi) => {
            row.forEach((value, yi) => {
                ctx.beginPath();
                ctx.fillStyle = `rgb(${value.color.r},${value.color.g},${value.color.b})`;
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
    return <canvas ref={canvasRef} width={configuration.getUsableWidth().toString()} height={configuration.getUsableHeight().toString()} />
}

export default MatrixCanvas;