import moment from "moment";
import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { dateToSting, stringToDate } from "../../parseDate/parseDate";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { updateTodo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { emptyTodo, ToDoType as ToDoType } from "../../type/todo/TodoType";

export function TodoEdit() {
    const navigate = useNavigate();
    const { idTodo } = useParams();
    let Todo = emptyTodo;
    let id = 0;

    if (idTodo != undefined) {
        id = parseInt(idTodo);
    }
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category);
    const findTodo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo.find(item => item.id == id))
    Todo = findTodo != undefined ? findTodo : emptyTodo;
    const [todo, setTodo] = useState<ToDoType>({ ...Todo, deadLine: stringToDate(Todo.deadLine) });
    const dispatch = useAppDispatch();

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        let nameCategory = categories.find((item) => item.idCategory == todo.categoryId)?.nameCategory;
        if (todo != undefined) {
            dispatch(updateTodo({
                ...todo, nameCategory: nameCategory != undefined ? nameCategory : "No Category",
                deadLine: dateToSting(deadLine)
            }))
        }
        navigate('/todo');
    }

    const { nameTodo, categoryId, deadLine, taskCompleted } = todo

    if (findTodo != undefined) {
        return (
            <>
                <form onSubmit={(e) => onFinish(e)}>
                    <div>
                        <label> Name Todo </label>
                        <input name='nameTodo' value={nameTodo} onChange={(e) => setTodo({ ...todo, nameTodo: e.target.value })} required />
                    </div>
                    <div>
                        <label>  Dead Line   </label>
                        <input name="deadLine" type="datetime-local" value={deadLine} onChange={(e) => setTodo({ ...todo, deadLine: e.target.value })} />
                    </div>
                    <div>
                        <select name="categoryId" value={categoryId} onChange={(e) => setTodo({ ...todo, categoryId: parseInt(e.target.value) })}>
                            <option value={0} >None</option>
                            {categories.map((item) =>
                                <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
                            )}
                        </select>

                    </div>
                    <div>
                        <select name="taskCompleted" value={taskCompleted ? 1 : 0} onChange={(e) => setTodo({ ...todo, taskCompleted: parseInt(e.target.value) == 1 ? true : false })}>
                            <option value={0}>Undone</option>
                            <option value={1}>Done</option>
                        </select>
                    </div>
                    <div>
                        <button type="submit">Submit</button>
                    </div>
                </form>
            </>
        );
    }
    return (<p>Error: Todo with id: {idTodo} not foun</p>)
}