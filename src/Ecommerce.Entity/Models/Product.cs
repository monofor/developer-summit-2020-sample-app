using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.Entity
{
    [Table("Products")]
    public class Product : IBaseModel
    {
        [Key] 
        public Guid ProductId { get; set; }

        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}