using System.Collections.Generic;

namespace ChatBotUI.Models
{
    public class BotResponse
    {
        public string Content { get; set; }

        public List<string> Options { get; set; } = new List<string>();
    }
}
