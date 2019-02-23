using DAL.Services;
using DAL.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL
{
    public static class DALExtentions
    {
        public static IServiceCollection AddDALCollection(this IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("PizzaShop"));

            services.AddScoped<IPizzaOrderService, PizzaOrderService>();

            return services;
        }
    }
}
