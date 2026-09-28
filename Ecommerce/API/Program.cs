var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<Produto> produtos = new List<Produto>();

//FUNCIONALIDADES - EndPoint
//Requisições
// - Método HTTP
// - URL
//Resposta
// - Dado/Informação
// - Código de status HTTP

//GET: http://localhost:5219
app.MapGet("/", () => "API do Ecommerce");

//GET: http://localhost:5219/api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    if (produtos.Count == 0)
    {
        return Results.NotFound("Não existem produtos cadastrados");
    }
    return Results.Ok(produtos);
});

//POST: http://localhost:5219/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto? produto) =>
{
    if(produto is null)
        return Results.BadRequest("Produto inválido");
    
    if (string.IsNullOrEmpty(produto.Nome))
        return Results.BadRequest("O nome do produto é obrigatório");
    
    if (produtos.FirstOrDefault(produtosCadastrados => produtosCadastrados.Nome == produto.Nome) != null)
        return Results.BadRequest("Esse produto já foi cadastrado");

    produtos.Add(produto);
    return Results.Created("", produto);
});

//GET: http://localhost:5219/api/produto/buscar
app.MapGet("/api/produto/buscar/{nome}", (string nome) => 
{ 
    
    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == nome)
        {
            return Results.Ok(produtoCadastrado);
        }
    }

    return Results.NotFound("Produto não encontrado");

});

app.MapDelete("/api/produto/deletar/{nome}", (string nome) =>
{

    Produto? produtoCadastrado = produtos.FirstOrDefault(produto => produto.Nome == nome);

    if (produtoCadastrado != null)
    {
        produtos.Remove(produtoCadastrado);
        return Results.Ok($"Produto deletado com sucesso!");
    }

    return Results.NotFound("Produto não encontrado");
});

app.MapPut("/api/produto/atualizar/{nome}", (string nome, Produto produtoAlterado) =>
{
    if(produtoAlterado is null)
        return Results.BadRequest("Produto inválido");

    if (string.IsNullOrEmpty(produtoAlterado.Nome))
        return Results.BadRequest("O nome do produto é obrigatório");
    
    if (produtos.FirstOrDefault(produtosCadastrados => produtosCadastrados.Nome == produtoAlterado.Nome) != null)
        return Results.BadRequest("Esse produto já foi cadastrado");

    foreach (Produto produtoCadastrado in produtos)
    {
        if (produtoCadastrado.Nome == nome)
        {
            produtoCadastrado.Nome = produtoAlterado.Nome;
            return Results.Ok($"Produto atualizado com sucesso!");
        }
    }

    return Results.NotFound("Produto não encontrado");

});

app.Run();