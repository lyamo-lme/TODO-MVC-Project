import { combineReducers, configureStore } from "@reduxjs/toolkit";
import categorySlice from "./Slice/category/categorySlice";
import todoSlice from "./Slice/todo/todoSlice";

const rootReducer=combineReducers({
todoReducer: todoSlice.reducer,
categoryReducer: categorySlice.reducer
})

const store = configureStore({
reducer: {
rootReducer
}
});
 
 export type RootState =ReturnType<typeof store.getState>;
 export type AppDispatch = typeof store.dispatch;
 export default store;