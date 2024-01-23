using AmazingLibraryManager.BooksCatalog.Application.InputModels;
using AmazingLibraryManager.BooksCatalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmazingLibraryManager.BooksCatalog.API.Controllers
{
    [Route("book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("availible")]
        public async Task<IActionResult> GetAvailible()
        {
            try
            {
                return Ok(await _bookService.GetAvailibleBooks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _bookService.GetAllBooks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                return Ok(await _bookService.GetById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] InsertBookInputModel model)
        {
            if (model is null) return BadRequest("Invalid Book.");

            try
            {
                var result = await _bookService.AddBook(model);

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No records have been changed.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] InsertBookInputModel model)
        {
            if (model is null) return BadRequest("Invalid Book.");

            try
            {
                var result = await _bookService.UpdateBook(model);

                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("No records have been changed.");
                }

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("review/{bookId}")]
        public async Task<IActionResult> GetReviews(Guid bookId) 
        {
            try 
            {
                return Ok(await _bookService.GetBookReviews(bookId));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("review/{bookId}")]
        public async Task<IActionResult> PostReview(Guid bookId, [FromBody] AddBookReviewInputModel model) 
        {
            try 
            {
                await _bookService.AddBookReview(bookId, model);

                return Ok("Book Review added with success.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("loan-book/{bookId}")]
        public async Task<IActionResult> RegisterBookLoan(Guid bookId) 
        {
            try
            {
                await _bookService.RegisterBookLoan(bookId);

                return Ok("Book Loan registered with success.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("return-book/{bookId}")]
        public async Task<IActionResult> RegisterBookReturn(Guid bookId) 
        {
            try
            {
                await _bookService.RegisterBookReturn(bookId);

                return Ok("Book Return registered with success.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            try 
            {
                await _bookService.DeleteBook(id);

                return Ok("Book successfuly deleted.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
