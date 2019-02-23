using DAL.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwaggerConferenceTask.Models
{
    public class OrderVM
    {
        public Pizza Pizza { get; set; }

        public int Count { get; set; }
    }
}
