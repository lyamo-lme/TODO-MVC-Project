import { Action, applyMiddleware, combineReducers, configureStore, getDefaultMiddleware, Observable } from "@reduxjs/toolkit";
import axios from "axios";
import { combineEpics, createEpicMiddleware, ofType } from "redux-observable";
import { filter, from, map } from "rxjs";
import { categoryEpic } from "./epics/categoryEpics/categoryEpic";
import { repositoryEpics } from "./epics/repositoryEpics/repositoryEpic";
import { todoEpic } from "./epics/todoEpics/todoEpic";
import categorySlice from "./Slice/category/categorySlice";
import repositorySlice from "./Slice/repository/repositorySlice";
import todoSlice from "./Slice/todo/todoSlice";


const epicMiddleware = createEpicMiddleware();

const rootEpic = combineEpics(todoEpic,categoryEpic,repositoryEpics);

const rootReducer = combineReducers({
    todoReducer: todoSlice.reducer,
    categoryReducer: categorySlice.reducer,
    repositoryReducer: repositorySlice.reducer
})

const store = configureStore({
    reducer: {
        rootReducer
    },
    middleware: [epicMiddleware]
});

epicMiddleware.run(rootEpic);



export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
export default store;