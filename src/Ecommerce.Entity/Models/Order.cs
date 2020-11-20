using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity
{
    [Table("Orders")]
    public class Order : IBaseModel
    {
        [Key] 
        public Guid OrderId { get; set; }

        public DateTime CreatedDate { get; set; }
        public double TotalPrice { get; set; }
        public OrderStatuses Status { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }

    public enum OrderStatuses
    {
        Created,
        Shipping,
        Shipped,
        Completed
    }
}