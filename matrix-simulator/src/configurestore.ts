import { connectRouter } from 'connected-react-router';
import { AppState } from './AppState';
import { combineReducers, configureStore } from '@reduxjs/toolkit';
import { addVirtualMatrix } from './infra/slices/MatricesSlice';
import { VirtualMatrixConfiguration } from './components/configuration/VirtualMatrixConfiguration';
/*
const preloadedState: AppState = new AppState([new VirtualMatrixConfiguration(0, 0)], {
    matrices: addVirtualMatrix
});
*/
const preloadedState = {
    initialState:[],
    reducer: {
        matrices: addVirtualMatrix
    }
}
//const history = new History();
const rootReducer = combineReducers({
    //router: connectRouter(history),

});

export const store = configureStore({
    ...
    preloadedState,
    devTools: process.env.NODE_ENV !== 'production',

})

