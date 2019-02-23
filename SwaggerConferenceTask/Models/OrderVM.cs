using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SwaggerConferenceTask.Models
{
    [DataContract]
    public class OrderVM
    {
        [DataMember(Name = "orders")]
        public IEnumerable<PizzaOrderVM> Orders { get; set; }

    }

    [DataContract]
    public class PizzaOrderVM
    {
        [DataMember(Name = "pizza")]
        public Pizza Pizza { get; set; }

        [DataMember(Name = "count")]
        public int Count { get; set; }
    }
}
