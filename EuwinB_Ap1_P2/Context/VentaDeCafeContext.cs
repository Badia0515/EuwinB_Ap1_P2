using Microsoft.EntityFrameworkCore;
using EuwinB_Ap1_P2.Models;

namespace EuwinB_Ap1_P2.Context
{
    public class VentaDeCafeContext : DbContext
    {
        public VentaDeCafeContext(DbContextOptions<VentaDeCafeContext> options) : base(options)
        {
        }
        public DbSet<Productos> productos { get; set; }
        public DbSet<Venta> ventas { get; set; }
        public DbSet<VentaDetalle> ventaDetalles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>().HasData(
                new Productos
                {
                    ProductoId = 1,
                    Nombre = "Starbucks Frappuccino Vainilla",
                    Concepto = "Cafe Botella sabor vainilla",
                    Precio = 225,
                    Stock = 10,
                    Activo = true
                },
                new Productos
                {
                    ProductoId = 2,
                    Nombre = "Starbucks Frappuccino Mocha",
                    Concepto = "Cafe Botella sabor chocolate",
                    Precio = 190,
                    Stock = 10,
                    Activo = true
                },
                new Productos
                {
                    ProductoId = 3,
                    Nombre = "Starbucks Frappuccino Caramel",
                    Concepto = "Cafe embotellado sabor caramelo",
                    Precio = 200,
                    Stock = 10,
                    Activo = true
                },
                new Productos
                {
                    ProductoId = 4,
                    Nombre = "Starbucks Doubleshot",
                    Concepto = "Cafe espresso con leche",
                    Precio = 175,
                    Stock = 10,
                    Activo = true
                },
                new Productos
                {
                    ProductoId = 5,
                    Nombre = "Starbucks Cold Brew",
                    Concepto = "Cafe frio preparado en frio",
                    Precio = 210,
                    Stock = 10,
                    Activo = true
                }
            );
        }
    }
}

