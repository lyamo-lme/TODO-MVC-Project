import { NavLink } from "react-router-dom";
import { useAppDispatch, useAppSelector } from "../../store/hooks";
import { removeCategory } from "../../store/Slice/category/categorySlice";
import { RootState } from "../../store/store";
import { block, center } from "../../style/style";


function CategoryList() {
    const categories = useAppSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispath = useAppDispatch();
    const deleteCategory = (id: number) => {
        dispath(removeCategory(id));
    }
    if (categories.length == 0) {
        return (
            <h1 style={center}>Non Categories</h1>

        )
    }
    return (
        <>
            <div style={block}>
                <div style={center}>CategoryList</div>

                <table style={{ width: "80%" }}>
                <tbody>
                    <tr>
                        <th>Category</th>
                        <th></th>
                        <th></th>
                    </tr>
                    {categories.map((item) =>
                        <tr key={item.idCategory}>
                            <td>{item.nameCategory}</td>
                            <td><NavLink to={'/edit/category/' + item.idCategory}>Edit</NavLink></td>
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