using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SwaggerConferenceTask.Models;
using SwaggerConferenceTask.Services;

namespace SwaggerConferenceTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            this.pizzaService = pizzaService;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<PizzaVM>> Get()
        {
            return Ok(this.pizzaService.GetPizzas());
        }

        [HttpGet("orders")]
        public ActionResult<IEnumerable<OrderResponseForList>> GetOrders()
        {
            return Ok(this.pizzaService.GetOrders());
        }


        [HttpPost("setOrder")]
        public async Task<ActionResult<OrderResponse>> SetOrder(OrderVM order)
        {
            return Ok(await this.pizzaService.SetOrderAsync(order.Orders));
        }

        [HttpPost("confirmOrder/{orderNum:int}")]
        public Task ConfirmOrder(int orderNum)
        {
            return this.pizzaService.ConfirmOrderAsync(orderNum);
        }

        [HttpPost("cancelOrder/{orderNum:int}")]
        public Task CancelOrder(int orderNum)
        {
            return this.pizzaService.CancelOrderAsync(orderNum);
        }
    }
}
