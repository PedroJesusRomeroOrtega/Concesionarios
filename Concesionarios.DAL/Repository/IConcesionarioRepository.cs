using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;

namespace Concesionarios.DAL.Repository
{
    public interface IConcesionarioRepository : IGenericRepository<Concesionario>
    {
        Concesionario GetById(int id);
    }
}
