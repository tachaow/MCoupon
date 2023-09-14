namespace Mango.Services.CouponAPI.Models.Dto
{
    public class CouponDto
    {
        public int CounponId { get; set; }
        public string CounponCode { get; set; }
        public double DiscountAmount { get; set; }
        public int MinAmount { get; set; }
    }
}
