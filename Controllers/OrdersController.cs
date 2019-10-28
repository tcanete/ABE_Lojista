using ABE_Lojista.Models;
using Microsoft.AspNetCore.Mvc;

namespace ABE_Lojista.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        /// <summary>
        /// Receive any changes on placed order status
        /// </summary>
        [HttpPut]
        public ActionResult NotifyOrderStatus(OrderResponseDTO orderResponse)
        {

            return Ok();
        }

        /// <summary>
        /// Receive any order request with estimated delivery date and pricing. Responds to the acceptance link.
        /// </summary>
        [HttpPost]
        public ActionResult RespondOrderRequest(OrderResponseDTO orderResponsee)
        {

            return Ok();
        }
    }
}