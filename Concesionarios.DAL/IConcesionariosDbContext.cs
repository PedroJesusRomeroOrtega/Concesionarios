using Concesionarios.Core.Common;
using System.Data.Entity;

namespace Concesionarios.DAL
{
    public interface IConcesionariosDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}
