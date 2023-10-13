﻿using Mango.Web.Models;
using MCoupon.Web.Models;

namespace Mango.Web.Services.IServices
{
    public interface IOrderService
    {
        Task<ResponseDto> CreateOrder(CartDto cartDto);
        Task<ResponseDto> CreateStripeSession(StripeRequestDto stripeRequestDto);
    }
}
