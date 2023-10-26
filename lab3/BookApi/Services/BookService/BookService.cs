using DataSeeder;
using Shared;
using Shared.BookStore;
using Shared.Services.BookService;

namespace BookApi.Services.BookService
{
    public class BookService : IBookService
    {
        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = ProductSeeder.GenerateProductData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Book>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Book>> DeleteBookAsync(Book book)
        {
            try
            {
                var response = new ServiceResponse<Book>()
                {
                    Data = ProductSeeder.GenerateProductData(),
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }
    }
}
