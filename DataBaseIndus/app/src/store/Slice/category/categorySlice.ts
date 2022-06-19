import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { CategoryCreateType } from "../../../type/category/CategoryCreateType";
import { CategoryType } from "../../../type/category/CategoryType";


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

const  categorySlice= createSlice({
name: "category",
initialState,
reducers:{
    fetchCategoryLoading:(state)=>{
        state.loading=true;
    },
    fetchCategorySuccess:(state,action: PayloadAction<CategoryType[]>)=>{
        state.loading=false;
        state.error='';
        state.category =action.payload;
    },
    fetchCategoryError:(state,action: PayloadAction<string>)=>{
        state.error=action.payload;
    },
    addCategory:(state, action: PayloadAction<CategoryCreateType>)=>{
        return {...state,category: state.category.concat({...action.payload,
        idCategory: state.category.length==0? 1: state.category[state.category.length-1].idCategory+1,
        })};
    },
    removeCategory:(state,action: PayloadAction<number>)=>{
        return {...state, category: state.category.filter((item)=>item.idCategory!==action.payload)}
    },
    updateCategory:(state,action:PayloadAction<CategoryType>)=>{
     const id = state.category.findIndex(item=> item.idCategory == action.payload.idCategory)
     var categories = state.category.slice() 
     if(id!=undefined){
        categories[id]=action.payload
     }
     return{...state, category: categories}
  }
}
});

export default categorySlice;
export const {removeCategory,addCategory,fetchCategoryError,fetchCategorySuccess,fetchCategoryLoading,updateCategory} = categorySlice.actions;