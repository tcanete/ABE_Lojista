using System.Collections.Generic;
using System.Linq;
using ABE_Lojista.Models;
using ABE_Lojista.Orders;
using Microsoft.AspNetCore.Mvc;

namespace ABE_Lojista.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public static List<OrderResponseDTO> Orders = new List<OrderResponseDTO>();

        /// <summary>
        /// Receive any changes on placed order status
        /// </summary>
        [HttpPut("Notify")]
        public ActionResult NotifyOrderStatus(OrderResponseDTO orderResponse)
        {
            var dbOrder = Orders.Where(o => o.Id == orderResponse.Id).FirstOrDefault();

            if (dbOrder != null)
            {
                dbOrder.Status = orderResponse.Status;
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet]
        public void Test()
        {
            var processor = new OrdersProcessor();
            processor.RequestProducts();
        }
    }
}