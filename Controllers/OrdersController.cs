using ABE_Lojista.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABE_Lojista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Receive any placed order status changes
        /// </summary>
        [HttpPost]
        public ActionResult<string> NotifyOrderStatus(OrderStatusResponseDTO orderStatusResponse)
        {

            return "value1";
        }

        /// <summary>
        /// Receive any order request with estimated delivery date and pricing. Responds to the acceptance link.
        /// </summary>
        [HttpPost]
        public ActionResult<string> RespondOrderRequest(OrderRequestDTO orderRequest)
        {

            return "value1";
        }
    }
}