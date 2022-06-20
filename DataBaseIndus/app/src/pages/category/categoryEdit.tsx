import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { useAppDispatch } from "../../store/hooks";
import { updateCategory } from "../../store/Slice/category/categorySlice";
import { fetchToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { CategoryType as CategoryType } from "../../type/category/CategoryType";

type ConstEditCategory = {
    id: number,
    category: CategoryType | undefined
}

export function CategoryEdit() {
    const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo)
    const navigate = useNavigate();
    const editCategory: ConstEditCategory = {
        id: 0,
        category: undefined,
    }
    const { id } = useParams();
    let Category: CategoryType = {
        idCategory: 0,
        nameCategory: ""
    }
    editCategory.id = id!=undefined? parseInt(id): 0;
    editCategory.category = useSelector((s: RootState) => s.rootReducer.categoryReducer.category.find(item => item.idCategory == editCategory.id))
    if (editCategory.category != undefined) {
        Category = editCategory.category;
    }
    const [category, setCategory] = useState<CategoryType>(Category)
    const dispatch = useAppDispatch();
    const onFinish = (e: React.FormEvent) => {
        console.log(id)
        e.preventDefault()
        if (category != undefined) {
            dispatch(updateCategory(category))
        }
        dispatch(fetchToDo(todo.map((item) => {
            if (item.categoryId == category.idCategory) {
                return { ...item, nameCategory: nameCategory };
            }
            return item;
        })))
        console.log("here error")
        navigate('/category');
    }
    const { nameCategory } = category
    if (editCategory.category != undefined) {
        return (
            <>  <form  onSubmit={(e) => onFinish(e)}>
                <div>
                    <p>Name Category</p>
                    <input name='nameCategory' value={nameCategory} onChange={(e) => setCategory({ ...category, nameCategory: e.target.value })} required />
                </div>
                <div>
                    <button type="submit">Submit</button>
                </div>
            </form>

            </>
        );
    }
    return (<p>Error: Category with id:{id} not found</p>)
}