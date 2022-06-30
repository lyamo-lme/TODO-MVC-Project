
export type ToDoType={
    nameTodo: string,
    categoryId: number,
    taskCompleted: boolean,
    nameCategory: string|null,
    id: number,
    deadLine: string|null
}
export const emptyTodo:ToDoType={
    nameTodo: "",
    categoryId: 0,
    taskCompleted: false,
    nameCategory: "",
    id: 0,
    deadLine: ""
}