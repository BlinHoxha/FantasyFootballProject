using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Auth
{
    public class AuthenticationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
