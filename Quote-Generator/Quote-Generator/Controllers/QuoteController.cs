using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace QuoteGenerator.Controllers
{
    public class QuoteController : Controller
    {
        private readonly HttpClient _httpClient;

        public QuoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Random(string keyword)
        {
            try
            {
                string apiUrl = "https://api.quotable.io/random";
                if (!string.IsNullOrEmpty(keyword))
                {
                    apiUrl += $"?tags={keyword}";
                }

                var response = await _httpClient.GetAsync(apiUrl);

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
