using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory clientFactory)
        {
            _httpClientFactory = clientFactory;
        }

        public async Task<CouponDto> GetCoupon(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var couponServiceResponse = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var content = await couponServiceResponse.Content.ReadAsStringAsync();
            
            var responseData = JsonConvert.DeserializeObject<ResponseDto>(content); // it will be NullReference if unauthorized
            if (responseData != null && responseData.IsSuccess)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(responseData.Result));
            }
            return new CouponDto();
        }
    }
}
