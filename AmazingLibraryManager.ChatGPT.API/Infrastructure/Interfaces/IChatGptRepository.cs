using OpenAI_API.Chat;

namespace AmazingLibraryManager.ChatGPT.API.Infrastructure.Interfaces
{
    public interface IChatGptRepository
    {
        Task<List<ChatResult>> GetFullHistory(); 
        Task AddChatResultHistory(ChatResult chatResult);
    }
}