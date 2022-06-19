import { useState } from "react";
import { useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import { useAppDispatch } from "../../store/hooks";
import { fetchToDo, removeTodo, updateTodo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { center, itemTodo, itemTodoUndone } from "../../style/style";


function DoneTodoList() {

    const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo).filter((item) => item.taskCompleted)
    const dispatch = useAppDispatch()
    const deleteTodo = (id: number) => {
        dispatch(removeTodo(id));
    }
    const stringEdit = "/edit/todo/"
    if (todo.length == 0) {
        return (<h1 style={center}>Non Done Todo</h1>)
    }
    return (<>
        <table style={{ marginLeft: "10%" }}>
            <caption>Done</caption>
            <tbody>
            <tr>
                <th>Name Todo</th>
                <th>Dead Line</th>
                <th>Category</th>
                <th></th>
                <th></th>
                <th></th>
            </tr>

            {todo.map((item) => {
                if (item.taskCompleted)
                    return (
                        <tr key={item.id} style={itemTodoUndone}>
                            <td>{item.nameTodo} </td>
                            <td>{item.deadLine}</td>
                            <td>{item.nameCategory}</td>
                            <td><NavLink to={stringEdit + item.id} >Edit</NavLink></td>
                            <td><img src={require('../../icons/delete.png')} onClick={() => deleteTodo(item.id)} /></td>
                        </tr>);
            })}
              </tbody>
        </table>

    </>
    );



}

export default DoneTodoList;
