using System;

namespace Ecommerce.Dto
{
    public class ProductDto
    {
        public Guid ProductId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}