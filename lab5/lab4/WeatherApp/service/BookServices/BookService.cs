using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
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

        public async Task<ServiceResponse<PaginationResponse<Book>>> GetBooksAsync(int page, int size)
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseBookEndpoint.GetAllBooksEndpoint);

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<PaginationResponse<Book>>>(json);
                return result;
            } else
            {
                return new ServiceResponse<PaginationResponse<Book>>() { Data = null, Success = false, Message = "Failed to get the books." };
            }
        }

        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseBookEndpoint.GetAllBooksEndpoint, book);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
                return result;
            } else
            {
                return new ServiceResponse<Book>() { Data = null, Success = false, Message = "Failed to update the book." };
            }
        }

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{id}");

            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            } else
            {
                return new ServiceResponse<bool>() { Data = false, Success = false, Message = "Failed to delete the book."};
            }
        }

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book product)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BaseBookEndpoint.GetAllBooksEndpoint, product);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
                return result;
            } else
            {
                return new ServiceResponse<Book>() { Data = null, Success = false, Message = "Failed to create the book." };
            }
        }
    }
}
