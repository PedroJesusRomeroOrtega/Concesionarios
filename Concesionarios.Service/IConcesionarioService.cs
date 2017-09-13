using Concesionarios.Core;
using Concesionarios.Service.Common;

namespace Concesionarios.Service
{
    public interface IConcesionarioService : IEntityService<Concesionario>
    {
        Concesionario GetById(int id);
    }
}
