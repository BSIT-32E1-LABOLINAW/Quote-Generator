using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;


// The purpose of this is to retrieve the quotes from the API used in this small project.
namespace QuoteGenerator.Controllers
{
    public class QuoteController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public QuoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public async Task<IActionResult> Random()
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync("https://api.quotable.io/random");

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsAsync<dynamic>();

                    string quoteText = data.content;
                    string quoteAuthor = data.author;

                    return Json(new { content = quoteText, author = quoteAuthor });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
