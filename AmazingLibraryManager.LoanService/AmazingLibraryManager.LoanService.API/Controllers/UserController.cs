using AmazingLibraryManager.LoanService.API.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AmazingLibraryManager.LoanService.API.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAvailibleUsers() 
        {
            try
            {
                return Ok(await _userService.GetAvailibleUsers());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}