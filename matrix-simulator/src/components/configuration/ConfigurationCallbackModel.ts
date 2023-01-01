import { PhysicalMatrixLocator } from "./PhysicalMatrixLocator";
import { VirtualMatrixConfiguration } from "./VirtualMatrixConfiguration";

export class ConfigurationCallbackModel {
    constructor(
        public virtualMatrixConfiguredCallback: (virtualMatrix: VirtualMatrixConfiguration) => void,
        public physicalMatrixConfiguredCallback: (virtualMatrix: PhysicalMatrixLocator) => void){

    }
}