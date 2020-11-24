using ApiNetCore.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiNetCore.Domain.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> InsertAsync(T item);
        Task<T> UpdateAsync(T item);
        Task<bool> DeleteAsync(Guid id);
        Task<T> SelectAsync(Guid id);
        Task<IEnumerable<T>> SelectAsync();
    }
}
