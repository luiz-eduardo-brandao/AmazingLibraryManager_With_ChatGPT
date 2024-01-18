using AmazingLibraryManager.LoanService.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AmazingLibraryManager.LoanService.API.Controllers
{
    [ApiController]
    [Route("bookCatalog")]
    public class BookCatalogController : ControllerBase
    {
        private readonly IBookCatalogService _bookCatalogService;

        public BookCatalogController(IBookCatalogService bookCatalogService)
        {
            _bookCatalogService = bookCatalogService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailibleBooks() 
        {
            try
            {
                return Ok(await _bookCatalogService.GetAvailibleBooks());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}