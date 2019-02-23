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
        Task SetOrderAsync(Order order);

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
        Task CanselOrderAsync(int orderId);
    }
}
