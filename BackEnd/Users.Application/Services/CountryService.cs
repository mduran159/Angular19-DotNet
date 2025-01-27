using System.Net.Http;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace Users.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private const string CacheKey = "CountriesCache";

        public CountryService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<IEnumerable<string>> GetAllCountriesAsync()
        {
            // Verifica si los datos ya están en la caché
            if (_cache.TryGetValue(CacheKey, out List<string> cachedCountries))
            {
                return cachedCountries;
            }

            // Si no están en la caché, realiza la llamada a la API
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all?fields=name");
            var countriesData = JsonSerializer.Deserialize<List<CountryResponse>>(response);
            var countries = countriesData?.ConvertAll(c => c.name.common) ?? new List<string>();

            // Almacena los datos en la caché con una duración específica (e.g., 1 hora)
            _cache.Set(CacheKey, countries, TimeSpan.FromHours(1));

            return countries;
        }

        private class CountryResponse
        {
            public required Name name { get; set; }
        }

        private class Name
        {
            public required string common { get; set; }
        }
    }
}
