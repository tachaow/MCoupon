using Mango.Web.Models;

namespace MCoupon.Web.Models
{
    public class StripeRequestDto
    {
        public string StripeSessionUrl { get; set; }
        public string StripeSessinId { get; set; }
        public string ApproveUrl { get; set; }
        public string CancelUrl { get; set; }
        public OrderHeaderDto OrderHeader { get; set; }
    }
}
