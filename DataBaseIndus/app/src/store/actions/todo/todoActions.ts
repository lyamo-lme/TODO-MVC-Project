import { createAction } from "@reduxjs/toolkit";
import { ToDoCreateType } from "../../../type/react/todo/TodoCreateType";
import { ToDoUpdateType } from "../../../type/react/todo/TodoUpdateType";

export const fetchTodoActionType = "fetchTodo";
export const deleteTodoActionType = "deleteTodo";
export const addTodoActionType = "addTodo";
export const updateTodoActionType = "updateTodo";

export const fetchTodoAction = () => {
    return {
        type: fetchTodoActionType,
    } ;
};

export const deleteTodoAction = createAction<number>(deleteTodoActionType);
export const addTodoAction = createAction<ToDoCreateType>(addTodoActionType);
export const updateTodoAction = createAction<ToDoUpdateType>(updateTodoActionType);