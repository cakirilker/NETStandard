﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Shared
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddProductAsync(T t);
        Task<bool> UpdateAsync(T t);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> FindByAsync(Func<T, bool> predicate);
    }
}