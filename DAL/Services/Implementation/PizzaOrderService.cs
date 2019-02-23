using DAL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.Services.Implementation
{
    internal class PizzaOrderService : IPizzaOrderService
    {
        private readonly ApiContext apiContext;

        private Order GetOrder(int orderId)
        {
            var order = this.apiContext.Order.SingleOrDefault(el => el.Id == orderId);
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
        public async Task CanselOrderAsync(int orderId)
        {            
            var order = this.GetOrder(orderId);

            order.IsConfirmed = false;
            order.IsCanseled = true;

            await this.apiContext.SaveChangesAsync();
        }

        public async Task ConfirmOrderAsync(int orderId)
        {
            var order = this.GetOrder(orderId);
            if (order.IsCanseled)
            {
                throw new NullReferenceException("Заказ отменен и не может быть подтвеоржден.");
            }
            order.IsConfirmed = true;
            await this.apiContext.SaveChangesAsync();
        }

        public async Task<int> SetOrderAsync(Order order)
        {
            await this.apiContext.Order.AddAsync(order);
            await this.apiContext.SaveChangesAsync();
            return order.Id;
        }
    }
}
