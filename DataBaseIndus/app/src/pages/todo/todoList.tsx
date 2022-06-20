import DoneTodoList from "../../components/todo/doneTodo";
import UndoneTodoList from "../../components/todo/undoneTodo";


function TodoList() {
  return (
    <>
      <UndoneTodoList />
      <DoneTodoList />
    </>
  );
}

export default TodoList;
