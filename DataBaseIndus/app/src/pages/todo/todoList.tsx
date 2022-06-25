import axios from "axios";
import { useEffect } from "react";
import DoneTodoList from "../../components/todo/doneTodo";
import UndoneTodoList from "../../components/todo/undoneTodo";
import { ToDoType } from "../../type/todo/TodoType";


function TodoList() {
  const query = `
  query{
    tasksQueries{
       getAllTodos{
        nameTodo
       }
    }
  }
  `
  useEffect(() => {


    const result = axios.post(
        "https://localhost:7084/graphql",
        {
          query:query
        }
      )
      .then(ressult=>{
        const data= ressult.data
        console.log(data)})

    

    
  })
  return (

    <>
      <UndoneTodoList />
      <DoneTodoList />
    </>
  );
}

export default TodoList;
