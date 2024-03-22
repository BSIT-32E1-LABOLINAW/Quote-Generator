using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Quote_Generator.Controllers
{
    public class QuoteController : Controller
    {
        private readonly HttpClient _httpClient;

        public QuoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("QuoteAPI");
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Random()
        {
            try
            {
                var response = await _httpClient.GetAsync("random");

                if (response.IsSuccessStatusCode)
                {
                    var quote = await response.Content.ReadAsAsync<Quote>();
                    return Json(new { content = quote.Content, author = quote.Author });
                }
                else
                {
                    return NotFound();
                }
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class Quote
    {
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
