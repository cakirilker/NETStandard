using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Standard.Data
{
    public interface IRestService<T> where T : class
    {
        Task<IList<T>> RefleshDataAsync();
        T GetItemByIdAsync(int id);
        Task CreateItemAsync(T item);
        Task UpdateItemAsync(T item);
        Task DeleteItemAsync(int id);
    }
}
