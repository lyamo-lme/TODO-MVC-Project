import {combineReducers, configureStore} from "@reduxjs/toolkit";
import {  toDoSlice } from "./reducers/ToDoSlice";


const rootReducer =combineReducers({
    todoReducer: toDoSlice.reducer
})

 export const  setupStore=()=>{
    return configureStore({
        reducer:rootReducer
    })
 }

export type RootState = ReturnType<typeof rootReducer>;
export type AppStore = ReturnType<typeof setupStore>;
export type AppDispath = AppStore["dispatch"];

