using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;
using System.Collections.Generic;

namespace Concesionarios.DAL.Repository
{
    public interface ICocheRepository : IGenericRepository<Coche>
    {
        Coche GetById(int id);
        IEnumerable<Coche> GetAll(int idConcesionario);
    }
}
