export const queryChangeRepository = `
mutation changeCategory($typeSource: String!){
    repositoryMutation{
        changeRepositoryType(typeSource: $typeSource)
  }
}
`
