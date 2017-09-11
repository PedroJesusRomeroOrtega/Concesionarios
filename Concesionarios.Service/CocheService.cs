using Concesionarios.Core;
using Concesionarios.DAL.Repository;
using Concesionarios.DAL.Repository.Common;
using Concesionarios.Service.Common;

namespace Concesionarios.Service
{
    public class CocheService : EntityService<Coche>, ICocheService
    {
        IUnitOfWork unitOfWork;
        ICocheRepository cocheRepository;

        public CocheService(IUnitOfWork unitOfWork, ICocheRepository cocheRepository) : base(unitOfWork, cocheRepository)
        {
            this.unitOfWork = unitOfWork;
            this.cocheRepository = cocheRepository;
        }
    }
}
