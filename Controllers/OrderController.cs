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
    public class OrderCreateDto
    {
        public string product {get; set;}

        public int items  {get; set;}
        
        public float maximum_price_per_item  {get; set;}

        public string comment  {get; set;}  
    }

    public class OrderGetDto : OrderCreateDto
    {
        public string id {get; set;}
    }

    public static class OrderExtensions
    {
        public static OrderGetDto CreateGetDto(this Order order)
        {
            return new  OrderGetDto {
                id = order.id,
                product = order.product,
                comment = order.comment,
                items = order.items,
                maximum_price_per_item = order.maximum_price_per_item
            };
        }
    }


    [ApiController]
    [Route("order")]
    public class OrderController : ControllerBase
    {
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
        public async Task<List<Order>> Create([FromBody][Required]List<OrderCreateDto> createOrderArgs)
        {
            List<Order> orders = new List<Order>();


            foreach (var singleCreateOrder in createOrderArgs)
            {
                var id = $"order_{Guid.NewGuid():N}";
                var order = new Order
                {
                    id = id,
                    product = singleCreateOrder.product,
                    comment = singleCreateOrder.comment,
                    items = singleCreateOrder.items,
                    maximum_price_per_item = singleCreateOrder.maximum_price_per_item
                };


                _context.Orders.Add(order);
                orders.Add(order);
            }
           
            await _context.SaveChangesAsync();

            return orders;
        }

        [HttpGet]
        public ActionResult<IEnumerable<OrderGetDto>> Get()
        {
            return _context.Orders.ToList().Select(_ => _.CreateGetDto()).ToArray();
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<IEnumerable<OrderGetDto>> Get(string id)
        {
            var foundOrder = _context.Orders.FirstOrDefault(_ => _.id == id);
            if (foundOrder != null)
            {
                return new [] { foundOrder.CreateGetDto() };
            }
            return BadRequest();
        }
    }
}
