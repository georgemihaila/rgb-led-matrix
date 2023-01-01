import { VirtualMatrixConfiguration } from "./components/configuration/VirtualMatrixConfiguration";

export class AppState {
    constructor(public virtualMatrices: Array<VirtualMatrixConfiguration> = new Array<VirtualMatrixConfiguration>(), public reducer: {

    }){
        
    }
}