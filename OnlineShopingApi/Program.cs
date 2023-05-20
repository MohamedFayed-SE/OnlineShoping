using BAL;
using BLL.Interfaces;
using BLL.Repositories;
using Microsoft.EntityFrameworkCore;
using OnlineShopingApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
string ConnectionString = builder.Configuration.GetConnectionString("default");

// to use UseSqlServer Should Intall Microsoft.tools
builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseSqlServer(ConnectionString));

builder.Services.AddScoped<IUniteOfWork, UniteOfWork>();
builder.Services.AddScoped<ExceptionMiddleware>();
// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
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
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
