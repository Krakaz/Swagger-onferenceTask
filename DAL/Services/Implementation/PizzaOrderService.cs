using DAL.Models;
using System;
using System.Threading.Tasks;

namespace DAL.Services.Implementation
{
    internal class PizzaOrderService : IPizzaOrderService
    {
        public Task CanselOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task ConfirmOrderAsync(int orderId)
        {
            throw new NotImplementedException();
        }

        public Task SetOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
