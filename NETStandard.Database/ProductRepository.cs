using NETStandard.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Database
{
    public class ProductRepository : IRepository<Product>
    {
        public Task<bool> AddProductAsync(Product t)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindByAsync(Func<Product, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            try
            {
                var command = @"SELECT Id, Name, Price FROM Products;";
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Task<Product> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Product t)
        {
            throw new NotImplementedException();
        }
    }
}
