using Microsoft.AspNetCore.Mvc;
using QuoteGenerator.Models;
using System;
using System.Collections.Generic;

namespace QuoteGenerator.Controllers
{
    public class QuoteController : Controller
    {
        private List<Quote> quotes;

        public QuoteController()
        {
            // Initialize your list of quotes here
            quotes = new List<Quote>
    {
        new Quote { Id = 1, Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs", SourceURL = "https://www.goodreads.com/quotes/772887-the-only-way-to-do-great-work-is-to-love" },
        new Quote { Id = 2, Text = "Innovation distinguishes between a leader and a follower.", Author = "Steve Jobs", SourceURL = "https://www.inc.com/nick-hobson/steve-jobs-said-what-separates-a-leader-from-a-follower-really-comes-down-to-this-mindset.html#:~:text=Steve%20Jobs%20once%20said%2C%20%22Innovation,who%20excels%20as%20a%20leader." },
        new Quote { Id = 3, Text = "Stay hungry, stay foolish.", Author = "Steve Jobs", SourceURL = "https://en.wikipedia.org/wiki/Stay_Hungry_Stay_Foolish#:~:text=%22Stay%20Hungry.,Catalog%20published%20in%20October%201974.&text=It%20features%20the%20stories%20of,the%20rough%20road%20of%20entrepreneurship." },
        new Quote { Id = 4, Text = "Your time is limited, don't waste it living someone else's life.", Author = "Steve Jobs", SourceURL = "https://medium.com/@officialprpatel002/your-time-is-limited-dont-waste-it-living-someone-else-s-life-steve-jobs-dae3858035f7" },
        new Quote { Id = 5, Text = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston Churchill", SourceURL = "https://www.goodreads.com/quotes/3270-success-is-not-final-failure-is-not-fatal-it-is" },
        new Quote { Id = 6, Text = "The only thing we have to fear is fear itself.", Author = "Franklin D. Roosevelt", SourceURL = "https://historymatters.gmu.edu/d/5057/" },
        new Quote { Id = 7, Text = "Life is what happens when you're busy making other plans.", Author = "John Lennon", SourceURL = "https://medium.com/the-write-brain/life-is-what-happens-when-youre-busy-making-other-plans-john-lennon-363d6bff4c87" },
        new Quote { Id = 8, Text = "I have not failed. I've just found 10,000 ways that won't work.", Author = "Thomas A. Edison", SourceURL = "https://www.oxfordreference.com/display/10.1093/acref/9780191826719.001.0001/q-oro-ed4-00003960#:~:text=Thomas%20Alva%20Edison%201847%E2%80%931931&text=I%20have%20not%20failed.,ways%20that%20won't%20work.&text=Waste%20is%20worse%20than%20loss,of%20waste%20before%20him%20constantly." },
        new Quote { Id = 9, Text = "The only impossible journey is the one you never begin.", Author = "Tony Robbins", SourceURL = "https://medium.com/upchapter/the-only-impossible-journey-is-the-one-you-never-begin-anthony-robbins-62229bb9c770" },
        new Quote { Id = 10, Text = "The best revenge is massive success.", Author = "Frank Sinatra", SourceURL = "https://www.brainyquote.com/quotes/frank_sinatra_379942" }
    };
        }





        public IActionResult Index()
        {
            // Pass the entire list of quotes to the view
            return View(quotes);
        }


        public IActionResult Random()
        {
            Random rnd = new Random();
            int index = rnd.Next(quotes.Count);
            var randomQuote = quotes[index];
            return Json(randomQuote); // Return the random quote in JSON format
        }

        public IActionResult Quote(int id)
        {
            var quote = quotes.FirstOrDefault(q => q.Id == id);
            if (quote == null)
            {
                return NotFound();
            }

            return PartialView("_QuoteDetails", quote);
        }

    }
}
