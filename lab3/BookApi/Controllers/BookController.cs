using Microsoft.AspNetCore.Mvc;
using Shared;
using Shared.Services.BookService;
using Shared.BookStore;

namespace BookApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> GetBooks()
        {

            var result = await _bookService.GetBooksAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<Book>>>> DeleteBook()
        {

            var result = await _bookService.GetBooksAsync();

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }
    }
}
