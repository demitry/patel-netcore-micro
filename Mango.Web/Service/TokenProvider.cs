using Mango.Web.Service.IService;
using Mango.Web.Utility;

namespace Mango.Web.Service
{
    public class TokenProvider : ITokenProvider
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenProvider(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public void ClearToken() => _contextAccessor.HttpContext?.Response.Cookies.Delete(Constant.TokenCookie);

        public string? GetToken() => _contextAccessor.HttpContext?.Request.Cookies.TryGetValue(Constant.TokenCookie, out string? token) is true ? token : null;

        public void SetToken(string token) => _contextAccessor.HttpContext?.Response.Cookies.Append(Constant.TokenCookie, token);
        
    }
}
