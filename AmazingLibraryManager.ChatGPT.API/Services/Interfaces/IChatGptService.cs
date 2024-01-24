using OpenAI_API.Chat;

namespace AmazingLibraryManager.ChatGPT.API.Services.Interfaces
{
    public interface IChatGptService
    {
        Task<List<ChatResult>> GetChatHistory();
        Task<string> GetChatGptResponse(string prompt);
    }
}