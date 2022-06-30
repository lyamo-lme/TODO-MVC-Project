export const graphqlRequest = async (query: string, variables?: unknown) => {
    const request = await fetch(
        "https://localhost:7084/graphql", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ query, variables })
    });
    
    return await request.json();
}