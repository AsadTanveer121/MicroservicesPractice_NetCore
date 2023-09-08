using Microsoft.EntityFrameworkCore;
using PRODUCT_MICROSERVICES.DBContexts;
using PRODUCT_MICROSERVICES.Repository;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductContext>(Options => Options.UseMySQL(builder.Configuration.GetConnectionString("ProductDB")) );
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddMvc();
builder.Services.AddControllers();


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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
