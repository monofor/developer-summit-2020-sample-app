using System;
using System.Collections.Generic;

namespace Ecommerce.Dto
{
    public class OrderDto
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedDate { get; set; }
        public OrderStatuses Status { get; set; }
        public string StatusText => Status.ToString();
        public double TotalPrice { get; set; }
        public List<OrderDetailDto> Details { get; set; }
    }

    public class OrderDetailDto
    {
        public Guid ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }

    public enum OrderStatuses
    {
        Created,
        Shipping,
        Shipped,
        Completed
    }
}