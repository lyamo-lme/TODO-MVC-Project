import { useEffect } from "react";
import { NavLink } from "react-router-dom";
import { deleteCategoryAction, fetchCategoryAction } from "../../store/actions/category/categoryActions";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { removeCategory } from "../../store/Slice/category/categorySlice";
import { fetchToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";


function CategoryList() {
    const categories = useAppSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispatch = useAppDispatch();

    const deleteCategory = (id: number) => {
        var answer = window.confirm("Are you sure?");
        if(answer){
            dispatch(deleteCategoryAction(id));
        }
      
    }
    if (categories.length == 0) {
        return (
            <div className="block"><i>Non Categories</i></div>
        )
    }
    return (
        <>
            <div className="block">
                <table>
                    <caption>List of Categories</caption>
                    <tbody>
                        <tr>
                            <th>Category</th>
                            <th colSpan={2}>Actions</th>
                        </tr>
                        {categories.map((item) =>
                            <tr key={item.idCategory}>
                                <td>{item.nameCategory}</td>
                                <td><NavLink to={'/edit/category/' + item.idCategory}><img src={require('../../icons/edit.png')} /></NavLink></td>
                                <td><img src={require('../../icons/delete.png')} onClick={() => deleteCategory(item.idCategory)} /></td>
                            </tr>
                        )}
                    </tbody>
                </table>
            </div>
        </>
    );
}

export default CategoryList;