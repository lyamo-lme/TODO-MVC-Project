import { ToDoType } from "../../react/todo/TodoType"

export type CategoryType={
    idCategory: number,
    nameCategory: string,
    tasks: ToDoType[] | null
}
