import { useState } from "react";
import { useSelector } from "react-redux";
import { Link, NavLink, Outlet, useNavigate } from "react-router-dom";
import { changeRepositoryAction } from "../../store/actions/repositoryAction";
import { useAppDispatch } from "../../store/hooks";
import { RootState } from "../../store/store";



export function Layout() {
    const navigate = useNavigate();
    const sources = useSelector((s: RootState) => s.rootReducer.repositoryReducer.typeSource)
    const dispatch = useAppDispatch();
    const [currentSource, setState]=useState(useSelector((s: RootState) => s.rootReducer.repositoryReducer.currentSource));
    const changeRepository=()=>{
          dispatch(changeRepositoryAction(currentSource));
          navigate('');
    }

    return (
        <>
            <header>
                <NavLink to='/todo'>Todo</NavLink>
                <NavLink to='/category'>Category</NavLink>
                <div className="changeReposBlock">
                    <select value={currentSource} onChange={(e)=>setState(e.target.value)}>
                        {
                            sources.map((item) =>
                                <option key={item} value={item}>{item}</option>)
                        }
                    </select>
                    <button onClick={()=>changeRepository()}>Change</button>
                </div>
            </header>
            <Outlet />
        </>
    );

}