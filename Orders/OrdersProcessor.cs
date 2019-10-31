using System.Collections.Generic;
using System.Net;
using ABE_Lojista.Controllers;
using ABE_Lojista.Models;
using Newtonsoft.Json;
using RestSharp;

namespace ABE_Lojista.Orders
{
    public class OrdersProcessor
    {
        private string AtacadistaApiUrl = "http://localhost:50000/api/v1";

        public void ProcessOrder(OrderResponseDTO orderResponse)
        {

        }

        public void RequestProducts()
        {
            //ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;
            var productRequest = CreateProductsRequest();

            var client = new RestClient(AtacadistaApiUrl);
            var request = new RestRequest("Orders", Method.POST);
            request.AddJsonBody(productRequest);

            var response = client.Execute(request);
            var content = response.Content;

            if (!string.IsNullOrEmpty(content))
            {
                var order = JsonConvert.DeserializeObject<OrderResponseDTO>(content);

                OrdersController.Orders.Add(order);
                
                if (order.OrderValue < 200)
                {
                    ConfirmRequest(order.Id);
                }
            }
        }

        private void ConfirmRequest(int orderId)
        {
            var productRequest = CreateProductsRequest();
            var acceptanceRequest = CreateOrderAcceptanceResponse(orderId);

            var client = new RestClient(AtacadistaApiUrl);
            var request = new RestRequest("Orders", Method.PUT);
            request.AddJsonBody(acceptanceRequest);

            var response = client.Execute(request);
            var content = response.Content;
        }

        private OrderRequestDTO CreateProductsRequest()
        {
            return new OrderRequestDTO
            {
                Orders = new List<Order>()
                {
                    new Order{
                        Code = 14,
                        Quantity = 7,
                        Notes = "test teste 123"
                    },
                    new Order{
                        Code = 22,
                        Quantity = 12,
                        Notes = "123 123 test"
                    }
                }
            };
        }

        private OrderAcceptanceResponse CreateOrderAcceptanceResponse(int orderId)
        {
            return new OrderAcceptanceResponse
            {
                AcceptOrder = true,
                OrderId = orderId,
                Links = new List<BaseDTOLink>()
                {
                    new BaseDTOLink
                    {
                        Rel = "notification",
                        Href = "http://localhost:60000/api/v1/Orders/Notify"
                    }
                }
            };
        }
    }
}