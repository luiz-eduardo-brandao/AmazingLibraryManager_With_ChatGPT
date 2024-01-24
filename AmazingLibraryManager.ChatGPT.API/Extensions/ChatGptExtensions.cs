using OpenAI_API;

namespace AmazingLibraryManager.ChatGPT.API.Extensions
{
    public static class ChatGptExtensions
    {
        public static WebApplicationBuilder AddChatGpt(this WebApplicationBuilder builder) 
        {
            var key = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            var chat = new OpenAIAPI(key);

            builder.Services.AddSingleton(chat);

            return builder;
        }
    }
}