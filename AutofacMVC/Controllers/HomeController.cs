using System.Web.Mvc;
using CpMVC.Services.Test;

namespace CpMVC.Controllers
{
    public class HomeController : Controller
    {

        public HomeController(ITestService testService)
        {
            var s = testService;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}