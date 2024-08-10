using Microsoft.AspNetCore.Mvc;

namespace Lab_CustomMiddleware.Controllers
{
    public class AccountController : Controller
    {
        [Route("/login")]
        public IActionResult Login()
        {
            return View();
        }
    }
}
