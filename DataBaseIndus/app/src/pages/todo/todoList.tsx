import { useState } from "react";
import { useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import DoneTodoList from "../../components/todo/doneTodo";
import UndoneTodoList from "../../components/todo/undoneTodo";
import { useAppDispatch } from "../../store/hooks";
import { fetchToDo, removeTodo, updateTodo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { center, itemTodo, itemTodoUndone } from "../../style/style";


function TodoList() {
  return (
    <>
      <div style={{margin: " 25px 45%"}}>TodoList</div>
      <UndoneTodoList />
      <br />
      <DoneTodoList />

    </>
  );
}

export default TodoList;
