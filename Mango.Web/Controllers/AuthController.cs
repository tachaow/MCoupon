using Mango.Web.Models;
using Mango.Web.Utility;
using MCoupon.Web.Services;
using MCoupon.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace MCoupon.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService,ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
               new SelectListItem{Text =SD.RoleAdmin, Value = SD.RoleAdmin },
               new SelectListItem{Text =SD.RoleCustomer, Value = SD.RoleCustomer },

            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterationRequestDto obj)
        {
            ResponseDto result = await _authService.RegiserAsync(obj);
            ResponseDto assignRole;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;
                }

                assignRole = await _authService.AssigRoleAsync(obj);
                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>()
            {
               new SelectListItem{Text =SD.RoleAdmin, Value = SD.RoleAdmin },
               new SelectListItem{Text =SD.RoleCustomer, Value = SD.RoleCustomer },
            };


            ViewBag.RoleList = roleList;
            return View(obj);
        }

        public IActionResult Logout()
        {

            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
            //return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = 
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                _tokenProvider.SetToken(loginResponseDto.Token);

                return RedirectToAction("Index","Home");
            }
            else
            {
                ModelState.AddModelError("CustomerError", responseDto.Message);
                return View(obj);
            }
        }


        [HttpPost]
        public IActionResult AssignRole()
        {
            return View();
        }
    }
}
