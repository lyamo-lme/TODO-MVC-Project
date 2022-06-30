export type ToDoUpdateType={
    nameTodo: string,
    categoryId: number,
    taskCompleted: boolean,
    id: number,
    deadLine: string|null
}
export const emptyUpdateTodo:ToDoUpdateType={
    nameTodo: "",
    categoryId: 0,
    taskCompleted: false,
    id: 0,
    deadLine: "",
}