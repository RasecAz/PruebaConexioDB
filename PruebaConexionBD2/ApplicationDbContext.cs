using Microsoft.EntityFrameworkCore;
using PruebaConexionBD2.Entityes;

namespace PruebaConexionBD2
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Vehiculo> Vehiculos => Set<Vehiculo>();
    }
}
