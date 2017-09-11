using Concesionarios.Core.Common;
using Concesionarios.DAL.Repository.Common;
using System;
using System.Collections.Generic;

namespace Concesionarios.Service.Common
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        IUnitOfWork _unitOfWork;
        IGenericRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Entidad");
            }
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Entidad");
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Entidad");
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

    }
}
