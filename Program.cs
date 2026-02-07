var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "I Like trip hop and downtempo!");

app.Run();