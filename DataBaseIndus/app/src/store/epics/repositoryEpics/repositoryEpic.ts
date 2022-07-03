import { combineEpics, ofType } from "redux-observable";
import { from, map, mergeMap } from "rxjs";
import { changeRepositoryType } from "../../actions/repositoryAction";
import { queryChangeRepository } from "../../queries/repositoryQueries";
import { graphqlRequest } from "../../requestFromApi/queryToApi";
import { changeCurrentTypeSource } from "../../Slice/repository/repositorySlice";



const changeRepositoryEpic = (action$: any) => {
    console.log('here')
    return action$.pipe(
        ofType(changeRepositoryType),
        mergeMap((action: any) => from(graphqlRequest(queryChangeRepository, {
            typeSource: action.payload
        })).pipe(
            map(response => {
                console.log(response)
                return changeCurrentTypeSource(response.data.repositoryMutation.changeRepositoryType);
            }
            ))));
}


export const repositoryEpics = combineEpics(changeRepositoryEpic);