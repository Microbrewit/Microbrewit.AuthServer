using Microsoft.AspNet.Mvc;

namespace Microbrewit.AuthServer.UI.Home
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
