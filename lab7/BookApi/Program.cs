using DataSeeder;
using BookApi.Services.BookService;
using WeatherApp.API.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsePolicy", builder =>
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyCorsePolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
