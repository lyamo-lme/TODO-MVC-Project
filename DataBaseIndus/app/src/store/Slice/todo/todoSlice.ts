import { createSlice, PayloadAction } from "@reduxjs/toolkit"
import { ToDoType } from "../../../type/react/todo/TodoType";

interface TodoState {
   todo: ToDoType[],
   loading: boolean,
   error: string,

   errorAddTodo: string,

}

const initialState: TodoState = {
   todo: [] as ToDoType[],
   loading: true,
   error: '',

   errorAddTodo: ''

}

const todoSlice = createSlice({
   name: 'todo',
   initialState,
   reducers: {
      fetchToDo: (state, action: PayloadAction<ToDoType[]>) => {
         console.log(123)
         return { ...state, todo: action.payload }
      },
      fetchToDoSuccess: (state, action: PayloadAction<boolean>) => {
         return { ...state, loading: action.payload }
      },
      fetchToDoError: (state, action: PayloadAction<string>) => {
         state.error = action.payload;
      },
      addToDo: (state, action: PayloadAction<ToDoType>) => {
         return { ...state, todo: state.todo.concat(action.payload) };
      },
      removeTodo: (state, action: PayloadAction<number>) => {
         console.log(action.payload);
         return { ...state, todo: state.todo.filter(item => item.id !== action.payload) }
      },
      updateTodo: (state, action: PayloadAction<ToDoType>) => {
         const i = state.todo.findIndex(item => item.id == action.payload.id);
         var todos = state.todo.slice();
         todos[i] = action.payload;
         return { ...state, todo: todos }
      }
   }
});

export const { removeTodo, addToDo, fetchToDo, fetchToDoError, fetchToDoSuccess, updateTodo } = todoSlice.actions;

export default todoSlice;