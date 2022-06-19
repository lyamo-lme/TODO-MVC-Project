import { useState } from "react";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../store/hooks";
import todoSlice, { addToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { onChange } from "../onChange/ChangeProperyInput";
import { form } from "../../style/style";
import { ToDoCreateType } from "../../type/todo/TodoCreateType";

function TodoCreate() {
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispatch = useAppDispatch();
    const [todo, setTodo] = useState<ToDoCreateType>({
        nameTodo: '',
        categoryId: 0,
        deadLine: '',
        nameCategory: ''
    })

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault();
        let nameCategory = categories.find((item) => item.idCategory == todo.categoryId)?.nameCategory;
        dispatch(addToDo({ ...todo, nameCategory: nameCategory != undefined ? nameCategory : "" }))
    }

    const { nameTodo, deadLine, categoryId } = todo


    return (
        <>
            <form style={form} onSubmit={(e) => onFinish(e)}>
                <div>
                    <p>Name Todo</p>
                    <input name='nameTodo' value={nameTodo} onChange={(e) => onChange((e), setTodo)} required />
                </div>
                <div>
                    <p> Dead Line</p>
                    <input name="deadLine" type="datetime-local" value={deadLine} onChange={(e) => onChange((e), setTodo)} />
                </div>
                <div>
                    <p>Category</p>
                    <select name="categoryId" value={categoryId} onChange={(e) => onChange((e), setTodo)}>
                        <option value={0} >None</option>
                        {categories.map((item) =>
                            <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
                        )}
                    </select>
                </div>
                <p>
                    <button type="submit">Submit</button>
                </p>

            </form>

        </>
    );
}

export default TodoCreate;