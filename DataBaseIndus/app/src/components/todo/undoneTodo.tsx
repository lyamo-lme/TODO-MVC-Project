import { useState } from "react";
import { useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import { useAppDispatch } from "../../store/hooks";
import { removeTodo, updateTodo } from "../../store/Slice/todo/todoSlice";
import {block} from "../../style/style"
import { RootState } from "../../store/store";
import { center, itemTodo, itemTodoUndone } from "../../style/style";


function UndoneTodoList() {

  const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo).filter((item)=>!item.taskCompleted)
  const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
  const dispatch = useAppDispatch()
  const deleteTodo = (id: number) => {
    dispatch(removeTodo(id));
  }
  const [idCategory, setCategory] = useState(0);
  const stringEdit = "/edit/todo/"
  if (todo.length == 0) {
    return (<h1 style={center}>Non Undone Todo</h1>)
  }
  return (<>
     <div style={block}>
    <select value={idCategory} onChange={(e) => setCategory(parseInt(e.target.value))}>
      <option value={0}>None</option>
      {categories.map((item) =>
        <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
      )}
    </select>
    <table >
      <caption>Current Todo</caption>
      <tbody>
      <tr>
        <th>Name Todo</th>
        <th>Dead Line</th>
        <th>Category</th>
        <th></th>
        <th></th>
        <th></th>
      </tr>
      {todo.map((item) => {
        if (!item.taskCompleted && (!(idCategory != 0) || item.categoryId == idCategory))
          return (
          <tr key={item.id} style={itemTodo}>
            <td >{item.nameTodo} </td>
            <td>{item.deadLine}</td>
            <td>{item.nameCategory}</td>
            <td><img  onClick={()=>dispatch(updateTodo({...item, taskCompleted: !item.taskCompleted}))} src={require('../../icons/done.png')}/></td>
            <td><NavLink to={stringEdit + item.id} ><img src={require('../../icons/edit.png')}/></NavLink></td>
            <td><img src={require('../../icons/delete.png')} onClick={() => deleteTodo(item.id)}/></td>
          </tr>);
      }
      )}
      </tbody>
    </table>
    </div>
  </>
  );
}

export default UndoneTodoList;
