﻿using Mango.Services.ShoppingCartAPI.Models.Dto;
using Mango.Services.ShoppingCartAPI.Service.IService;
using Newtonsoft.Json;

namespace Mango.Services.ShoppingCartAPI.Service
{
    public class CouponService : ICouponService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CouponService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<CouponDto> GetCoupons(string couponCode)
        {
            var client = _httpClientFactory.CreateClient("Coupon");
            var response = await client.GetAsync($"/api/coupon/GetByCode/{couponCode}");
            var apiContet = await response.Content.ReadAsStringAsync();
            var resp = JsonConvert.DeserializeObject<ResponseDto>(apiContet);
            if (resp != null)
            {
                return JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(resp.Result));
            }
            return new CouponDto();
        }
    }
}
