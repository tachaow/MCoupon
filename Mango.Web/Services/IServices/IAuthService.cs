using Mango.Web.Models;

namespace MCoupon.Web.Services.IServices
{
    public interface IAuthService
    {
        Task<ResponseDto?> LoginAsync(LoginRequestDto loginRequestDto);
        Task<ResponseDto?> RegiserAsync(RegisterationRequestDto registerationRequestDto);
        Task<ResponseDto?> AssigRoleAsync(RegisterationRequestDto registerationRequestDto);
    }
}
