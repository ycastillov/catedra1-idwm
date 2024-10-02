using Catedra1_idwm.src.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext> (options => options.UseSqlite("Data Source=Practica1.db"));

var app = builder.Build();


app.Run();
