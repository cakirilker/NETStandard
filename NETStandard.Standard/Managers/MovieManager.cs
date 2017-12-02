using NETStandard.Standard.Data;
using NETStandard.Standard.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Standard.Managers
{
    public class MovieManager : BaseManager<Movie>, IManager<Movie>
    {
        public MovieManager(IRestService<Movie> service) : base(service)
        {
        }

        public Task CreateAsync(Movie item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            return Service.DeleteItemAsync(id);
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await Service.RefreshDataAsync();
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await Service.GetItemByIdAsync(id);
        }

        public Task UpdateAsync(int id, Movie item)
        {
            throw new NotImplementedException();
        }
    }
}
