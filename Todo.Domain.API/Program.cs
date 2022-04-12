using Microsoft.EntityFrameworkCore;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Contexts;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
//builder.Services.AddDbContext<DataContext>(opt => 
    //opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<TodoHandler, TodoHandler>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            );

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
