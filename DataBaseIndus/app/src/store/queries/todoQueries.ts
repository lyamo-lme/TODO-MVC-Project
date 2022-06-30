export const queryGetAllTodo = `
  query{
    tasksQueries{
       getAllTodos{
        nameTodo,
        categoryId,
        taskCompleted,
        nameCategory,
        id,
        deadLine
       }
    }
  }
  `
  
export const queryDeleteTodo= `
mutation deleteTodo($id: Int!){
  taskMutation{
    delete(deleteId: $id){
     id
    }
  }
}
`

export const queryAddTodo= `
mutation addTodo ($todoCreate: CreateTodoType!){
  taskMutation{
    create(todo: $todoCreate){
      nameTodo,
      categoryId,
      taskCompleted,
      nameCategory,
      id,
      deadLine
    }
  }
}
`

export const queryUpdateTodo= `
mutation updateTodo ($todoUpdate: EditTodoType!){
  taskMutation{
    update(editTodo: $todoUpdate){
      nameTodo,
      categoryId,
      taskCompleted,
      nameCategory,
      id,
      deadLine
    }
  }
}
`

