using gluten_free_br.Business;
using gluten_free_br.Business.Implementation;
using gluten_free_br.Model.Context;
using gluten_free_br.Repository;
using gluten_free_br.Repository.Implementation;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// **MySQLConection**
var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(
    connection,
    new MySqlServerVersion(new Version(8, 3, 0)))
    );

//**Versioning API**
builder.Services.AddApiVersioning();

// **Dependency Injection**
builder.Services.AddScoped<IRecipeBusiness, RecipeBusinessImplementation>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepositoryImplementation>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
