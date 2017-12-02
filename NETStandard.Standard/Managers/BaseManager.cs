using NETStandard.Standard.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace NETStandard.Standard.Managers
{
    public abstract class BaseManager<T> where T : class
    {
        public IRestService<T> Service { get; set; }
        public BaseManager(IRestService<T> service)
        {
            Service = service;
        }
    }
}
