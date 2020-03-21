using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.DbContext;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CreateOrderDto
    {
        public string id {get; set;}

        public string product {get; set;}

        public int items  {get; set;}
        
        public float maximum_price_per_item  {get; set;}

        public string comment  {get; set;}  
    }

    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<OrderController> _logger;
        private readonly MariaContext _context;


        public OrderController(
            MariaContext context,
            ILogger<OrderController> logger)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost]
        public async Task<string> Create([FromBody][Required]CreateOrderDto createOrderArgs)
        {
            await Task.CompletedTask;

            var id = $"order_{Guid.NewGuid():N}";
            _context.Orders.Add(
                new Order {
                    id = id,
                    product = createOrderArgs.product,
                    comment = createOrderArgs.comment,
                    items = createOrderArgs.items,
                    maximum_price_per_item = createOrderArgs.maximum_price_per_item
                });
            await _context.SaveChangesAsync();

            return "coming_soon";
        }
    }
}
