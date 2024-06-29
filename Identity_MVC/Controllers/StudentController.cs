using Microsoft.AspNetCore.Mvc;

namespace Identity_MVC.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
