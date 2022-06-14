import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { updateTodo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { IToDoType } from "../../type/todo/TodoType";
import {form} from "../../style/style";
interface IConstEditTodo {
    id: number,
    todo: IToDoType | undefined
}
export function TodoEdit() {
    const navigate = useNavigate();
    const editTodo: IConstEditTodo = {
        id: -1,
        todo: undefined,
    }
    const { idTodo } = useParams();
    let Todo: IToDoType = {
        nameCategory: "",
        nameTodo: "",
        categoryId: 0,
        taskCompleted: false,
        id: 0,
        deadLine: ""
    }
    if (idTodo != undefined) {
        editTodo.id = parseInt(idTodo);
    }
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category);
    editTodo.todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo.find(item => item.id == editTodo.id))
    if (editTodo.todo != undefined) {
        Todo = editTodo.todo;
    }
    const [todo, setTodo] = useState<IToDoType>(Todo);
    const dispatch = useAppDispatch();
    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        let nameCategory = (id:number)=>{
            let name= categories.find((item)=>item.idCategory==id)?.nameCategory;
            if(name!=undefined){
                return name;
            }
            return '';
          };
        if (todo != undefined) {
            dispatch(updateTodo({...todo, nameCategory: nameCategory(todo.categoryId),taskCompleted: todo.taskCompleted}))
        }
        navigate('/todo');
    }
    const { nameTodo, categoryId, deadLine,taskCompleted } = todo
    if (editTodo.todo != undefined) {
        return (
            <>
                <form  style={form} onSubmit={(e) => onFinish(e)}>
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
                            {categories.map((item) =>
                                <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
                            )}
                        </select>
                    </div>
                    <div>
                    <select name="taskCompleted" value={taskCompleted? 1:0} onChange={(e) => setTodo({ ...todo, taskCompleted: parseInt(e.target.value)==1?true:false})}>
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
    return (<p>Error</p>)
}