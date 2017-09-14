using Concesionarios.Core;
using Concesionarios.Service.Common;
using System.Collections.Generic;

namespace Concesionarios.Service
{
    public interface ICocheService : IEntityService<Coche>
    {
        Coche GetById(int id);
        IEnumerable<Coche> GetAll(int idConcesionario);
    }
}
