using DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class PizzaOrder
    {
        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Pizza Pizza { get; set; }

        public int Count { get; set; }

    }
}
