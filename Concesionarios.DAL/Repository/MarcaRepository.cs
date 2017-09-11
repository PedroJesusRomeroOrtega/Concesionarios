using Concesionarios.Core;
using Concesionarios.DAL.Repository.Common;
using System.Data.Entity;
using System.Linq;

namespace Concesionarios.DAL.Repository
{
    public class MarcaRepository : GenericRepository<Marca>, IMarcaRepository
    {
        public MarcaRepository(DbContext dbContext) : base(dbContext) { }

        public Marca GetById(int id)
        {
            return FindBy(m => m.Id == id).FirstOrDefault();
        }
    }
}
