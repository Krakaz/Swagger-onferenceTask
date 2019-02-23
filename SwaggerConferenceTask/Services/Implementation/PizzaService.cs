using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Models;
using DAL.Services;
using SwaggerConferenceTask.Models;

namespace SwaggerConferenceTask.Services.Implementation
{
    internal class PizzaService : IPizzaService
    {
        private readonly IPizzaOrderService pizzaOrderService;

        public static TimeSpan DefaultDeliveryTime => TimeSpan.FromMinutes(30);

        public PizzaService(IPizzaOrderService pizzaOrderService)
        {
            this.pizzaOrderService = pizzaOrderService;
        }
        public Task CanselOrderAsync(int orderId)
        {
            return this.pizzaOrderService.CanselOrderAsync(orderId);
        }

        public Task ConfirmOrderAsync(int orderId)
        {
            return this.pizzaOrderService.ConfirmOrderAsync(orderId);
        }

        public async Task<OrderResponse> SetOrderAsync(IEnumerable<OrderVM> order)
        {
            var orderDAL = new Order();
            orderDAL.Pizzas = order.Select(el => new PizzaOrder { Pizza = el.Pizza, Count = el.Count });
            orderDAL.DeliveryTime = this.GetDeliveryTime(order);
            orderDAL.OrderPrice = GetOrderPrice(order);

            var response = new OrderResponse();
            response.DeliveryTime = orderDAL.DeliveryTime;
            response.OrderPrice = orderDAL.OrderPrice;
            response.OrderNum = await this.pizzaOrderService.SetOrderAsync(orderDAL);

            return response;
        }

        private TimeSpan GetDeliveryTime(IEnumerable<OrderVM> order)
        {
            var deliveryTime = DefaultDeliveryTime;
            foreach(var pizza in order)
            {
                var coockingTime = 15 + (new Random()).Next(30);
                deliveryTime.Add(TimeSpan.FromMinutes(coockingTime * pizza.Count));
            }
            return deliveryTime;
        }


        private int GetOrderPrice(IEnumerable<OrderVM> order)
        {
            var orderPrice = 0;
            foreach (var pizza in order)
            {
                orderPrice += (500 + (new Random()).Next(300)) * pizza.Count;
            }
            return orderPrice;
        }
    }
}
