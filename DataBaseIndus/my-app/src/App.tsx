import React, { useState } from 'react';
import { useAppDispath, useAppSelector } from './hooks/redux';
import { RootState } from './store/store';
import { useQuery, gql } from '@apollo/client';
import { toDoSlice } from './store/reducers/ToDoSlice';
import { IToDoType } from './types/ToDoType';


function App() {
  const {todo} = useAppSelector(state=>  state.todoReducer);
  const actions = toDoSlice.actions;
  const dispath = useAppDispath(); 

  return (
    <div>
      {todo.map((item:IToDoType) => (

        <div>{item.nameCategory}</div>
      ))}
      </div>
  );
}

export default App;
