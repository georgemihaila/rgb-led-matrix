import { VirtualMatrixConfiguration } from "../../components/configuration/VirtualMatrixConfiguration";
import { VirtualCanvas } from "../VirtualCanvas";

export class MatrixModel {
    private _canvas: VirtualCanvas;
    public get canvas(): VirtualCanvas {
        return this._canvas;
    }
    private set canvas(value: VirtualCanvas) {
        this._canvas = value;
    }
    constructor(configuration: VirtualMatrixConfiguration){
        this._canvas = new VirtualCanvas(configuration.widthPixels, configuration.heightPixels);
    }
}