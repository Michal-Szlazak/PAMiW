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
        Task<ServiceResponse<List<Book>>> GetBooksAsync();
        Task<ServiceResponse<Book>> UpdateBookAsync(Book product);
        Task<ServiceResponse<bool>> DeleteBookAsync(int id);
        Task<ServiceResponse<Book>> CreateBookAsync(Book product);
    }
}
