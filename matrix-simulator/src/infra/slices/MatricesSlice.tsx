import { AnyAction, Dispatch, createSlice } from "@reduxjs/toolkit";
import { AppState } from "../../AppState";
import { VirtualMatrixConfiguration } from '../../components/configuration/VirtualMatrixConfiguration';

export interface IVirtualMatricesState {
    matrices: Array<VirtualMatrixConfiguration>
}

const initialState: IVirtualMatricesState = {
    matrices: new Array<VirtualMatrixConfiguration>()
}

const matricesSlice = createSlice({
    name: 'matrices',
    initialState,
    reducers: {
        addVirtualMatrix: (state: IVirtualMatricesState, _) => {
            console.log('adding');
            //state.matrices.push(new VirtualMatrixConfiguration(action.payload.//matrixWidth, action.payload.matrixHeight));
        }
    }
});

export const { addVirtualMatrix } = matricesSlice.actions;

export const add1 = (matrix: { matrixWidth: number, matrixHeight: number }) => (dispatch: any, state: any) => {
    console.log('add1 ' + JSON.stringify(matrix))
    console.log('getState: ' + JSON.stringify(state));
    state.virtualMatrices.push(new VirtualMatrixConfiguration(matrix.matrixWidth, matrix.matrixHeight));
    dispatch(addVirtualMatrix(matrix));
}

export const selectVirtualMatrices = (state: IVirtualMatricesState) => state.matrices;

export default matricesSlice.reducer;