using NETStandard.Standard.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Standard.Managers
{
    public interface IManager<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T item);
        Task UpdateAsync(int id, T item);
        Task DeleteAsync(int id);
    }
}
