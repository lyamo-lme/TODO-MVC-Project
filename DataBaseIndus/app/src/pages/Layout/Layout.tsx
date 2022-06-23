import { Link, NavLink, Outlet } from "react-router-dom";



export function Layout() {
    /* добавить виды репозиториев в стейт и здесь обьявить для запроса на измениня типа*/
    return (
        <>
            <header>
                <NavLink to='/todo'>Todo</NavLink>
                <NavLink to='/category'>Category</NavLink>
                <div className="changeReposBlock">
                <select >
                    <option value={"Xml"}>Xml</option>
                    <option value={"Sql"}>Sql</option>
                </select>
                <button >Change</button>
                </div>
            </header>
            <Outlet />
        </>
    );

}