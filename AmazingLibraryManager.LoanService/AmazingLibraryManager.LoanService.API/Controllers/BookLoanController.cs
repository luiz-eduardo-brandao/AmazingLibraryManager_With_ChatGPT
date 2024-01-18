using AmazingLibraryManager.LoanService.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AmazingLibraryManager.LoanService.API.Controllers
{
    [ApiController]
    [Route("loan")]
    public class BookLoanController : ControllerBase
    {
        private readonly IBookLoanService _bookLoanService;

        public BookLoanController(IBookLoanService bookLoanService)
        {
            _bookLoanService = bookLoanService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            try 
            {
                return Ok(await _bookLoanService.GetAll());
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(Guid userId) 
        {
            try 
            {
                return Ok(await _bookLoanService.GetByUserId(userId));
            }
            catch (Exception ex) 
            {
                return NotFound(ex.Message);
            }
        }
    }
}