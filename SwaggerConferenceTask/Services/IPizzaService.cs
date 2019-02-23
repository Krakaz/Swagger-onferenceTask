using SwaggerConferenceTask.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwaggerConferenceTask.Services
{
    /// <summary>
    /// API Сервис по заказу пиццы
    /// </summary>
    public interface IPizzaService
    {
        /// <summary>
        /// Производит запись заказа
        /// </summary>
        /// <param name="order">Заказ на пицы</param>
        /// <returns></returns>
        Task<OrderResponse> SetOrderAsync(IEnumerable<OrderVM> order);

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
