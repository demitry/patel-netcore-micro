using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using static Mango.Web.Utility.SD;
//using static Microsoft.Net.Http.Headers.HeaderNames;
using Microsoft.Net.Http.Headers;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
                _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("MangoAPI");
                client.DefaultRequestHeaders.ExpectContinue = false; // <-- Make sure it is false. // https://stackoverflow.com/questions/18673896/internal-server-error-when-doing-a-post-with-httpclient-in-windows-phone-8
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeNames.Application.Json));
                //client.Timeout = TimeSpan.FromSeconds(60);
                
                HttpRequestMessage message = new();
                message.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
                
                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add(HeaderNames.Authorization, $"Bearer {token}");
                }

                message.RequestUri = new Uri(requestDto.Url);
                
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(
                        JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, MediaTypeNames.Application.Json);
                }
 
                HttpResponseMessage? apiResponse = null;

                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);
                
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }catch (Exception ex)
            {
                var dto = new ResponseDto
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }
    }
}
