namespace AmazingLibraryManager.ChatGPT.API.Models
{
    public class ChatGptRequestModel
    {
        public ChatGptRequestModel(string prompt)
        {
            model = "gpt-3.5-turbo";
            temperature = 0.7;
            messages = new List<Message> 
            {
                new Message { role = "user", content = prompt }
            };
        }

        public string model { get; set; }
        public List<Message> messages { get; set; }
        public double temperature { get; set; }
    }
}