using Catedra1_idwm.src.Models;  // Reemplaza con tu espacio de nombres
using Catedra1_idwm.src.Data;    // Reemplaza con tu espacio de nombres

namespace Catedra1_idwm.src.Data;

public static class Seeder
{
     public static async Task Seed(DataContext context)
    {
        // Verifica si la tabla de usuarios ya contiene datos
        if (context.Users.Any())
        {
            return; // Si ya hay usuarios, no se ejecuta el seeder
        }

        // Lista de usuarios iniciales para poblar la base de datos
        var users = new[]
        {
            new User { Rut = "12345678-9", Name = "Juan Pérez", Email = "juan.perez@example.com", Gender = "masculino", Birthdate = new DateTime(1990, 5, 1) },
            new User { Rut = "98765432-1", Name = "María López", Email = "maria.lopez@example.com", Gender = "femenino", Birthdate = new DateTime(1988, 8, 15) },
            new User { Rut = "11223344-5", Name = "Carlos García", Email = "carlos.garcia@example.com", Gender = "masculino", Birthdate = new DateTime(1995, 2, 20) },
            new User { Rut = "66778899-3", Name = "Ana Torres", Email = "ana.torres@example.com", Gender = "femenino", Birthdate = new DateTime(1992, 7, 30) },
            new User { Rut = "11224433-6", Name = "Luis Rojas", Email = "luis.rojas@example.com", Gender = "masculino", Birthdate = new DateTime(1993, 11, 5) },
            new User { Rut = "22113344-7", Name = "Laura Martínez", Email = "laura.martinez@example.com", Gender = "femenino", Birthdate = new DateTime(1991, 9, 17) },
            new User { Rut = "33445566-8", Name = "Pedro González", Email = "pedro.gonzalez@example.com", Gender = "masculino", Birthdate = new DateTime(1994, 4, 10) },
            new User { Rut = "99887766-4", Name = "Carolina Díaz", Email = "carolina.diaz@example.com", Gender = "femenino", Birthdate = new DateTime(1989, 6, 8) },
            new User { Rut = "55443322-9", Name = "Miguel Castro", Email = "miguel.castro@example.com", Gender = "masculino", Birthdate = new DateTime(1996, 3, 15) },
            new User { Rut = "44556677-1", Name = "Valentina Reyes", Email = "valentina.reyes@example.com", Gender = "femenino", Birthdate = new DateTime(1997, 1, 25) }
        };

        // Agrega los usuarios a la base de datos
        context.Users.AddRange(users);
        context.SaveChanges(); // Guarda los cambios en la base de datos
        
    }
}