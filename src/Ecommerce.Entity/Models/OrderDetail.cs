using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity
{
    [Table("OrderDetails")]
    public class OrderDetail : IBaseModel
    {
        [Key] 
        public Guid OrderDetailId { get; set; }

        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public virtual Product Product { get; set; }
    }
}