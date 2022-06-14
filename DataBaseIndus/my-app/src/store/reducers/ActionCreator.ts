import {
    ApolloClient,
    InMemoryCache,
    ApolloProvider,
    useQuery,
    gql
  } from "@apollo/client";
import { AppDispath } from "../store";
import ToDoSlice, { toDoSlice } from "./ToDoSlice";

export const fetchTodos=()=> async (dispath: AppDispath)=>{
try{
 dispath(toDoSlice.actions.fetchToDo())
 const client=new ApolloClient({
uri: '',
cache: new InMemoryCache()
 });
}
catch(e){

}
}
