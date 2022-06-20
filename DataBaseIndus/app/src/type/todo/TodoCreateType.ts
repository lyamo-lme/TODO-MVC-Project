export type ToDoCreateType={
    nameTodo: string,
    categoryId: number,
    deadLine: string,
    nameCategory: string
}
export const emptyCreateTodo:ToDoCreateType={
    nameTodo: "",
    categoryId: 0,
    nameCategory: "",
    deadLine: ""
}