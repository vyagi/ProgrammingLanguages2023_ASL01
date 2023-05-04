using Microsoft.AspNetCore.Mvc;

namespace AspNetEmpty.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public int MySecondAction()
        {
            return 10;
        }

        public ViewResult GiveMeAView()
        {
            return View();
        }
    }
}
