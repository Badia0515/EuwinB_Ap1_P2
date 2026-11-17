using Aplicada1.Core;
using EuwinB_Ap1_P2.Model;
using EuwinB_Ap1_P2.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EuwinB_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EuwinB_Ap1_P2.Service
{
    public class VentaServices(IDbContextFactory<VentaDeCafeContext> contextFactory) : IServiceResult<Venta, int>
    {
        public async Task<Result<Venta?>> Buscar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.ventas.FirstOrDefaultAsync(E => E.VentaId == id);
        }
        public async Task<bool> Existe(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.ventas.AnyAsync(E => E.VentaId == id);
        }
        public async Task<Result> Eliminar(int id)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            var venta = await context.ventas.Include(V => V.ventaDetalles).FirstOrDefaultAsync(V => V.VentaId == id);
            if (venta == null)
            {
                return Result.Success(false);
            }
            await Afectar(venta.ventaDetalles.ToArray(), TipoDeOperacion.Suma);
            context.ventaDetalles.RemoveRange(venta.ventaDetalles);
            context.ventas.Remove(venta);
            var cantidad = await context.SaveChangesAsync();
            return Result.Success(cantidad > 0);
        }
        public async Task<Result<List<Venta>>> GetList(Expression<Func<Venta, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.ventas.Where(criterio).AsNoTracking().ToListAsync();
        }
        public async Task<bool> Insertar(Venta entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            await Afectar(entidad.ventaDetalles.ToArray(), TipoDeOperacion.Resta);
            context.ventas.Add(entidad);
            return await context.SaveChangesAsync() > 0;
        } 
        public async Task Afectar(VentaDetalle[] Detalle, TipoDeOperacion tipoDeOperacion)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            foreach (var detalle in Detalle)
            {
                var producto = await context.productos.FirstOrDefaultAsync(P => P.ProductoId == detalle.ProductoId);
                if (producto != null)
                {
                    if (tipoDeOperacion == TipoDeOperacion.Suma)
                    {
                        producto.Stock += detalle.Cantidad;
                    }
                    else
                    {
                        producto.Stock -= detalle.Cantidad;
                    }
                }
                await context.SaveChangesAsync();
            }
        }
        public async Task<bool> Editar(Venta entidad)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            context.ventas.Update(entidad);
            return await context.SaveChangesAsync() > 0;
        }
        public async Task<Result> Guardar(Venta entidad)
        {
            bool Guardando;
            if(!await Existe(entidad.VentaId))
            {
                Guardando = await Insertar(entidad);
            }
            else
            {
                Guardando = await Editar(entidad);
            }
            return Result.Success(Guardando);
        }
        public enum TipoDeOperacion
        {
            Suma,
            Resta
        }
    }
}
