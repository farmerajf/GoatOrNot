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

        public HomeController(IGoatDetector goatDetector)
        {
            _goatDetector = goatDetector;
        }

        public async Task<ActionResult> Index(string imageUrl)
        {
            if (!imageUrl.IsEmpty())
            {
                try
                {
                    var model = new ResultsModel
                    {
                        IsGoat = await _goatDetector.IsGoat(imageUrl),
                        ImageUrl = imageUrl
                    };
                    return View(model);
                }
                catch (ClientException)
                {
                    return RedirectToAction ("Error");
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