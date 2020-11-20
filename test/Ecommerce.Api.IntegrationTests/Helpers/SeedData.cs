using System;
using System.Collections.Generic;
using Ecommerce.Data;
using Ecommerce.Entity;

namespace Ecommerce.Api.IntegrationTests
{
    public static class SeedData
    {
        public static void Seed(EcommerceContext dbContext)
        {
            var products = new List<Product>
            {
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Code = "iPhone",
                    Name = "iPhone 12",
                    Price = 14000
                },
                new Product
                {
                    ProductId = Guid.NewGuid(),
                    Code = "macbook",
                    Name = "Macbook Pro 16'",
                    Price = 34000
                }
            };

            dbContext.Products.AddRange(products);
            dbContext.SaveChanges();
        }
    }
}