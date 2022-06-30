export const queryGetAllCategory = `
  query{
    categoriesQueries{
        getAllCategories{
        idCategory,
        nameCategory
       }
    }
  }
  `
  
export const queryDeleteCategory= `
mutation deleteCategory($id: Int!){
    categoryMutation{
    delete(deleteId: $id){
        idCategory
    }
  }
}
`

export const queryAddCategory= `
mutation addCategory ($categoryCreate: CreateCategoryType!){
    categoryMutation{
    create(newCategory: $categoryCreate){
     idCategory,
     nameCategory
    }
  }
}
`

export const queryUpdateCategory= `
mutation updateCategory($categoryUpdate: EditCategoryType!){
    categoryMutation{
    update(editCategory: $categoryUpdate){
      nameCategory,
      idCategory,
    }
  }
}
`

