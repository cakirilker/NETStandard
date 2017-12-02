using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Standard.Data
{
    public interface IRestService<T> where T : class
    {
        Task<List<T>> RefreshDataAsync();
        Task<T> GetItemByIdAsync(int id);
        Task CreateItemAsync(T item);
        Task UpdateItemAsync(int id, T item);
        Task DeleteItemAsync(int id);
    }
}
