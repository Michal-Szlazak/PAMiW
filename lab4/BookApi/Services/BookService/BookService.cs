using DataSeeder;
using Shared;
using Shared.BookStore;
using Shared.Services.BookService;
using WeatherApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace BookApi.Services.BookService
{
    public class BookService : IBookService
    {

        private readonly DataContext _dataContext;

        public BookService (DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<Book>> CreateBookAsync(Book Book)
        {
            try
            {
                _dataContext.Books.Add(Book);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book>() { Data = Book, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>()
                {
                    Data = null,
                    Success = false,
                    Message = "Cannot create Book"
                };
            }

        }

        public async Task<ServiceResponse<List<Book>>> GetBooksAsync()
        {
            var Books = await _dataContext.Books.ToListAsync();

            try
            {
                var response = new ServiceResponse<List<Book>>()
                {
                    Data = Books,
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

        public async Task<ServiceResponse<bool>> DeleteBookAsync(int id)
        {
            try
            {
                var Book = new Book() { Id = id };
                _dataContext.Books.Attach(Book);
                _dataContext.Books.Remove(Book);
                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<bool>() { Data = true, Success = true };

            } catch (Exception)
            {
                return new ServiceResponse<bool>() { Data = false, Success = false };
            }

        }

        public async Task<ServiceResponse<Book>> UpdateBookAsync(Book Book)
        {
            try
            {
                var BookToEdit = new Book() { Id = Book.Id };
                _dataContext.Books.Attach(BookToEdit);

                BookToEdit.Title = Book.Title;
                BookToEdit.Description = Book.Description;
                BookToEdit.Author = Book.Author;

                await _dataContext.SaveChangesAsync();
                return new ServiceResponse<Book>() {  Data = Book, Success = true };
            }
            catch (Exception)
            {
                return new ServiceResponse<Book>
                {
                    Data = null,
                    Success = false,
                    Message = "An error occured while updating Book"
                };
            }
        }
    }
}
