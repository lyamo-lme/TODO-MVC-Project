import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { useAppDispatch } from "../../store/hooks";
import { updateCategory } from "../../store/Slice/category/categorySlice";
import { fetchToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { ICategoryType } from "../../type/category/CategoryType";
import { IToDoType } from "../../type/todo/TodoType";
import { onChange } from "../onChange/ChangeProperyInput";
import {form} from "../../style/style";
interface IConstEditCategory {
    id: number,
    category: ICategoryType | undefined
}

export function CategoryEdit() {
    const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo)
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const navigate = useNavigate();
    const editCategory: IConstEditCategory = {
        id: -1,
        category: undefined,
    }
    const { id } = useParams();
    console.log(id)
    let Category: ICategoryType = {
        idCategory: 0,
        nameCategory: ""
    }
    if (id != undefined) {
        editCategory.id = parseInt(id);
    }
    editCategory.category = useSelector((s: RootState) => s.rootReducer.categoryReducer.category.find(item => item.idCategory == editCategory.id))
    if (editCategory.category != undefined) {
        Category = editCategory.category;
    }
    const [category, setCategory] = useState<ICategoryType>(Category)
    const dispatch = useAppDispatch();
    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        if (category != undefined) {
            dispatch(updateCategory(category))
        }
        navigate('/category');
    }
    const { nameCategory } = category
    if (editCategory.category != undefined) {
        return (
            <>  <form style={form} onSubmit={(e) => onFinish(e)}>
                <div>
                    <label>Name Category</label>
                    <input name='nameCategory' value={nameCategory} onChange={(e) => setCategory({ ...category, nameCategory: e.target.value })} required />
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