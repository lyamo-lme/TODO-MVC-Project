
import { combineEpics, ofType } from "redux-observable";
import {  from, map, mergeMap } from "rxjs";
import { addCategoryActionType, deleteCategoryActionType, fetchCategoryActionType, fetchCategoryAction ,updateCategoryActionType as updateCategoryType } from "../../actions/category/categoryActions";
import { queryAddCategory, queryDeleteCategory, queryGetAllCategory, queryUpdateCategory } from "../../queries/categoryQueries";
import { graphqlRequest } from "../../requestFromApi/queryToApi";
import { addCategory,  removeCategory, setCategory, updateCategory } from "../../Slice/category/categorySlice";



const fetchCategoryEpic = (action$: any) =>
  action$.pipe(
        ofType(fetchCategoryAction),
        mergeMap(() => from(graphqlRequest(queryGetAllCategory)).pipe(
          map(response => {
            console.log(response)
            return setCategory(response.data.categoriesQueries.getAllCategories)
          }))));

  

const deleteCategoryEpic = (action$: any) =>
  action$.pipe(
    ofType(deleteCategoryActionType),
    mergeMap((action: any) => from(graphqlRequest(queryDeleteCategory, {
      id: action.payload
    }))
      .pipe(
        map(response => {
          console.log(response);
          return removeCategory(response.data.categoryMutation.delete.idCategory);
        }))))

const updateCategoryEpic = (action$: any) =>
  action$.pipe(
    ofType(updateCategoryType),
    mergeMap((action: any) => from(graphqlRequest(queryUpdateCategory, {
        categoryUpdate: action.payload
    }))
      .pipe(
        map(response => {
          console.log(response);
          return updateCategory(response.data.categoryMutation.update)
        }))))

const addCategoryEpic = (action$: any) =>
  action$.pipe(
    ofType(addCategoryActionType),
    mergeMap((action: any) => from(graphqlRequest(queryAddCategory, {
        categoryCreate: action.payload
    }))
      .pipe(
        map(response => {
          console.log(response);
          return addCategory(response.data.categoryMutation.create);
        }))))

export const categoryEpic = combineEpics(addCategoryEpic,fetchCategoryEpic,deleteCategoryEpic,updateCategoryEpic);