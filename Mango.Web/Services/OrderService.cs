using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;
using MCoupon.Web.Models;

namespace Mango.Web.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBaseService _baseService;

        public OrderService(IBaseService baseService)
        {
            this._baseService = baseService;
        }

        public async Task<ResponseDto> CreateOrder(CartDto cartDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = cartDto,
                Url = SD.OrderAPIBase + "/api/order/CreateOrder"
            });
        }

        public async Task<ResponseDto> CreateStripeSession(StripeRequestDto stripeRequestDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = stripeRequestDto,
                Url = SD.OrderAPIBase + "/api/order/CreateStripeSession"
            });
        }

        public async Task<ResponseDto> ValidateStripeSession(int orderHeaderId)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = orderHeaderId,
                Url = SD.OrderAPIBase + "/api/order/ValidateStripeSession"
            });
        }
    }
}
