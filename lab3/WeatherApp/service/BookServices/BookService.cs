using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Shared;
using Shared.BookStore;
using Shared.Services.BookService;
using WeatherApp.Configuration;

namespace WeatherApp.service.BookServices
{
    internal class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public BookService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseBookEndpoint.GetAllBooksEndpoint);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Book>>>(json);
            return result;
        }
    }
}
