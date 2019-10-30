using System;
using System.Net;
using ABE_Lojista.Controllers;
using ABE_Lojista.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace ABE_Lojista.Tests
{
    public class OrdersTest
    {
        [Fact]
        public void NotifyOrderStatus()
        {
            // Arrange
            var controller = new OrdersController();
            var resquest = new OrderResponseDTO()
            {
                Id = 1
            };
            ResetOrderList();

            // Act
            var result = controller.NotifyOrderStatus(resquest) as OkResult;
            var expected = (int)HttpStatusCode.OK;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expected, result.StatusCode);
        }

        private void ResetOrderList()
        {
            OrdersController.Orders = new System.Collections.Generic.List<OrderResponseDTO>()
            {
                new OrderResponseDTO
                {
                    Id = 1,
                    DeliveryDate = DateTime.Now,
                    Orders = new System.Collections.Generic.List<Order>(){
                        new Order{
                            Code = 1,
                            Quantity = 12,
                            Notes = "testes teste"
                        }
                    },
                    OrderValue = 12.56m,
                    Status = OrderStatus.Created,
                    Links = new System.Collections.Generic.List<BaseDTOLink>()
                }
            };
        }
    }
}