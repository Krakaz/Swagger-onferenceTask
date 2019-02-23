using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    /// <summary>
    /// Сервис по заказу пиццы
    /// </summary>
    public interface IPizzaOrderService
    {
        /// <summary>
        /// Производит запись заказа
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        Task<int> SetOrderAsync(Order order);

        /// <summary>
        /// Производит запись детализации заказа
        /// </summary>
        /// <param name="pizzaOrder"></param>
        /// <returns></returns>
        Task SavePizzaOrderAsync(IEnumerable<PizzaOrder> pizzaOrder);

        /// <summary>
        /// Подтверждает заказ
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task ConfirmOrderAsync(int orderId);

        /// <summary>
        /// Отменяет заказ
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task CancelOrderAsync(int orderId);

        /// <summary>
        /// Получает список всех заказов
        /// </summary>
        /// <returns></returns>
        IEnumerable<Order> GetList();
    }
}
