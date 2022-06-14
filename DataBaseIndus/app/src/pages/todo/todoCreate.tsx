import { useState } from "react";
import { useSelector } from "react-redux";
import { useAppDispatch } from "../../store/hooks";
import todoSlice, { addToDo } from "../../store/Slice/todo/todoSlice";
import { RootState } from "../../store/store";
import { IToDoCreateType } from "../../type/todo/TodoCreateType";
import { onChange } from "../onChange/ChangeProperyInput";
import {form} from "../../style/style";

function TodoCreate() {
    const categories = useSelector((s: RootState) => s.rootReducer.categoryReducer.category)
    const todos = useSelector((s: RootState) => s.rootReducer.todoReducer.todo)
    const dispatch= useAppDispatch();
    const [todo, setTodo] = useState<IToDoCreateType>({
        nameTodo: '',
        categoryId: 0,
        deadLine: ''
    })
    const onFinish = (e:React.FormEvent) => {
      e.preventDefault();
      let nameCategory = (id:number)=>{
          let name= categories.find((item)=>item.idCategory==id)?.nameCategory;
          if(name!=undefined){
              return name;
          }
          return '';
        };
        console.log(nameCategory(todo.categoryId));
       let idTodo = ()=>{
            if(todos.length===0){
                return 1;
            }
            return todos[todos.length-1].id+1;
          };
        console.log(todo);
      dispatch(addToDo({
          nameTodo: todo.nameTodo,
          id: idTodo(),
          categoryId: todo.categoryId,
          nameCategory:  nameCategory(todo.categoryId),
          deadLine: todo.deadLine,
          taskCompleted: false
      }));
         
    }
    
    const { nameTodo, deadLine, categoryId } = todo
 
  
    return (
        <>
            <form style={form} onSubmit={(e) => onFinish(e)}>
                    <div>
                    <label>Name Todo</label>
                  <input name='nameTodo' value={nameTodo} onChange={(e)=>onChange((e),setTodo)} required />
                </div>
                    <div>
                        <label> Dead Line</label>
                        <input name="deadLine" type="datetime-local" value={deadLine} onChange={(e)=>onChange((e),setTodo)} />
                    </div>
                    <div>
                        <label>Category</label>
                        <select name="categoryId" value={categoryId}  onChange={(e)=>onChange((e),setTodo)}>
                            {categories.map((item) =>
                                <option key={item.idCategory} value={item.idCategory} >{item.nameCategory}</option>
                            )}
                             </select>
                   
                    </div>
                    <div>
                         <button type="submit">Submit</button>
                    </div>
       

            </form>
        </>
    );
}

export default TodoCreate;