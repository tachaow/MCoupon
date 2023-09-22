using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Mango.Web.Utility;

namespace Mango.Web.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseService _baseService;

        public ProductService(IBaseService baseService)
        {
            this._baseService = baseService;
        }

        public async  Task<ResponseDto> CreateProductAsync(ProductDto ProductDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.POST,
                Data = ProductDto,
                Url = SD.ProductAPIBase + "/api/product"
            });
        }

        public async  Task<ResponseDto> DeleteProductAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.DELETE,
                Url = SD.ProductAPIBase + "/api/product/" + id
            });
        }
               
        public async  Task<ResponseDto> GetAllProductAsync()
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                   ApiType = Utility.SD.ApiType.GET,
                   Url=SD.ProductAPIBase+"/api/product"
            });
        }
               
        public async  Task<ResponseDto> GetProductAsync(string ProductCode)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/Product/GetByCode"+ProductCode
            });
        }
               
        public async  Task<ResponseDto> GetProductByIdAsync(int id)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.GET,
                Url = SD.ProductAPIBase + "/api/Product/" + id
            });
        }
               
        public async  Task<ResponseDto> UpdateProductAsync(ProductDto ProductDto)
        {
            return await _baseService.SendAsync(new RequestDto()
            {
                ApiType = Utility.SD.ApiType.PUT,
                Data = ProductDto,
                Url = SD.ProductAPIBase + "/api/Product"
            });
        }
    }
}
