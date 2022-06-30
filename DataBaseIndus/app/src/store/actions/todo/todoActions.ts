import { createAction } from "@reduxjs/toolkit";
import { ToDoCreateType } from "../../../type/react/todo/TodoCreateType";
import { ToDoUpdateType } from "../../../type/react/todo/TodoUpdateType";

export const fetchTodo = "fetchTodo";
export const deleteTodo = "deleteTodo";
export const addTodo = "addTodo";
export const updateTodoActionType = "updateTodo";

export const fetchTodoAction = () => {
    return {
        type: fetchTodo,
    } ;
};

export const deleteTodoAction = createAction<number>(deleteTodo);
export const addTodoAction = createAction<ToDoCreateType>(addTodo);
export const updateTodoAction = createAction<ToDoUpdateType>(updateTodoActionType);