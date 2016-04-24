using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebPages;
using GoatOrNot.Models;
using GoatOrNot.Services;
using Microsoft.ProjectOxford.Vision;

namespace GoatOrNot.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGoatDetector _goatDetector;
        private readonly IGoatApiClient _goatApiClient;

        public HomeController(IGoatDetector goatDetector, IGoatApiClient goatApiClient)
        {
            _goatDetector = goatDetector;
            _goatApiClient = goatApiClient;
        }

        public async Task<ActionResult> Index(string imageUrl)
        {
            if (!imageUrl.IsEmpty())
            {
                try
                {
                    var isGoat = await _goatDetector.IsGoat(imageUrl);
                    var model = new ResultsModel
                    {
                        IsGoat = isGoat,
                        ImageUrl = imageUrl,
                        Quote = isGoat ? (await _goatApiClient.GetQuoteAsync()).Value : null
                    };
                    return View(model);
                }
                catch (ClientException)
                {
                    return RedirectToAction ("Error");
                }
                catch (Exception)
                {
                    return RedirectToAction("Error");
                }
            }

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }
    }
}