using ChatBotUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        [HttpGet("{input}")]
        public ActionResult<BotResponse> Get(string input)
        {
            var lowerInput = input.ToLower();
            var response = new BotResponse();

            if (lowerInput == "hi")
            {
                response.Content = "Please select a product:";
                response.Options.Add("Asset Management");
                response.Options.Add("Financials");
            }
            else if (lowerInput == "asset management" || lowerInput == "financials")
            {
                response.Content = $"You selected [{input}]";
            }
            else
            {
                response.Content = $"Unrecognised response [{input}]";
            }

            return Ok(response);
        }
    }
}