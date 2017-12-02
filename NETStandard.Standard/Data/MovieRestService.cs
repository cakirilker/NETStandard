using NETStandard.Standard.Extensions;
using NETStandard.Standard.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace NETStandard.Standard.Data
{
    public class MovieRestService : IRestService<Movie>
    {
        // RestUrl = http://10.0.2.2:5000/api/movie

        HttpClient _client;

        public MovieRestService()
        {
            _client = new HttpClient
            {
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task CreateItemAsync(Movie item)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            HttpResponseMessage response = new HttpResponseMessage();

            try
            {
                response = await _client.PostAsJsonAsync(uri, item);
                response.EnsureSuccessStatusCode();
                Debug.Write($"RESULT {response.StatusCode}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
                response.Dispose();
            }
            finally
            {
                response.Dispose();
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            var uri = new Uri($"{Constants.RestUrl}/{id}");
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _client.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.Write($"ERROR {ex.Message}");
            }
        }

        public async Task<Movie> GetItemByIdAsync(int id)
        {
            Movie movie = null;
            var uri = new Uri(string.Format(Constants.RestUrl, id));
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }
            finally
            {
                response.Dispose();
            }
            return movie;
        }

        public async Task<List<Movie>> RefreshDataAsync()
        {
            List<Movie> movies = null;
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
            }
            finally
            {
                response.Dispose();
            }
            return movies;
        }

        public async Task UpdateItemAsync(int id, Movie item)
        {
            var uri = new Uri($"{Constants.RestUrl}/{id}");
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                response = await _client.PutAsJsonAsync(uri, item);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ERROR {ex.Message}");
                response.Dispose();
            }
            finally
            {
                response.Dispose();
            }
        }
    }
}
