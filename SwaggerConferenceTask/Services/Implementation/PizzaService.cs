using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DAL.Enums;
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
        public Task CancelOrderAsync(int orderId)
        {
            return this.pizzaOrderService.CancelOrderAsync(orderId);
        }

        public Task ConfirmOrderAsync(int orderId)
        {
            return this.pizzaOrderService.ConfirmOrderAsync(orderId);
        }

        public async Task<OrderResponse> SetOrderAsync(IEnumerable<PizzaOrderVM> order)
        {
            var orderDAL = new Order();
            
            orderDAL.DeliveryTime = this.GetDeliveryTime(order);
            orderDAL.OrderPrice = GetOrderPrice(order);

            var response = new OrderResponse();
            response.DeliveryTime = orderDAL.DeliveryTime;
            response.OrderPrice = orderDAL.OrderPrice;
            response.OrderNum = await this.pizzaOrderService.SetOrderAsync(orderDAL);
            var pizzas = order.Select(el => new PizzaOrder { OrderId = response.OrderNum, Pizza = el.Pizza, Count = el.Count });
            await this.pizzaOrderService.SavePizzaOrderAsync(pizzas);

            return response;
        }

        private TimeSpan GetDeliveryTime(IEnumerable<PizzaOrderVM> order)
        {
            var deliveryTime = DefaultDeliveryTime;
            foreach(var pizza in order)
            {
                var coockingTime = 15 + (new Random()).Next(30);
                deliveryTime.Add(TimeSpan.FromMinutes(coockingTime * pizza.Count));
            }
            return deliveryTime;
        }


        private int GetOrderPrice(IEnumerable<PizzaOrderVM> order)
        {
            var orderPrice = 0;
            foreach (var pizza in order)
            {
                orderPrice += (500 + (new Random()).Next(300)) * pizza.Count;
            }
            return orderPrice;
        }

        public IEnumerable<PizzaVM> GetPizzas()
        {
            var response = new List<PizzaVM>();
            foreach (Pizza pizza in Enum.GetValues(typeof(Pizza)))
            {
                var item = new PizzaVM()
                {
                    Id = (int)Enum.Parse(typeof(Pizza), pizza.ToString()),
                    Code = pizza,
                    Name = pizza.GetType().GetMember(pizza.ToString()).First()
                        .GetCustomAttribute<DescriptionAttribute>()
                        .Description
                };
                response.Add(item);
            }
            return response;
        }

        public IEnumerable<OrderResponseForList> GetOrders()
        {
            return this.pizzaOrderService.GetList().Select(el => new OrderResponseForList(el));
        }
    }
}
