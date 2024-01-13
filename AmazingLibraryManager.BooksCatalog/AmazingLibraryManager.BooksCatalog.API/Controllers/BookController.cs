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
            var result = await _bookService.GetAvailibleBooks();

            if (result?.Count() > 0) 
            { 
                return Ok(result);
            }
            else
            {
                return BadRequest("No records found.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bookService.GetAllBooks();

            if (result?.Count() > 0) 
            { 
                return Ok(result);
            }
            else
            {
                return BadRequest("No records found.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetById(id);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound("No records found.");
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
