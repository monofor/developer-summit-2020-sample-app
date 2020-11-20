using System;
using System.Collections.Generic;
using Ecommerce.Dto;

namespace Ecommerce.Service
{
    public interface IOrderService
    {
        ServiceResponse<List<OrderDto>> GetAll();
        ServiceResponse<Guid> Create(List<CreateOrderDto> data);
    }
}