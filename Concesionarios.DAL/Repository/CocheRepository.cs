using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Concesionarios.DAL.Repository
{
    public class CocheRepository : GenericRepository<Coche>, ICocheRepository
    {
        public CocheRepository(DbContext dbContext) : base(dbContext) { }

        public IEnumerable<Coche> GetAll(int idConcesionario)
        {
            return FindBy(c => c.Concesionario.Id == idConcesionario);
        }

        public Coche GetById(int id)
        {
            return FindBy(c => c.Id == id).FirstOrDefault();
        }

        //public override IEnumerable<Coche> FindBy(Expression<Func<Coche, bool>> predicate)
        //{
        //    //IEnumerable<Coche> query = _dbset.Include(c => c.Concesionario).Where(predicate).AsEnumerable();
        //    IEnumerable<Coche> query = _dbset.Where(predicate).AsEnumerable();
        //    return query;
        //}

    }
}
