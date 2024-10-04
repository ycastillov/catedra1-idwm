using Catedra1_idwm.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Catedra1_idwm.src.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }
    }
}