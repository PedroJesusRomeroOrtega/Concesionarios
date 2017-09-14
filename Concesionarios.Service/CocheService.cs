using Concesionarios.Core;
using Concesionarios.DAL.Repository;
using Concesionarios.DAL.Repository.Common;
using Concesionarios.Service.Common;
using System.Collections.Generic;

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

        public Coche GetById(int id)
        {
            return cocheRepository.GetById(id);
        }

        public IEnumerable<Coche> GetAll(int idConcesionario)
        {
            return cocheRepository.GetAll(idConcesionario);
        }
    }
}
