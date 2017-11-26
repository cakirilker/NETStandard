using NETStandard.Standard.Data;
using NETStandard.Standard.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Standard.Managers
{
    public class MovieManager
    {
        MovieRestService movieRestService;

        public MovieManager(MovieRestService service)
        {
            movieRestService = service;
        }

        public Task<IList<Movie>> GetMoviesAsync()
        {
            return movieRestService.RefleshDataAsync();
        }
    }
}
