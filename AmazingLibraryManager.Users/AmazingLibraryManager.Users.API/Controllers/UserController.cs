using AmazingLibraryManager.Users.Application.InputModels;
using AmazingLibraryManager.Users.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AmazingLibraryManager.Users.API.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            try
            {
                return Ok(await _userService.Get());
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("availibles")]
        public async Task<IActionResult> GetAvailibles() 
        {
            try
            {
                return Ok(await _userService.GetAllAvailible());
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
                return Ok(await _userService.GetById(id));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AddUserInputModel model) 
        {
            try
            {
                return Ok(await _userService.AddUser(model));
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserInputModel model) 
        {
            try 
            {
                return Ok(await _userService.UpdateUser(model));
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
                await _userService.DeleteUser(id);

                return Ok("User has been deleted.");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
    }
}