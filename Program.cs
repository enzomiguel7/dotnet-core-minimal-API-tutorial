using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//configuração do banco de dados em memória;
builder.Services.AddDbContext<TodoDb>(opt => opt.UseInMemoryDatabase("TodoList"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//constroi a aplicação com as configurações acima 
var app = builder.Build();

app.MapGet("/todoitems", async (TodoDb db) => 
    await db.Todos.ToListAsync());

app.MapGet("/todoitems/complete", async (TodoDb db) =>
    await db.Todos.Where(t => t.IsComplete).ToListAsync());

app.MapGet("/todoitems{id}", async (int id, TodoDb db) => 
    await db.Todos.FindAsync(id)
         is Todo todo
             ? Results.Ok(todo)
             : Results.NotFound());