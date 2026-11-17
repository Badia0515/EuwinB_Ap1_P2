using System.Linq.Expressions;
using Aplicada1.Core;
using EuwinB_Ap1_P2.Context;
using EuwinB_Ap1_P2.Models;
using Microsoft.EntityFrameworkCore;

namespace EuwinB_Ap1_P2.Services
{
    public class ProductoServices(IDbContextFactory<VentaDeCafeContext> contextFactory) : IServiceResult<Productos, int>
    {
        public Task<Result<Productos?>> Buscar(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Result> Eliminar(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<Result<List<Productos>>> GetList(Expression<Func<Productos, bool>> criterio)
        {
            await using var context = await contextFactory.CreateDbContextAsync();
            return await context.productos.Where(criterio).AsNoTracking().ToListAsync();
        }
        public Task<Result> Guardar(Productos entidad)
        {
            throw new NotImplementedException();
        }
    }
}
