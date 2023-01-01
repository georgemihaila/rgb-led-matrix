import { PhysicalMatrixLocator } from '../../components/configuration/PhysicalMatrixLocator';

export interface IAutodiscoverService {
    locate(): Promise<Array<PhysicalMatrixLocator>>
}