using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaultGuardAPI.Domain.Entities.Base;

namespace VaultGuardAPI.Application.Interface.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        bool Insert(T obj);
        bool Update(T obj);
        bool Delete(Guid id);
        IQueryable<T> SelectAll();
        T? Select(Guid id);
    }
}
