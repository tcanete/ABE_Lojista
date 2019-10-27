using ABE_Lojista.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABE_Lojista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Receive any changes on placed order status
        /// </summary>
        [HttpPut]
        public ActionResult<string> NotifyOrderStatus(OrderRequestDTO orderRequest)
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