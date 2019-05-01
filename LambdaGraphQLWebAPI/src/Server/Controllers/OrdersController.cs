using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Orders.Models;
using Orders.Services;

namespace LambdaGraphQLWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Get()
        {
            var orders = await orderService.GetOrdersAsync();
            return Ok(orders);
        }
    }
}