using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerConferenceTask.Models
{
    public class OrderResponseForList: OrderResponse
    {
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }

        public OrderResponseForList(Order order)
        {
            this.OrderNum = order.Id;
            this.OrderPrice = order.OrderPrice;
            this.DeliveryTime = order.DeliveryTime;
            this.IsCanceled = order.IsCanceled;
            this.IsConfirmed = order.IsConfirmed;
        }
    }
}
