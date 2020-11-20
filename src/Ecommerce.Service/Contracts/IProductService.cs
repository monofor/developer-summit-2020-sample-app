using System.Collections.Generic;
using Ecommerce.Dto;

namespace Ecommerce.Service
{
    public interface IProductService
    {
        ServiceResponse<List<ProductDto>> GetAll();
    }
}