import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { dateToSting, stringToDate } from "../../parseDate/parseDate";
import { updateTodoAction } from "../../store/actions/todo/todoActions";
import { useAppDispatch } from "../../store/hooks";
import { updateTodo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { emptyTodo, ToDoType as ToDoType } from "../../type/react/todo/TodoType";
import { ToDoUpdateType } from "../../type/react/todo/TodoUpdateType";

export function TodoEdit() {
    const navigate = useNavigate();
    const { idTodo } = useParams();
    let Todo = emptyTodo;
    let id = idTodo != undefined ? parseInt(idTodo) : 0;
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category);
    const findTodo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo.find(item => item.id == id))
    Todo = findTodo != undefined ? findTodo : emptyTodo;
    const [todo, setTodo] = useState<ToDoUpdateType>({
        nameTodo: Todo.nameTodo,
        id: Todo.id,
        categoryId: Todo.categoryId,
        deadLine: Todo.deadLine,
        taskCompleted: Todo.taskCompleted
       });
    const dispatch = useAppDispatch();

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        console.log(todo.deadLine);
        dispatch(updateTodoAction({...todo,deadLine: todo.deadLine!=""||todo.deadLine!=null?stringToDate(deadLine):null}))
        navigate('/todo');
    }

    const { nameTodo, categoryId, deadLine, taskCompleted } = todo

    if (findTodo != undefined) {
        return (
            <>
                <form className="block" style={{ width: "fit-content" }} onSubmit={(e) => onFinish(e)}>
                    <table>
                        <tbody>
                            <tr>
                                <td> Name Todo</td>
                                <td>  <input name='nameTodo' value={nameTodo} onChange={(e) => setTodo({ ...todo, nameTodo: e.target.value })} required />
                                </td>
                            </tr>
                            <tr>
                                <td>Dead Line </td>
                                <td>   <input name="deadLine" type="datetime-local" value={deadLine!=null?deadLine:0} onChange={(e) => setTodo({ ...todo, deadLine: e.target.value })} />
                                </td>
                            </tr>
                            <tr>
                                <td>Category</td>
                                <td><select name="categoryId" value={categoryId} onChange={(e) => setTodo({ ...todo, categoryId: parseInt(e.target.value) })}>
                                    <option value={0} >None</option>
                                    {categories.map((item) =>
                                        <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
                                    )}
                                </select></td>
                            </tr>
                            <tr>
                                <td>Status complete</td>
                                <td>  <select name="taskCompleted" value={taskCompleted ? 1 : 0} onChange={(e) => setTodo({ ...todo, taskCompleted: parseInt(e.target.value) == 1 ? true : false })}>
                                    <option value={0}>Undone</option>
                                    <option value={1}>Done</option>
                                </select>
                                </td>
                            </tr>
                            <tr >
                                <td colSpan={2}><button type="submit">Submit</button></td>
                            </tr>
                        </tbody>
                    </table>



                </form>
            </>
        );
    }
    return (<p>Error: Todo with id: {idTodo} not foun</p>)
}