import { VirtualMatrixConfiguration } from "./VirtualMatrixConfiguration";

export class ConfigurationCallbackModel {
    constructor(
        public virtualMatrixConfiguredCallback: (virtualMatrix: VirtualMatrixConfiguration) => void){

    }
}