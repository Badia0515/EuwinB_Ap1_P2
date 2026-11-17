using Microsoft.EntityFrameworkCore;
using EuwinB_Ap1_P2.Model;
using EuwinB_Ap1_P2.Models;

namespace EuwinB_Ap1_P2.Context
{
    public class VentaDeCafeContext : DbContext
    {
        public VentaDeCafeContext(DbContextOptions<VentaDeCafeContext>options):base(options)
        {
        }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Venta> ventas { get; set; }
        public DbSet<VentaDetalle> ventaDetalles{ get; set; }

    }
}
