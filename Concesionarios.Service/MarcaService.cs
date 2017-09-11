using Concesionarios.Core;
using Concesionarios.DAL.Repository;
using Concesionarios.DAL.Repository.Common;
using Concesionarios.Service.Common;

namespace Concesionarios.Service
{
    public class MarcaService : EntityService<Marca>, IMarcaService
    {
        IUnitOfWork unitOfWork;
        IMarcaRepository marcaRepository;

        public MarcaService(IUnitOfWork unitOfWork, IMarcaRepository marcaRepository) : base(unitOfWork, marcaRepository)
        {
            this.unitOfWork = unitOfWork;
            this.marcaRepository = marcaRepository;
        }
    }
}
