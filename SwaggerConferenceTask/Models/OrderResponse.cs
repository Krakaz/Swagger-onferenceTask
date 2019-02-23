using System;

namespace SwaggerConferenceTask.Models
{
    public class OrderResponse
    {
        public int OrderNum { get; set; }

        public int OrderPrice { get; set; }

        public TimeSpan DeliveryTime { get; set; }
    }
}
