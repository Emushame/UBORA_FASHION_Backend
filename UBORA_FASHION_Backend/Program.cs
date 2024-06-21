using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UBORA_FASHION_Backend.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add and define UboraFashionDbContext
builder.Services.AddDbContext<UboraFashionDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("UF.Connection")));

var app = builder.Build();

//Add API for adding a new Product in the DB
app.MapPost("/AddProduct", async (Product product, UboraFashionDbContext db) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();

    return Results.Created($"/Add/{product.ProductId}", product);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
