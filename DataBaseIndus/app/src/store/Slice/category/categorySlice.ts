import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { ICategoryType } from "../../../type/category/CategoryType";


interface categoryState {
    category: ICategoryType[],
    error: string,
    loading: boolean

}

const initialState: categoryState = {

    category: [{
        idCategory:0,
        nameCategory: "Work"
    }] as ICategoryType[],
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
    fetchCategorySuccess:(state,action: PayloadAction<ICategoryType[]>)=>{
        state.loading=false;
        state.error='';
        state.category =action.payload;
    },
    fetchCategoryError:(state,action: PayloadAction<string>)=>{
        state.error=action.payload;
    },
    addCategory:(state, action: PayloadAction<ICategoryType>)=>{
        return {...state,category: state.category.concat(action.payload)};
    },
    removeCategory:(state,action: PayloadAction<number>)=>{
        return {...state, category: state.category.filter((item)=>item.idCategory!==action.payload)}
    },
    updateCategory:(state,action:PayloadAction<ICategoryType>)=>{
     const id = state.category.find(item => item.idCategory == action.payload.idCategory)?.idCategory
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