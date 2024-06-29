using Microsoft.AspNetCore.Mvc;

namespace Identity_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
