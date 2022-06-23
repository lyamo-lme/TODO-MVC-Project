
import { Link, Navigate, Route, Routes } from "react-router-dom";
import { CategoryEdit } from "./pages/category/categoryEdit";
import { CategoryMainPage } from "./pages/category/categoryMainPage";
import { Layout } from "./pages/Layout/Layout";
import { TodoEdit } from "./pages/todo/todoEdit";
import TodoMainPage from "./pages/todo/todoMainPage";




function App() {
  return (
    <>

      <div className="App">
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route path='/todo' element={<TodoMainPage />} />
            <Route path='/category' element={<CategoryMainPage />} />
            <Route path='/edit/todo/:idTodo' element={<TodoEdit />} />
            <Route path='/edit/category/:id' element={<CategoryEdit />} />
            <Route path='/' element={<Navigate to='/todo'/>}/>
          </Route>
        </Routes>
      </div>
    </>
  );
}

export default App;
