import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { IToDoType } from "../../types/ToDoType"

interface ToDoState{
todo: IToDoType[],
isLoading: boolean,
error: null|string
}

const initialState = { 
todo: [] as IToDoType[],
isLoading: false,
error: ""
}

export const toDoSlice = createSlice({
name: 'todo',
initialState,
reducers:{
fetchToDo(state){
    state.isLoading=true;
},
fetchToDoSuccess(state,action: PayloadAction<IToDoType[]>){
    state.isLoading=false;
    state.error='';
    state.todo =action.payload;
},
fetchToDoError(state,action: PayloadAction<string>){
    state.error=action.payload;
},
addToDo(state, action:PayloadAction<IToDoType>){
state.todo.push(action.payload)
}
}});

export default toDoSlice.reducer;