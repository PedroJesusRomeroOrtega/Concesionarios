using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;
using System.Data.Entity;
using System.Linq;

namespace Concesionarios.DAL.Repository
{
    public class ConcesionarioRepository : GenericRepository<Concesionario>, IConcesionarioRepository
    {
        public ConcesionarioRepository(DbContext context) : base(context) { }

        //public override IEnumerable<Concesionario> GetAll()
        //{
        //    return _dbset.Include(c => c.Coches).AsEnumerable();
        //}

        public Concesionario GetById(int id)
        {
            //return _dbset.Where(c => c.Id == id).Include(c => c.Coches).FirstOrDefault();
            return _dbset.Where(c => c.Id == id).FirstOrDefault();
        }
    }
}
