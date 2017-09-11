using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;
using System.Data.Entity;
using System.Linq;

namespace Concesionarios.DAL.Repository
{
    public class ConcesionarioRepository : GenericRepository<Concesionario>, IConcesionarioRepository
    {
        public ConcesionarioRepository(DbContext context) : base(context) { }

        public Concesionario GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
