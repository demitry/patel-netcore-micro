using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        void PopulateViewBagRoleList()
        {
            ViewBag.RoleList = new List<SelectListItem>()
            {
                new SelectListItem{ Text = AppRole.Admin, Value = AppRole.Admin },
                new SelectListItem{ Text = AppRole.Customer, Value = AppRole.Customer }
            };
        }

        [HttpGet]
        public IActionResult Register()
        {
            PopulateViewBagRoleList();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto registerDto)
        {
            ResponseDto result = await _authService.RegisterAsync(registerDto);

            ResponseDto assignRoleDto;

            if (result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(registerDto.Role))
                {
                    registerDto.Role = AppRole.Customer;
                }

                assignRoleDto = await _authService.AssignRoleAsync(registerDto);

                if (assignRoleDto != null && assignRoleDto.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }

            PopulateViewBagRoleList();

            return View(registerDto);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}
