import { IAutodiscoverService } from './IAutodiscoverService';
import { PhysicalMatrixLocator } from '../../components/configuration/PhysicalMatrixLocator';

export class MockAutodiscoverService implements IAutodiscoverService {
    constructor() { }

    public locate(): Promise<Array<PhysicalMatrixLocator>> {
        return new Promise<Array<PhysicalMatrixLocator>>(() => {
            return [new PhysicalMatrixLocator("http://10.10.0.88:5050")];
        });
    }
}