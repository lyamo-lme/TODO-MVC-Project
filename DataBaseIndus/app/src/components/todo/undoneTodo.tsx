import { useState } from "react";
import { useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import { useAppDispatch } from "../../store/hooks";
import { fetchToDo, removeTodo, updateTodo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { center, itemTodo, itemTodoUndone } from "../../style/style";


function UndoneTodoList() {

  const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo).filter((item)=>!item.taskCompleted)
  const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
  const dispatch = useAppDispatch()
  const deleteTodo = (id: number) => {
    dispatch(removeTodo(id));
  }
  const [category, setCategory] = useState({
    idCategory: -1,
  });
  const stringEdit = "/edit/todo/"
  if (todo.length == 0) {
    return (<h1 style={center}>Non Undone Todo</h1>)
  }
  return (<>

    <select value={category.idCategory} onChange={(e) => setCategory({ ...category, idCategory: parseInt(e.target.value) })}>
      <option value={-1}>None</option>
      {categories.map((item) =>
        <option value={item.idCategory} >{item.nameCategory}</option>
      )}
    </select>
    <table style={{marginLeft: "10%"}}>
      <caption>Current Todo</caption>
      <br/>
      <tr>
        <th>Name Todo</th>
        <th>Dead Line</th>
        <th>Category</th>
        <th></th>
        <th></th>
        <th></th>
      </tr>
      {todo.map((item) => {
        if (!item.taskCompleted && (!(category.idCategory != -1) || item.categoryId == category.idCategory))
          return (
          <tr style={itemTodo}>
            <td >{item.nameTodo} </td>
            <td>{item.deadLine}</td>
            <td>{item.nameCategory}</td>
            <td ><img style={{width: "60px"}} onClick={()=>dispatch(updateTodo({...item, taskCompleted: !item.taskCompleted}))} src={require('../../icons/accept.png')}/></td>
            <td><NavLink to={stringEdit + item.id} >Edit</NavLink></td>
            <td><img src={require('../../icons/delete.png')} onClick={() => deleteTodo(item.id)}/></td>
          </tr>);
      }
      )}
    </table>

  </>
  );
}

export default UndoneTodoList;
