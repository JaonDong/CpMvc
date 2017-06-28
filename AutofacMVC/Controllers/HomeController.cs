using System.Web.Mvc;
using Cp.Core.Domain.TestModels;
using CpMVC.Services.Test;

namespace CpMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITestService _testService;
        public HomeController(ITestService testService)
        {
            _testService = testService;
        }

        // GET: Home
        public ActionResult Index()
        {
            _testService.InsertStudent(new Student()
            {
                Name = "张三"
            });
            return View();
        }
    }
}