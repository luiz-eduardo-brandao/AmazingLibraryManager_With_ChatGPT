using AmazingLibraryManager.ChatGPT.API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using OpenAI_API;
using OpenAI_API.Chat;

namespace AmazingLibraryManager.ChatGPT.API.Controllers
{
    [Route("chat")]
    public class ChatController : Controller
    {
        private readonly IChatGptService _chatGptService;

        public ChatController(IChatGptService chatGptService)
        {
            _chatGptService = chatGptService;
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory() 
        {
            try
            {
                var result = await _chatGptService.GetChatHistory();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery(Name = "prompt")] string prompt) 
        {
            try
            {
                var result = await _chatGptService.GetChatGptResponse(prompt);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}