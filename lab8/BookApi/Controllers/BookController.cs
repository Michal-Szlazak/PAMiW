﻿using Microsoft.AspNetCore.Mvc;
using BookApi.Services.BookService;
using ProjectShared.BookStore;
using Microsoft.AspNetCore.Authorization;

namespace BookApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        [HttpGet("{page}/{size}")]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks([FromRoute] int page, [FromRoute] int size)
             {

            var result = await _bookService.GetBooksAsync(page, size);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<ServiceResponse<Book>>> GetProduct(int id)
        {

            var result = await _bookService.GetBookByIdAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<Book>>> UpdateBook([FromBody] Book book)
        {

            var result = await _bookService.UpdateBookAsync(book);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost]
        [Authorize(Roles = "Admin,User")]
        public async Task<ActionResult<ServiceResponse<Book>>> CreateBook([FromBody] Book book)
        {
            var result = await _bookService.CreateBookAsync(book);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteBook([FromRoute] int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

    }
}
