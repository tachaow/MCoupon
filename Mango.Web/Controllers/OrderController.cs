using Microsoft.AspNetCore.Mvc;

namespace MCoupon.Web.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult OrderIndex()
        {
            return View();
        }
    }
}
