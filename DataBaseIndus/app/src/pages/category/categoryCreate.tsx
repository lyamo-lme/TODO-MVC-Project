import { useState } from "react";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../store/hooks";
import { addCategory } from "../../store/Slice/category/categorySlice";
import { RootState } from "../../store/store";
import { ICategoryCreateType } from "../../type/category/CategoryCreateType";
import { onChange } from "../onChange/ChangeProperyInput";
import {form} from "../../style/style";


function CategoryCreate() {
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const dispatch = useAppDispatch();
    const [category, setCategory] = useState<ICategoryCreateType>({
        nameCategory: ''
    })


    const onFinish = (e: React.FormEvent) => {
        e.preventDefault();
        const idCategory = () => {
            if (categories.length == 0) {
                return 0;
            }
            return categories[categories.length - 1].idCategory + 1;
        };
        dispatch(addCategory({
            idCategory: idCategory(),
            nameCategory: nameCategory
        })
        );
    }

    const { nameCategory } = category

    return (
        <>
            <form  style={form} onSubmit={(e) => onFinish(e)}>
                <div>
                    <label >Name Category</label>
                    <input name='nameCategory' value={nameCategory} onChange={(e) => onChange((e), setCategory)} required />
                    <button type="submit">Submit</button>
                </div>
            </form>

        </>
    );
}

export default CategoryCreate;