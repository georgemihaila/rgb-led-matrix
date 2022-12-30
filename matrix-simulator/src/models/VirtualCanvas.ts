import { Color } from "./Color";
import { Pixel } from "./Pixel";
import { Vector2 } from "./Vector2";

export class VirtualCanvas {
    public pixels: Pixel[][];
    constructor(public width: Number, public height: Number) {
        this.pixels = [];
        for (let x = 0; x < width; x++) {
            this.pixels[x] = [];
            for (let y = 0; y < height; y++) {
                this.pixels[x][y] = new Pixel(new Vector2(x, y), Color.getRandom());
            }
        }
    }
}