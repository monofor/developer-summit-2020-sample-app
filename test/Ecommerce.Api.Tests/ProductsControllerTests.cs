using System;
using System.Collections.Generic;
using Ecommerce.Api.Controllers;
using Ecommerce.Api.Models;
using Ecommerce.Dto;
using Ecommerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Ecommerce.Api.Tests
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductService> _productService;

        public ProductsControllerTests()
        {
            _productService = new Mock<IProductService>();
        }

        [Fact]
        public void Get_ReturnsProductList()
        {
            // Arrange
            var returnData = new ServiceResponse<List<ProductDto>>
            {
                Success = true,
                Message = "Products listed successfully",
                Data = new List<ProductDto>
                {
                    new ProductDto
                    {
                        Code = "iphone",
                        Name = "iPhone 12",
                        Price = 14000
                    }
                }
            };
            _productService.Setup(x => x.GetAll()).Returns(returnData);
            
            // Act
            var controller = new ProductsController(_productService.Object);
            var result = controller.Get();

            // Assert
            var apiResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<ApiData<List<ProductDto>>>(apiResult.Value);

            Assert.True(model.Success);
            Assert.Equal("Products listed successfully", model.Message);
            Assert.Equal(StatusCodes.Status200OK, apiResult.StatusCode);
            Assert.NotNull(model.Data);
            Assert.Single(model.Data);
        }
        
        [Fact]
        public void Get_ReturnsNoProduct()
        {
            // Arrange
            var returnData = new ServiceResponse<List<ProductDto>>
            {
                Success = false,
                Message = "Internal service error"
            };
            _productService.Setup(x => x.GetAll()).Returns(returnData);
            
            // Act
            var controller = new ProductsController(_productService.Object);
            var result = controller.Get();

            // Assert
            var apiResult = Assert.IsType<ObjectResult>(result);
            var model = Assert.IsAssignableFrom<ApiData<object>>(apiResult.Value);

            Assert.False(model.Success);
            Assert.Equal("Internal service error", model.Message);
            Assert.Equal(StatusCodes.Status400BadRequest, apiResult.StatusCode);
            Assert.Null(model.Data);
        }
    }
}