var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<Produto> produtos = new List<Produto>();

//FUNCIONALIDADES - EndPoint
//Requisições
// - Método HTTP
// - URL
//Resposta
// - Dado/Informação

//GET: http://localhost:5219
app.MapGet("/", () => "API do Ecommerce");

//GET: http://localhost:5219/api/produto/listar
app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

//POST: http://localhost:5219/api/produto/cadastrar
app.MapPost("/api/produto/cadastrar", (Produto produto) =>
{
    produtos.Add(produto);
    return Results.Created("", produto);
}
);

app.Run();