using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Api.Models;
using Ecommerce.Dto;
using Ecommerce.Service;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    public class OrdersController : BaseApiController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var orders = _orderService.GetAll();

            return orders.Success ? Success(orders.Data, orders.Message) : BadRequest<object>(null, orders.Message);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<CreateOrderModel> model)
        {
            var data = model.Select(x => new CreateOrderDto
            {
                ProductId = x.ProductId,
                Quantity = x.Quantity
            }).ToList();

            var orderInfo = _orderService.Create(data);

            return orderInfo.Success ? Success(orderInfo.Data, orderInfo.Message) : BadRequest(Guid.Empty, orderInfo.Message);
        }
    }
}