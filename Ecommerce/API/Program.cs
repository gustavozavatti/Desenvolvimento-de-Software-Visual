using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>();
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
app.MapGet("/api/produto/listar", ([FromServices] AppDataContext ctx) =>
{
    if (ctx.Produtos.Count() == 0)
    {
        return Results.NotFound("Não existem produtos cadastrados");
    }
    return Results.Ok(ctx.Produtos.ToList());
});

//POST: http://localhost:5219/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", ([FromBody] Produto? produto, [FromServices] AppDataContext ctx) =>
{
    if(produto is null)
        return Results.BadRequest("Produto inválido");
    
    if (string.IsNullOrEmpty(produto.Nome))
        return Results.BadRequest("O nome do produto é obrigatório");
    
    if (produtos.FirstOrDefault(produtosCadastrados => produtosCadastrados.Nome == produto.Nome) != null)
        return Results.BadRequest("Esse produto já foi cadastrado");

    ctx.Produtos.Add(produto);
    ctx.SaveChanges();
    return Results.Created("", produto);
});

//GET: http://localhost:5219/api/produto/buscar/nome_produto
app.MapGet("/api/produto/buscar/{nome}", ([FromRoute] string nome, [FromServices] AppDataContext ctx) => 
{ 
    Produto? produtoEncontrado = ctx.Produtos.FirstOrDefault(p => p.Nome == nome);

    if (produtoEncontrado != null)
    {
        return Results.Ok(produtoEncontrado);
    }

    return Results.NotFound("Produto não encontrado");
});

//DELETE: http://localhost:5219/api/produto/deletar/id_produto
app.MapDelete("/api/produto/deletar/{id}", (string id, [FromServices] AppDataContext ctx) =>
{
    Produto? produtoDeletar = ctx.Produtos.FirstOrDefault(produto => produto.Id == id);

    if (produtoDeletar != null)
    {
        ctx.Produtos.Remove(produtoDeletar);
        ctx.SaveChanges();
        return Results.Ok("Produto deletado com sucesso!");
    }

    return Results.NotFound("Produto não encontrado");
});

//PUT: http://localhost:5219/api/produto/atualizar
app.MapPut("/api/produto/atualizar/{id}", ([FromRoute] string id, [FromBody] Produto produtoAlterado) =>
{
    if(produtoAlterado is null)
        return Results.BadRequest("Produto inválido");

    if (string.IsNullOrEmpty(produtoAlterado.Nome))
        return Results.BadRequest("O nome do produto é obrigatório");
    
    if (produtos.FirstOrDefault(produtosCadastrados => produtosCadastrados.Nome == produtoAlterado.Nome) != null)
        return Results.BadRequest("Esse produto já foi cadastrado");

    Produto? produtoEncontrado = produtos.FirstOrDefault(p => p.Id == id);  

    if (produtoEncontrado != null)
    {
        produtoEncontrado.Nome = produtoAlterado.Nome;
        return Results.Ok("Produto atualizado com sucesso!");
    }

    return Results.NotFound("Produto não encontrado");
});

app.Run();