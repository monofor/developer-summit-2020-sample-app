using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Dto;
using Ecommerce.Entity;
using Ecommerce.Repository;
using Ecommerce.UnitOfWork;
using OrderStatuses = Ecommerce.Dto.OrderStatuses;

namespace Ecommerce.Service.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _uow;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IUnitOfWork uow, IRepository<Product> productRepository)
        {
            _uow = uow;
            _productRepository = productRepository;
        }

        public ServiceResponse<List<OrderDto>> GetAll()
        {
            var orders = _uow.OrderRepository.FindAll(x => x.OrderDetails).ToList();
            var data = new List<OrderDto>();

            foreach (var order in orders)
            {
                var o = new OrderDto
                {
                    OrderId = order.OrderId,
                    TotalPrice = order.TotalPrice,
                    CreatedDate = order.CreatedDate,
                    Status = (OrderStatuses) order.Status,
                    Details = new List<OrderDetailDto>()
                };

                foreach (var orderDetail in order.OrderDetails)
                {
                    var product = _productRepository.FirstOrDefault(x => x.ProductId == orderDetail.ProductId);
                    o.Details.Add(new OrderDetailDto
                    {
                        ProductId = orderDetail.ProductId,
                        Quantity = orderDetail.Quantity,
                        UnitPrice = orderDetail.UnitPrice,
                        TotalPrice = orderDetail.TotalPrice,
                        ProductCode = product.Code,
                        ProductName = product.Name
                    });
                }

                data.Add(o);
            }

            return new ServiceResponse<List<OrderDto>>
            {
                Success = true,
                Message = "Orders listed successfully.",
                Data = data
            };
        }

        public ServiceResponse<Guid> Create(List<CreateOrderDto> data)
        {
            var order = new Order
            {
                CreatedDate = DateTime.UtcNow,
                Status = Entity.OrderStatuses.Created,
                OrderDetails = new List<OrderDetail>()
            };
            var totalOrderPrice = 0d;

            foreach (var orderDetail in data)
            {
                var product = _productRepository.FirstOrDefault(x => x.ProductId == orderDetail.ProductId);
                var totalPrice = product.Price * orderDetail.Quantity;
                var detail = new OrderDetail
                {
                    ProductId = orderDetail.ProductId,
                    Quantity = orderDetail.Quantity,
                    UnitPrice = product.Price,
                    TotalPrice = totalPrice
                };

                totalOrderPrice += totalPrice;

                order.OrderDetails.Add(detail);
            }

            order.TotalPrice = totalOrderPrice;

            _uow.OrderRepository.Add(order);
            _uow.SaveChanges();

            return new ServiceResponse<Guid>
            {
                Success = true,
                Message = "Order created successfully.",
                Data = order.OrderId
            };
        }
    }
}