import { Color } from "./Color";
import { Vector2 } from "./Vector2";

export interface IPixel {
    position: Vector2;
    color: Color;
}

export class Pixel {
    constructor(public position: Vector2, public color: Color) {

    }
}
