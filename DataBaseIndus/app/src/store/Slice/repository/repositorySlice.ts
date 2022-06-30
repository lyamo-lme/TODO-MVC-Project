import { createSlice, PayloadAction } from "@reduxjs/toolkit";
import { CategoryCreateType } from "../../../type/react/category/CategoryCreateType";
import { CategoryType } from "../../../type/react/category/CategoryType";


interface repositoryState {
    typeSource: string[],
    currentSource: string
}

const initialState: repositoryState = {
    typeSource:[
        "XML",
        "DB"
    ],
    currentSource: "DB"
}

const repositorySlice = createSlice({
    name: "repository",
    initialState,
    reducers: {
        changeCurrentTypeSource: (state, action: PayloadAction<string>) => {
            return {...state, currentSource: action.payload}
        }
    }
});

export default repositorySlice;
export const { changeCurrentTypeSource } = repositorySlice.actions;