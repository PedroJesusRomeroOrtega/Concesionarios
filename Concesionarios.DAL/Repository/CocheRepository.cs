using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;
using System.Data.Entity;
using System.Linq;

namespace Concesionarios.DAL.Repository
{
    public class CocheRepository : GenericRepository<Coche>, ICocheRepository
    {
        public CocheRepository(DbContext dbContext) : base(dbContext) { }

        public Coche GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }
    }
}
