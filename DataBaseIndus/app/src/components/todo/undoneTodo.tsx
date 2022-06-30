import { useState } from "react";
import { useSelector } from "react-redux";
import { NavLink } from "react-router-dom";
import { dateToSting } from "../../parseDate/parseDate";
import { deleteTodoAction, updateTodoAction } from "../../store/actions/todo/todoActions";
import { useAppDispatch } from "../../store/hooks";
import { RootState } from "../../store/store";


function UndoneTodoList() {
  const todo = useSelector((s: RootState) => s.rootReducer.todoReducer.todo).filter((item) => !item.taskCompleted)
  const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
  const dispatch = useAppDispatch();
  const [idCategory, setCategory] = useState(0);
  const stringEdit = "/edit/todo/";
  const deleteTodo = (id: number) => {
    var answer = window.confirm("Are you sure?");
    if (answer) {
      dispatch(deleteTodoAction(id));
    }
  }

  if (todo.length == 0) {
    return (<div className="block"><i>Non UnDone Todo</i></div>)
  }
  return (<>
    <div className="block">
      <select value={idCategory} onChange={(e) => setCategory(parseInt(e.target.value))}>
        <option value={0}>None</option>
        {categories.map((item) =>
          <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
        )}
      </select>
      <table >
        <caption>Current Todos</caption>
        <tbody>
          <tr>
            <th>Name Todo</th>
            <th>Dead Line</th>
            <th>Category</th>
            <th colSpan={3}>Actions</th>
          </tr>
          {todo.map((item) => {
            if (!item.taskCompleted && (!(idCategory != 0) || item.categoryId == idCategory))
              return (
                <tr key={item.id} >
                  <td >{item.nameTodo} </td>
                  <td>{item.deadLine == null ? "None" : dateToSting(item.deadLine)}</td>
                  <td>{item.nameCategory}</td>
                  <td><img onClick={() => dispatch(updateTodoAction({
                    nameTodo: item.nameTodo,
                    id: item.id,
                    categoryId: item.categoryId,
                    deadLine: item.deadLine,
                    taskCompleted: !item.taskCompleted
                  }))} src={require('../../icons/done.png')} /></td>
                  <td><NavLink to={stringEdit + item.id} ><img src={require('../../icons/edit.png')} /></NavLink></td>
                  <td><img src={require('../../icons/delete.png')} onClick={() => deleteTodo(item.id)} /></td>
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
