import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { ToDoCreateType } from "../../../type/todo/TodoCreateType";
import { ToDoType } from "../../../type/todo/TodoType";

interface TodoState{
todo: ToDoType[],
loading: boolean,
error: string,

errorAddTodo: string,

}

const initialState:TodoState = {
todo: [] as ToDoType[],
loading: true,
error: '',

errorAddTodo: ''

}

 const todoSlice = createSlice({
    name: 'todo',
    initialState,
    reducers:{
    fetchToDo:(state,action: PayloadAction<ToDoType[]>)=>{
        return {...state, todo: action.payload}
    },
    fetchToDoSuccess:(state,action: PayloadAction<boolean>)=>{
       return {...state, loading: action.payload}
    },
    fetchToDoError:(state,action: PayloadAction<string>)=>{
        state.error=action.payload;
    },
    addToDo:(state, action: PayloadAction<ToDoCreateType>)=>{
       return {...state,todo: state.todo.concat({...action.payload,
           id: state.todo.length==0? 1:state.todo[state.todo.length-1].id+1,
           taskCompleted: false,
         })};
    },
      removeTodo:(state, action: PayloadAction<number>)=>{
         console.log(action.payload);
       return {...state, todo: state.todo.filter(item=>item.id!==action.payload) }
   },
     updateTodo:(state,action:PayloadAction<ToDoType>)=>{
      const id = state.todo.find(item => item.id == action.payload.id)?.id
      var todos = state.todo.slice() 
      if(id!=undefined){
         todos[id-1]=action.payload
      }
      return{...state, todo: todos}
   }
     }
});

   export const {removeTodo, addToDo,fetchToDo,fetchToDoError,fetchToDoSuccess,updateTodo} =todoSlice.actions;
  
    export default todoSlice;
