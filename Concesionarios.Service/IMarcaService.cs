using Concesionarios.Core;
using Concesionarios.Service.Common;

namespace Concesionarios.Service
{
    public interface IMarcaService : IEntityService<Marca>
    {
        Marca GetById(int id);
    }
}
