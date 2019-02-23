﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public TimeSpan DeliveryTime { get; set; }

        public IEnumerable<PizzaOrder> Pizzas { get; set; }

        public bool IsConfirmed { get; set; }

        public bool IsCanseled { get; set; }
    }
}
