using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
                : base(options)
        {
        }

        public DbSet<Order> Order { get; set; }

        public DbSet<PizzaOrder> PizzaOrders { get; set; }
    }
}
