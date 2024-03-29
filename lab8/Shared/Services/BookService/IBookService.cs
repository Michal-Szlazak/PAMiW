﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectShared.BookStore;

namespace ProjectShared.Services.BookService
{
    public interface IBookService
    {
        Task<ServiceResponse<PaginationResponse<Book>>> GetBooksAsync(int page, int size);
        Task<ServiceResponse<Book>> UpdateBookAsync(Book product, string token);
        Task<ServiceResponse<bool>> DeleteBookAsync(int id, string token);
        Task<ServiceResponse<Book>> GetBookByIdAsync(int id, string token);
        Task<ServiceResponse<Book>> CreateBookAsync(Book product, string token);
    }

    public class PaginationResponse<Book>
    {
        public List<Book> Data { get; set; }
        public int TotalItems { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
