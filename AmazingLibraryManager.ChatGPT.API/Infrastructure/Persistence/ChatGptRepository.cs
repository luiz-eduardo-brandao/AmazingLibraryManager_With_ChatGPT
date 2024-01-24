using AmazingLibraryManager.ChatGPT.API.Infrastructure.Interfaces;
using OpenAI_API.Chat;

namespace AmazingLibraryManager.ChatGPT.API.Infrastructure.Persistence
{
    public class ChatGptRepository : IChatGptRepository
    {
        private readonly List<ChatResult> _chatHistory;

        public ChatGptRepository()
        {
            _chatHistory = new List<ChatResult>();
        }

        public async Task<List<ChatResult>> GetFullHistory() 
        {
            return _chatHistory;
        }

        public async Task AddChatResultHistory(ChatResult chatResult) 
        {
            _chatHistory.Add(chatResult);
        }
    }
}