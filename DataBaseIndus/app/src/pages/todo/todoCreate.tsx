import { useState } from "react";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../store/hooks";
import { addToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { onChange } from "../onChange/ChangeProperyInput";

import { emptyCreateTodo, ToDoCreateType } from "../../type/todo/TodoCreateType";
import { dateToSting } from "../../parseDate/parseDate";

function TodoCreate() {
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispatch = useAppDispatch();
    const [todo, setTodo] = useState<ToDoCreateType>(emptyCreateTodo)

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault();
        let nameCategory = categories.find((item) => item.idCategory == todo.categoryId)?.nameCategory;
        dispatch(addToDo(
            {...todo,
                nameCategory: nameCategory != undefined ? nameCategory : "No Category",
                deadLine: dateToSting(deadLine)
            }))

    }

    const { nameTodo, deadLine, categoryId } = todo


    return (
        <>
            <div className="block-form form">
                <form className="form" onSubmit={(e) => onFinish(e)}>
                    <div>
                        <label>Name Todo</label>
                        <input name='nameTodo' value={nameTodo} onChange={(e) => onChange((e), setTodo)} required />
                    </div>
                    <div>
                        <label> Dead Line</label>
                        <input name="deadLine" type="datetime-local" value={deadLine} onChange={(e) => onChange((e), setTodo)} />
                    </div>
                    <div>
                        <label>Category</label>
                        <select name="categoryId" value={categoryId} onChange={(e) => onChange((e), setTodo)}>
                            <option value={0} >None</option>
                            {categories.map((item) =>
                                <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
                            )}
                        </select>
                    </div>
                    <div>
                        <button type="submit">Submit</button>
                    </div>

                </form>
            </div>
        </>
    );
}

export default TodoCreate;