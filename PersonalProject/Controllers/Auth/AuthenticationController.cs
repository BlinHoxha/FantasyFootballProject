using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
