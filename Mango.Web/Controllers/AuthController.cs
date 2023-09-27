using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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

        public AuthController(IAuthService authService, ITokenProvider  tokenProvider)
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
        public async Task<IActionResult> Login(LoginRequestDto obj)
        {
            ResponseDto responseDto = await _authService.LoginAsync(obj);

            if (responseDto != null && responseDto.IsSuccess)
            {
                LoginResponseDto loginResponseDto = 
                    JsonConvert.DeserializeObject<LoginResponseDto>(Convert.ToString(responseDto.Result));

                await SignInUser(loginResponseDto);
                _tokenProvider.SetToken(loginResponseDto.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["error"] = responseDto.Message;
                return View(obj);
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDto obj)
        {
            ResponseDto result = await _authService.RegisterAsync(obj);
            ResponseDto assingRoleResponse;

            if( result != null && result.IsSuccess)
            {
                if (string.IsNullOrEmpty(obj.Role))
                {
                    obj.Role = SD.RoleCustomer;
                }
                
                assingRoleResponse = await _authService.AssignRoleAsync(obj);
                if (assingRoleResponse != null && assingRoleResponse.IsSuccess)
                {
                    TempData["success"] = string.IsNullOrWhiteSpace(result.Message)
                        ? "Registration Successful"
                        : $"Registration Successful but {result.Message}";

                    return RedirectToAction(nameof(Login));
                }
            }
            else
            {
                TempData["error"] = result.Message;
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem{Text=SD.RoleAdmin,Value=SD.RoleAdmin},
                new SelectListItem{Text=SD.RoleCustomer,Value=SD.RoleCustomer},
            };

            ViewBag.RoleList = roleList;
            return View(obj);
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            _tokenProvider.ClearToken();
            return RedirectToAction("Index","Home");
        }

        private async Task SignInUser(LoginResponseDto loginResponseDto)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(loginResponseDto.Token);
            var identity = CreateClaimsIdentityBasedOnJwt(jwt);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

        private ClaimsIdentity CreateClaimsIdentityBasedOnJwt(JwtSecurityToken jwt)
        {
            var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);

            var emailClaim = jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Email)?.Value;
            if (emailClaim != null)
            {
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Email, emailClaim));

                // NB! Without this claim type the User will be null, in _Layout, User.Identity.Name
                identity.AddClaim(new Claim(ClaimTypes.Name, emailClaim));
            }

            var subClaim = jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Sub)?.Value;
            if (subClaim != null)
            {
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, subClaim));
            }

            var nameClaim = jwt.Claims.FirstOrDefault(claim => claim.Type == JwtRegisteredClaimNames.Name)?.Value;
            if (nameClaim != null)
            {
                identity.AddClaim(new Claim(JwtRegisteredClaimNames.Name, nameClaim));
            }

            var roleClaim = jwt.Claims.FirstOrDefault(u => u.Type == "role")?.Value;
            if (roleClaim != null)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, roleClaim));
            }

            return identity;
        }

    }
}
