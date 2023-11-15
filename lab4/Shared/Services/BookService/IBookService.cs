using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.BookStore;

namespace Shared.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<PaginationResponse<Book>>> GetBooksAsync(int page, int size);
        Task<ServiceResponse<Book>> UpdateBookAsync(Book product);
        Task<ServiceResponse<bool>> DeleteBookAsync(int id);
        Task<ServiceResponse<Book>> CreateBookAsync(Book product);
    }

    public class PaginationResponse<Book>
    {
        public List<Book> Data { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
