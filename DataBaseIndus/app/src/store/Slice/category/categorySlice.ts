import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { CategoryCreateType } from "../../../type/react/category/CategoryCreateType";
import { CategoryType } from "../../../type/react/category/CategoryType";


interface categoryState {
    category: CategoryType[],
    error: string,
    loading: boolean

}

const initialState: categoryState = {

    category: [] as CategoryType[],
    error: '',
    loading: true
}

const categorySlice = createSlice({
    name: "category",
    initialState,
    reducers: {
        fetchCategoryLoading: (state) => {
            state.loading = true;
        },
        setCategory: (state, action: PayloadAction<CategoryType[]>) => {
            state.category = action.payload;
        },
        setCategoryError: (state, action: PayloadAction<string>) => {
            state.error = action.payload;
        },
        addCategory: (state, action: PayloadAction<CategoryType>) => {
            return {...state, category: state.category.concat(action.payload)};
        },
        removeCategory: (state, action: PayloadAction<number>) => {
            return { ...state, category: state.category.filter((item) => item.idCategory !== action.payload) }
        },
        updateCategory: (state, action: PayloadAction<CategoryType>) => {
            const id = state.category.findIndex(item => item.idCategory == action.payload.idCategory)
            var categories = state.category.slice()
            categories[id] = action.payload
            return { ...state, category: categories }
        }
    }
});

export default categorySlice;
export const { removeCategory, addCategory,  setCategory, fetchCategoryLoading, updateCategory } = categorySlice.actions;