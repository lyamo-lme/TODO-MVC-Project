import { useEffect } from "react";
import { fetchCategoryAction } from "../../store/actions/category/categoryActions";
import { fetchTodoAction } from "../../store/actions/todo/todoActions";
import { useAppDispatch } from "../../store/hooks";
import TodoCreate from "./todoCreate";
import TodoList from "./todoList";

function TodoMainPage() {
    const dispatch = useAppDispatch();
    /*useEffect(()=>{
        dispatch({type:  fetchTodoAction}); 
        dispatch({type: fetchCategoryAction});
      })*/
    return (
        <>
            <TodoCreate />
            <TodoList />
        </>
    );
}

export default TodoMainPage;
