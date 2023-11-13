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

        public async Task<ServiceResponse<PaginationResponse<Book>>> GetBooksAsync(int pageNumber, int pageSize)
        {
            try
            {
                var totalBooks = await _dataContext.Books.CountAsync();

                var books = await _dataContext.Books
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToListAsync();

                var paginationResponse = new PaginationResponse<Book>
                {
                    Data = books,
                    TotalItems = totalBooks,
                    PageNumber = pageNumber,
                    PageSize = pageSize,
                };

                return new ServiceResponse<PaginationResponse<Book>>
                {
                    Data = paginationResponse,
                    Success = true,
                    Message = ""
                };
            }
            catch (Exception ex)
            {
                // Log the exception details
                Console.WriteLine($"Error: {ex.Message}");
                return new ServiceResponse<PaginationResponse<Book>>
                {
                    Data = null,
                    Message = "An error occurred while fetching paginated Books",
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
