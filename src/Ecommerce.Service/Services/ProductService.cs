using System.Collections.Generic;
using System.Linq;
using Ecommerce.Dto;
using Ecommerce.UnitOfWork;

namespace Ecommerce.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ServiceResponse<List<ProductDto>> GetAll()
        {
            var products = _uow.ProductRepository.FindAll().Select(x => new ProductDto
            {
                ProductId = x.ProductId,
                Code = x.Code,
                Name = x.Name,
                Price = x.Price
            }).ToList();

            return new ServiceResponse<List<ProductDto>>
            {
                Success = true,
                Message = "Products listed successfully.",
                Data = products
            };
        }
    }
}