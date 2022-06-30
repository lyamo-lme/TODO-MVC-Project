import { createAction } from "@reduxjs/toolkit";
import { CategoryCreateType } from "../../../type/react/category/CategoryCreateType";
import { CategoryType } from "../../../type/react/category/CategoryType";

export const fetchCategoryActionType = "fetchCategoryEpic";
export const deleteCategoryActionType = "deleteCategory";
export const addCategoryActionType = "addCategory";
export const updateCategoryActionType = "updateCategory";

export const fetchCategoryAction = () => {
    return {
        type: fetchCategoryActionType,
    } as const;
};
export const deleteCategoryAction = createAction<number>(deleteCategoryActionType);
export const addCategoryAction = createAction<CategoryCreateType>(addCategoryActionType);
export const updateCategoryAction = createAction<CategoryType>(updateCategoryActionType);