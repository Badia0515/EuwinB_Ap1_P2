using Microsoft.EntityFrameworkCore;
using EuwinB_Ap1_P2.Model;

namespace EuwinB_Ap1_P2.Context
{
    public class context : DbContext
    {
        public context(DbContextOptions<context>options):base(options)
        {
        }
        public DbSet<model> model { get; set; }
    }
}
