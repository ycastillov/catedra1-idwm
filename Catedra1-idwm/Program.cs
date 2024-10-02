using Catedra1_idwm.src.Data;
using Catedra1_idwm.src.Repositories;
using Catedra1_idwm.src.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext> (options => options.UseSqlite("Data Source=Practica1.db"));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.MapControllers();

using (var scope = app.Services.CreateScope()) // Se levanta la base de datos
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<DataContext>(); // Obtener servicio 
    await context.Database.MigrateAsync(); // Se realiza la migración de la base de datos de forma asincrona
    await Seeder.Seed(context);
}

app.Run();
