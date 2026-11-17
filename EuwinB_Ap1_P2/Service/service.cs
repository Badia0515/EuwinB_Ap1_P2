using Aplicada1.Core;
using EuwinB_Ap1_P2.Model;
using EuwinB_Ap1_P2.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuwinB_Ap1_P2.Service
{
    public class service(IDbContextFactory<VentaDeCafeContext> contextFactory) : IServiceResult<Productos, int>
    {
        public Task<Result<Productos?>> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<Productos>>> GetList(Expression<Func<Productos, bool>> criterio)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Guardar(Productos entidad)
        {
            throw new NotImplementedException();
        }
    }
}
