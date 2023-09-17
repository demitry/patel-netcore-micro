using Mango.Web.Models;
using Mango.Web.Service.IService;
using Mango.Web.Utility;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;

namespace Mango.Web.Service
{
    public class BaseService : IBaseService
    {
        private IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("MangoApi");
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", MediaTypeNames.Application.Json);
            //tbd: token

            message.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null) // for post
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data),
                    Encoding.UTF8, MediaTypeNames.Application.Json);
            }

            message.Method = requestDto.ApiType.ToHttpMethod();
            HttpResponseMessage? apiResponse = await httpClient.SendAsync(message);
            return await apiResponse.ToResponseDtoAsync();
        }
    }
}
