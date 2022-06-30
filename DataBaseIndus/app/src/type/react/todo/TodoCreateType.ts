export type ToDoCreateType={
    nameTodo: string,
    categoryId: number,
    deadLine: string|null,
    taskCompleted: boolean
}

export const emptyCreateTodo:ToDoCreateType={
    nameTodo: "",
    categoryId: 0,
    deadLine: "",
    taskCompleted: false
}