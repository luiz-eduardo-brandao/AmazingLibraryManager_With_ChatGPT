using AmazingLibraryManager.ChatGPT.API.Infrastructure.Interfaces;
using AmazingLibraryManager.ChatGPT.API.Services.Interfaces;
using OpenAI_API;
using OpenAI_API.Chat;

namespace AmazingLibraryManager.ChatGPT.API.Services
{
    public class ChatGptService : IChatGptService
    {
        private readonly OpenAIAPI _chatGpt;
        private readonly IChatGptRepository _chatGptRepository;

        public ChatGptService(OpenAIAPI chatGpt, IChatGptRepository chatGptRepository)
        {
            _chatGpt = chatGpt;
            _chatGptRepository = chatGptRepository;
        }

        public async Task<List<ChatResult>> GetChatHistory() 
        {
            return await _chatGptRepository.GetFullHistory();
        }

        public async Task<string> GetChatGptResponse(string prompt) 
        {
            var messages = new List<ChatMessage> 
            {
                new ChatMessage(ChatMessageRole.User, prompt)
            };

            var request = new ChatRequest 
            {
                Model = "gpt-3.5-turbo",
                Temperature = 0.7,
                Messages = messages
            };

            var result = await _chatGpt.Chat.CreateChatCompletionAsync(request);

            if (result is null) throw new InvalidOperationException("An unexpected error occured.");

            await _chatGptRepository.AddChatResultHistory(result);

            var textContent = result.Choices[0].Message.TextContent;

            return textContent;
        }
    }
}