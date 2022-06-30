
import { combineEpics, Epic, ofType } from "redux-observable";
import { catchError, filter, from, map, mergeMap } from "rxjs";
import { addTodoActionType, deleteTodoActionType, deleteTodoAction, fetchTodoAction, updateTodoActionType } from "../../actions/todo/todoActions";
import { queryAddTodo, queryDeleteTodo as queryDeleteTodo, queryGetAllTodo, queryUpdateTodo } from "../../queries/todoQueries";
import { graphqlRequest } from "../../queryToApi/queryToApi";
import { addToDo, fetchToDo, removeTodo, updateTodo } from "../../Slice/todo/todoSlice";



const fetchTodoEpic = (action$: any) =>
  action$.pipe(
    ofType(fetchTodoAction),
    mergeMap(() => from(graphqlRequest(queryGetAllTodo)).pipe(
      map(response =>fetchToDo(response.data.tasksQueries.getAllTodos)
      ))));

const deleteTodoEpic = (action$: any) =>
  action$.pipe(
    ofType(deleteTodoActionType),
    mergeMap((action: any) => from(graphqlRequest(queryDeleteTodo, {
      id: action.payload
    }))
      .pipe(
        map(response => {
          console.log(response);
          return removeTodo(response.data.taskMutation.delete.id);
        }))))

const updateTodoEpic = (action$: any) =>
  action$.pipe(
    ofType(updateTodoActionType),
    mergeMap((action: any) => from(graphqlRequest(queryUpdateTodo, {
      todoUpdate: action.payload
    }))
      .pipe(
        map(response => {
          console.log(response);
          return updateTodo(response.data.taskMutation.update)
        }))))

const addTodoEpic = (action$: any) =>
  action$.pipe(
    ofType(addTodoActionType),
    mergeMap((action: any) => from(graphqlRequest(queryAddTodo, {
      todoCreate: action.payload
    }))
      .pipe(
        map(response => {
          console.log(response);
          return addToDo(response.data.taskMutation.create);
        }))))

export const todoEpic = combineEpics(fetchTodoEpic, deleteTodoEpic, addTodoEpic, updateTodoEpic);