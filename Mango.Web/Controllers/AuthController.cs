using Mango.Web.Models;
using MCoupon.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MCoupon.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            this._authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AssignRole()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
