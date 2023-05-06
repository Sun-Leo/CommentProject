using Microsoft.AspNetCore.Mvc;

namespace CommentProject.Controllers
{
    public class WriterDashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
