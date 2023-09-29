using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Mango.Services.ShoppingCartAPI.Models.Dto
{
    public class CartHeaderDto
    {
        //public int CartHeadId { get; set; }
        //public string? UserId { get; set; }
        //public string? CouponCode { get; set; }
        //public double Discount { get; set; }
        //public double CartTotal { get; set; }

        public int CartHeaderId { get; set; }
        public string? UserId { get; set; }
        public string? CouponCode { get; set; }
        public double Discount { get; set; }
        public double CartTotal { get; set; }
    }
}
