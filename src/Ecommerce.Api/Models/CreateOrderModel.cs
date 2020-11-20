using System;

namespace Ecommerce.Api.Models
{
    public class CreateOrderModel
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}