using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Ecommerce.Api.Models;
using Ecommerce.Dto;
using Newtonsoft.Json;
using Xunit;

namespace Ecommerce.Api.IntegrationTests
{
	public class ProductsControllerTests : IClassFixture<CustomFactory<Startup>>
	{
		private readonly HttpClient _client;

		public ProductsControllerTests(CustomFactory<Startup> factory)
		{
			_client = factory.CreateClient();
		}

		[Fact]
		public async Task GetProductList()
		{
			var httpResponse = await _client.GetAsync("products");

			httpResponse.EnsureSuccessStatusCode();

			var stringResponse = await httpResponse.Content.ReadAsStringAsync();
			var response = JsonConvert.DeserializeObject<ApiData<List<ProductDto>>>(stringResponse);

			Assert.True(response.Success);
			Assert.Equal("Products listed successfully.", response.Message);
			Assert.NotNull(response.Data);
			Assert.Contains(response.Data, p => p.Code == "iPhone");
		}

		[Fact]
		public async Task ReturnsError()
		{
			var httpResponse = await _client.GetAsync("product-orders");

			Assert.Equal(HttpStatusCode.NotFound, httpResponse.StatusCode);
		}
	}
}