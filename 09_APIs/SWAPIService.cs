using _09_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _09_APIs
{
    public class SWAPIService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Person> GetPersonByIdAsync(int id)
        {
            // Send our request to the person endpoint, but take in any id
            HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.dev/api/people/{id}");

            // Wait here to see the response code, if 200 Ok, send that back
            if (response.IsSuccessStatusCode)
            {
                // Intrepret the JSON as a Person object, send that on back
                Person person = await response.Content.ReadAsAsync<Person>();
                return person;
            }

            return null;
        }

        // Generic type method, we pass the type in when we call
        public async Task<T> GetByUrlAsync<T>(string url)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<T>();
            }
            return default;
        }

        // https://swapi.dev/api/people/?search=r2

        public async Task<SearchResult<Person>> GetPersonSearchAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.dev/api/people/?search={query}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<Person>>();
            }
            return null;
        }

        public async Task<SearchResult<T>> GetSearchAsync<T>(string category, string query) //swapi.GetSearchAsync<Vehicle>("vehicles","wing");
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://swapi.dev/api/{category}/?search={query}");
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<SearchResult<T>>();
            }
            return default;
        }

        public async Task<SearchResult<Vehicle>> GetVehicleSearchAsync(string query)
        {
            return await GetSearchAsync<Vehicle>("vehicles", query);
        }

    }
}
