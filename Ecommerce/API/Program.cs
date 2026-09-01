var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<Produto> produtos = new List<Produto>
{
    new Produto { Nome = "Notebook" },
    new Produto { Nome = "Mouse" },
    new Produto { Nome = "Teclado" },
    new Produto { Nome = "Monitor" },
    new Produto { Nome = "Headset" },
    new Produto { Nome = "Webcam" },
    new Produto { Nome = "Impressora" },
    new Produto { Nome = "Pen Drive" },
    new Produto { Nome = "HD Externo" },
    new Produto { Nome = "Celular" }
};

//FUNCIONALIDADES - EndPoint
//Requisições
// - Método HTTP
// - URL
//Resposta
// - Dado/Informação

app.MapGet("/", () => "API do Ecommerce");

app.MapGet("/api/produto/listar", () =>
{
    return produtos;
});

app.Run();