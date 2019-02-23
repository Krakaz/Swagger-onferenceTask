using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Services.Implementation
{
    internal class PizzaOrderService : IPizzaOrderService
    {
        private readonly ApiContext apiContext;

        private Order GetOrder(int orderId)
        {
            var order = this.apiContext.Orders.SingleOrDefault(el => el.Id == orderId);
            if(order == null)
            {
                throw new NullReferenceException("Заказ не найден.");
            }
            return order;
        }

        public PizzaOrderService(ApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public async Task CancelOrderAsync(int orderId)
        {            
            var order = this.GetOrder(orderId);

            order.IsConfirmed = false;
            order.IsCanceled = true;

            await this.apiContext.SaveChangesAsync();
        }

        public async Task ConfirmOrderAsync(int orderId)
        {
            var order = this.GetOrder(orderId);
            if (order.IsCanceled)
            {
                throw new NullReferenceException("Заказ отменен и не может быть подтвеоржден.");
            }
            order.IsConfirmed = true;
            await this.apiContext.SaveChangesAsync();
        }

        public async Task<int> SetOrderAsync(Order order)
        {
            await this.apiContext.Orders.AddAsync(order);
            await this.apiContext.SaveChangesAsync();
            return order.Id;
        }

        public IEnumerable<Order> GetList()
        {
            var orders = this.apiContext.Orders.ToList();
            return this.apiContext.Orders.ToList();
        }

        public async Task SavePizzaOrderAsync(IEnumerable<PizzaOrder> pizzaOrder)
        {
            await this.apiContext.PizzaOrders.AddRangeAsync(pizzaOrder);
            await this.apiContext.SaveChangesAsync();
        }
    }
}
