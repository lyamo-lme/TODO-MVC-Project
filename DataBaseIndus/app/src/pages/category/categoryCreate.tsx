import { useState } from "react";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../store/hooks";
import { addCategory } from "../../store/Slice/category/categorySlice";
import { RootState } from "../../store/store";
import { CategoryCreateType } from "../../type/category/CategoryCreateType";
import { onChange } from "../onChange/ChangeProperyInput";
import {form} from "../../style/style";


function CategoryCreate() {
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispatch = useAppDispatch();
    const [category, setCategory] = useState<CategoryCreateType>({
        nameCategory: ''
    })
    const onFinish = (e: React.FormEvent) => {
        e.preventDefault();
        dispatch(addCategory(category));
        console.log(categories)
    }

    const { nameCategory } = category

    return (
        <>
            <form  style={form} onSubmit={(e) => onFinish(e)}>
                <div>
                    <p>Name Category</p>
                    <input name='nameCategory' value={nameCategory} onChange={(e) => onChange((e), setCategory)} required />
                    <button type="submit">Submit</button>
                </div>
            </form>

        </>
    );
}

export default CategoryCreate;