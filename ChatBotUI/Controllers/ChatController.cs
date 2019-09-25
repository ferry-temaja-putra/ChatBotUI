using ChatBotUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

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
            var products = new string[] { "asset management", "financials", "student management" };

            if (lowerInput == "hi")
            {
                response.Content = "Please select a product:";
                response.Options.Add("Asset Management");
                response.Options.Add("Financials");
                response.Options.Add("Student Management");
            }
            else if (products.Contains(lowerInput))
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