using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;

namespace Concesionarios.DAL.Repository
{
    public interface IMarcaRepository : IGenericRepository<Marca>
    {
        Marca GetById(int id);
    }
}
