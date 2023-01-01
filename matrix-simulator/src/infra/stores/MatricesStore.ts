import { configureStore, Reducer } from '@reduxjs/toolkit';
import { addVirtualMatrix } from '../slices/MatricesSlice';

export default configureStore({
    reducer: {
        addVirtualMatrices: (state: any) => {
            return (addVirtualMatrix(state))
        }
    }
});