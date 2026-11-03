using Aplicada1.Core;
using EuwinB_Ap1_P2.Model;
using EuwinB_Ap1_P2.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EuwinB_Ap1_P2.Service
{
    public class service(IDbContextFactory<context> contextFactory) : IServiceResult<model, int>
    {
        public Task<Result<model?>> Buscar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Result<List<model>>> GetList(Expression<Func<model, bool>> criterio)
        {
            throw new NotImplementedException();
        }

        public Task<Result> Guardar(model entidad)
        {
            throw new NotImplementedException();
        }
    }
}
