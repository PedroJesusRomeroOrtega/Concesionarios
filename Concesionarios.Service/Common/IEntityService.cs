using Concesionarios.Core.Common;
using System.Collections.Generic;

namespace Concesionarios.Service.Common
{
    public interface IEntityService<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
