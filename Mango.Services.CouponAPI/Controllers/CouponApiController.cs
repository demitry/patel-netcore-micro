using Mango.Services.CouponAPI.Data;
using Mango.Services.CouponAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mango.Services.CouponAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CouponApiController : ControllerBase
    {
        private readonly AppDbContext _db;

        public CouponApiController(AppDbContext db)
        {
            _db = db;
        }
        
        [HttpGet]
        public object Get()
        {
            try
            {
                List<Coupon> couponList =  _db.Coupons.ToList();
                return couponList;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        [HttpGet]
        [Route("{id:int}")]
        public object Get(int id)
        {
            try
            {
                Coupon coupon = _db.Coupons.First(c => c.CouponId == id);
                return coupon;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
