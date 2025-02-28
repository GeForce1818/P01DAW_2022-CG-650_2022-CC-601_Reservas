using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace P01_2022_CG_650_2022_CC_601.Models
{
    public class ParqueoContext : DbContext
    {

        public ParqueoContext(DbContextOptions<ParqueoContext> option) : base(option)
        {
        

        }

        public DbSet<espacio> espacio { get; set; }
        public DbSet<reserva> reserva { get; set; }
        public DbSet<sucursal> sucursal { get; set; }
        public DbSet<usuario> usuario { get; set; }

    }
}
