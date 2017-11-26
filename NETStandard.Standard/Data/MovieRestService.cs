using NETStandard.Standard.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NETStandard.Standard.Data
{
    public class MovieRestService : IRestService<Movie>
    {
        HttpClient _client;

        public MovieRestService()
        {
            _client = new HttpClient();
            _client.MaxResponseContentBufferSize = 256000;
        }
        public Task CreateItemAsync(Movie item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteItemAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Movie GetItemByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Movie>> RefleshDataAsync()
        {
            IList<Movie> movies = null;
            // RestUrl = http://10.0.2.2:5000/api/movie
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                var response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    movies = JsonConvert.DeserializeObject<IList<Movie>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }
            return movies;
        }

        public Task UpdateItemAsync(Movie item)
        {
            throw new NotImplementedException();
        }
    }
}
