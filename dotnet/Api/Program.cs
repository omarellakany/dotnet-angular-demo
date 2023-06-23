using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Services.Hubs;
using Services.Repos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IStockRepo, StockRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddDbContext<DbContext, EgidContext>();

builder.Services.AddSignalR();
builder.Services.AddCors(o => o.AddPolicy("EgidPolicy", builder =>
{
    builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials()
    .WithOrigins("http://localhost:4200")
    .Build();

}));

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("EgidPolicy");
app.MapControllers();
app.MapHub<StocksHub>("/subscribe");

app.Run();


