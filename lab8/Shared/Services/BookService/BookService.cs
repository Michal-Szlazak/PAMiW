

using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using ProjectShared.BookStore;
using ProjectShared.Configuration;

namespace ProjectShared.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public BookService(HttpClient httpClient, AppSettings appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings;
        }
        

        public async Task<ServiceResponse<PaginationResponse<Book>>> GetBooksAsync(int page, int size)
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseAPIUrl + "/" +
                _appSettings.BaseBookEndpoint.Base_url + page + "/" + size);

            if(response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<PaginationResponse<Book>>>(json);
                return result;
            } else
            {
                return new ServiceResponse<PaginationResponse<Book>>() { Data = null, Success = false, Message = 
                    "Failed to get the booksies." + " " + _appSettings.BaseAPIUrl + "/" +
                _appSettings.BaseBookEndpoint.Base_url + page + "/" + size
                };
            }
        }

        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book book)
        {
            var response = await _httpClient.PutAsJsonAsync("api/Book", book);

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
            var response = await _httpClient.DeleteAsync("api/Book/" + $"{id}");

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
            var response = await _httpClient.PostAsJsonAsync("api/Book", product);

            if(response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Book>>();
                return result;
            } else
            {
                return new ServiceResponse<Book>() { Data = null, Success = false, Message = "Failed to create the book." };
            }
        }

        public async Task<ServiceResponse<Book>> GetBookByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync("api/Book/" + id);
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Book>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Book>>(json)
                ?? new ServiceResponse<Book> { Success = false, Message = "Deserialization failed" };

            result.Success = result.Success && result.Data != null;

            return result;
        }
    }
}
