import React from "react";
import { useState } from "react";
import { useSelector } from "react-redux";
import { useNavigate, useParams } from "react-router-dom";
import { useAppDispatch } from "../../store/hooks";
import { updateCategory } from "../../store/Slice/category/categorySlice";
import { fetchToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { CategoryType as CategoryType, emptyCategoryType as emptyCategory } from "../../type/category/CategoryType";


/*
 const navigate = useNavigate();
    const { idTodo } = useParams();
    let Todo = emptyTodo;
    let id = 0;

    if (idTodo != undefined) {
        id = parseInt(idTodo);
    }
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category);
    const findTodo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo.find(item => item.id == id))
    Todo = findTodo != undefined ? findTodo : emptyTodo;
    const [todo, setTodo] = useState<ToDoType>({ ...Todo, deadLine: stringToDate(Todo.deadLine) });
    const dispatch = useAppDispatch();

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        let nameCategory = categories.find((item) => item.idCategory == todo.categoryId)?.nameCategory;
        if (todo != undefined) {
            dispatch(updateTodo({
                ...todo, nameCategory: nameCategory != undefined ? nameCategory : "No Category",
                deadLine: dateToSting(deadLine)
            }))
        }
        navigate('/todo');
    }
*/
export function CategoryEdit() {
    const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo)
    const dispatch = useAppDispatch();
    const navigate = useNavigate();
    const { id } = useParams();
    let Category = emptyCategory;
    let idCategory: number;
    idCategory = id == undefined ? 0 : parseInt(id);
    const findCategory = useSelector((s: RootState) => s.rootReducer.categoryReducer.category.find(item => item.idCategory == idCategory))
    Category = findCategory != undefined ? findCategory : emptyCategory;
    const [category, setCategory] = useState<CategoryType>(Category)

    const onFinish = (e: React.FormEvent) => {
        e.preventDefault()
        dispatch(updateCategory(category))
        dispatch(fetchToDo(todo.map((item) => {
            if (item.categoryId == category.idCategory) {
                return { ...item, nameCategory: nameCategory };
            }
            return item;
        })))
        navigate('/category');
    }
    const { nameCategory } = category
    if (category != undefined) {
        return (
            <>  <form onSubmit={(e) => onFinish(e)}>
                <div>
                    <p>Name Category</p>
                    <input name='nameCategory' value={nameCategory} onChange={(e) => setCategory({ ...category, nameCategory: e.target.value })} required />
                </div>
                <div>
                    <button type="submit">Submit</button>
                </div>
            </form>

            </>
        );
    }
    return (<p>Error: Category with id:{id} not found</p>)
}