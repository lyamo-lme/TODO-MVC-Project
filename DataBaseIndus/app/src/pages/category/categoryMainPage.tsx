import { useEffect } from "react";
import { fetchCategoryAction } from "../../store/actions/category/categoryActions";
import { useAppDispatch } from "../../store/hooks";
import CategoryCreate from "./categoryCreate";
import CategoryList from "./categoryList";


export function CategoryMainPage() {
    
    const dispatch = useAppDispatch();
    useEffect(() => {
        dispatch({type: fetchCategoryAction});
    },[]);

    return (
        <>
            <CategoryCreate />
            <CategoryList />
        </>
    );
}

