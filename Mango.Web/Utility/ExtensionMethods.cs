using Mango.Web.Models;
using Newtonsoft.Json;
using System.Net;

namespace Mango.Web.Utility
{
    public static class ExtensionMethods
    {
        public static HttpMethod ToHttpMethod(this ApiType apiType)
        {
            switch (apiType)
            {
                case ApiType.POST: return HttpMethod.Post;
                case ApiType.DELETE: return HttpMethod.Delete;
                case ApiType.PUT: return HttpMethod.Put;
                default: return HttpMethod.Get;
            }
        }

        public static async Task<ResponseDto?> ToResponseDtoAsync(this HttpResponseMessage? httpResponseMessage)
        {
            switch (httpResponseMessage.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new() { IsSuccess = false, Message = "Not Found" };
                case HttpStatusCode.Forbidden:
                    return new() { IsSuccess = false, Message = "Access Denied" };
                case HttpStatusCode.Unauthorized:
                    return new() { IsSuccess = false, Message = "Unauthorized" };
                case HttpStatusCode.InternalServerError:
                    return new() { IsSuccess = false, Message = "Internal Server Error" };
                case HttpStatusCode.BadRequest:
                    return new() { IsSuccess = false, Message = "Bad Request" };
                default:
                    var apiContent = await httpResponseMessage.Content.ReadAsStringAsync();
                    var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                    return apiResponseDto;
            }
        }
    }
}
