import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { updateCategoryAction } from "../../store/actions/category/categoryActions";
import { useAppDispatch } from "../../store/hooks";
import { updateCategory } from "../../store/Slice/category/categorySlice";
import { fetchToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { CategoryType as CategoryType, emptyCategoryType as emptyCategory } from "../../type/react/category/CategoryType";

export function CategoryEdit() {
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const { id } = useParams();
    let Category = emptyCategory;
    let idCategory = id == undefined ? 0 : parseInt(id);
    const findCategory = useSelector((s: RootState) => s.rootReducer.categoryReducer.category.find(item => item.idCategory == idCategory))
    Category = findCategory != undefined ? findCategory : emptyCategory;
    const [category, setCategory] = useState<CategoryType>(Category)

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        dispatch(updateCategoryAction(category))
        navigate('/category');
    }
    const { nameCategory } = category
    if (category != undefined) {
        return (
            <>  <form  className="block" style={{width:"fit-content"}}onSubmit={(e) => onFinish(e)}>
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

    return (<div className="block">Error: Category with id:{id} not found</div>)
}