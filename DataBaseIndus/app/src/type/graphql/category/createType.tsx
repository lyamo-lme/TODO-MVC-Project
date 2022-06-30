import { TodoType } from "../todo/todoType"

export type CategoryType={
    idCategory: number,
    nameCategory: string,
    tasks: TodoType[] | null
}
