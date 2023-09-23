using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Mango.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;

        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDto loginRequestDto = new();
            return View(loginRequestDto);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDto loginRequestDto)
        {
            ResponseDto responseDto = await _authService.LoginAsync(loginRequestDto);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SignInUser(loginResponseDto);
                
                _tokenProvider.SetToken(loginResponseDto.Token);
                
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData[Constant.Error] = responseDto.Message;
                return View(loginRequestDto);
            }
        }

        private void PopulateViewBagRoleList()
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
                    TempData[Constant.Success] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData[Constant.Error] = result.Message;
            }

            PopulateViewBagRoleList();

            return View(registerDto);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();

            return RedirectToAction("Index", "Home");
        }


        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(loginResponseDto.Token);
            
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
            
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email, jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email).Value),
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub).Value),
                new Claim(JwtRegisteredClaimNames.Name, jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Name).Value),
                new Claim(ClaimTypes.Role, jwt.Claims.FirstOrDefault(u => u.Type == "role").Value),
                new Claim(ClaimTypes.Name, jwt.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Email).Value) // NB! Without this claim type the User will be null, in _Layout, User.Identity.Name
            };

            identity.AddClaims(claims);
            
            var principal = new ClaimsPrincipal(identity);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
    }
}
