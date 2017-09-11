using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;

namespace Concesionarios.DAL.Repository
{
    public interface ICocheRepository : IGenericRepository<Coche>
    {
        Coche GetById(int id);
    }
}
