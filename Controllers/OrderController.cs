﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApplication.DbContext;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderCreateDto
    {
        public OrderCreateDto()
        {
            items = new List<OrderItemCreateDto>();
        }

        public List<OrderItemCreateDto> items { get; set; }
    }


    public class OrderItemCreateDto
    {
        public string product {get; set;}

        public int items  {get; set;}
        
        public float maximum_price_per_item  {get; set;}

        public string comment  {get; set;}  
    }


    public class OrderGetDto
    {
        public OrderGetDto()
        {
            items = new List<OrderItemGetDto>();
        }

        public string id {get; set;}

        [JsonProperty]
        public List<OrderItemGetDto> items { get; set; }

    }

    public class OrderItemGetDto : OrderItemCreateDto
    {
        public string id {get; set;}
    }

    public static class OrderExtensions
    {
        public static OrderGetDto CreateGetDto(this Order order)
        {
            return new  OrderGetDto {
                id = order.id
            };
        }

        public static OrderItemGetDto CreateGetItemDto(this OrderItem orderItem)
        {
            return new  OrderItemGetDto {
                id = orderItem.id,
                product = orderItem.product,
                comment = orderItem.comment,
                items = orderItem.items,
                maximum_price_per_item = orderItem.maximum_price_per_item
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
        public async Task<OrderGetDto> Create([FromBody][Required]List<OrderItemCreateDto> createOrderArgs)
        {
            var order = new Order {
                id = $"order_{Guid.NewGuid():N}"
            };

            var orderGetDto = order.CreateGetDto();

            await _context.Orders.AddAsync(order);

            foreach (var singleCreateOrder in createOrderArgs)
            {
                var id = $"orderItem_{Guid.NewGuid():N}";
                var orderItem = new OrderItem
                {
                    order_id = order.id,
                    id = id,
                    product = singleCreateOrder.product,
                    comment = singleCreateOrder.comment,
                    items = singleCreateOrder.items,
                    maximum_price_per_item = singleCreateOrder.maximum_price_per_item
                };

                await _context.OrderItems.AddAsync(orderItem);

                orderGetDto.items.Add(orderItem.CreateGetItemDto());
            }
            await _context.SaveChangesAsync();

            return orderGetDto;
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
