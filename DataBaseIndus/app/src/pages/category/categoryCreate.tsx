import { useState } from "react";
import { useSelector } from "react-redux";
import { addCategoryAction } from "../../store/actions/category/categoryActions";
import { useAppDispatch } from "../../store/hooks";
import { addCategory } from "../../store/Slice/category/categorySlice";
import { RootState } from "../../store/store";
import { CategoryCreateType } from "../../type/react/category/CategoryCreateType";
import { onChange } from "../onChange/ChangeProperyInput";


function CategoryCreate() {
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispatch = useAppDispatch();
    const [category, setCategory] = useState<CategoryCreateType>({
        nameCategory: ''
    })
    const onFinish = (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(addCategoryAction(category));
    }

    const { nameCategory } = category

    return (
        <>
            <div className="block-form form">
                <form className="form" onSubmit={(e) => onFinish(e)}>
                    <div>
                        <label>Name Category</label>
                        <input name='nameCategory' value={nameCategory} onChange={(e) => onChange((e), setCategory)} required />
                        <button type="submit">Submit</button>
                    </div>
                </form>
            </div>
        </>
    );
}

export default CategoryCreate;