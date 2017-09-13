using Concesionarios.Core;
using Concesionarios.DAL.Repository;
using Concesionarios.DAL.Repository.Common;
using Concesionarios.Service.Common;

namespace Concesionarios.Service
{
    public class ConcesionarioService : EntityService<Concesionario>, IConcesionarioService
    {
        IUnitOfWork unitOfWork;
        IConcesionarioRepository concesionarioRepository;

        public ConcesionarioService(IUnitOfWork unitOfWork, IConcesionarioRepository concesionarioRepository) : base(unitOfWork, concesionarioRepository)
        {
            this.unitOfWork = unitOfWork;
            this.concesionarioRepository = concesionarioRepository;
        }

        public Concesionario GetById(int id)
        {
            return concesionarioRepository.GetById(id);
        }
    }
}
