import { Link, NavLink, Outlet } from "react-router-dom";



export function Layout() {

    return (
        <>
        <header>
            <NavLink to='/todo'>Todo</NavLink>
            <NavLink to='/category'>Category</NavLink>
        </header>
        <Outlet />
        </>
        );
        
}