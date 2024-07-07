using Newtonsoft.Json;
using SallaIntegration.Models;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace SallaIntegration.Services
{
    public class ProductApiClientService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProductApiClientService(HttpClient httpClient, IHttpContextAccessor httpContextAccessor)
        {
            _httpClient = httpClient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ProductJsonResponse.Datum>> GetProductsAsync()
        {
            var accessToken = _httpContextAccessor.HttpContext.Items["AccessToken"]?.ToString();
            if (!string.IsNullOrEmpty(accessToken))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
            }

            var allProducts = new List<ProductJsonResponse.Datum>();
            int currentPage = 1;
            int totalPages;

            do
            {
                var response = await _httpClient.GetAsync($"https://api.salla.dev/admin/v2/products?page={currentPage}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"Error fetching products: {response.ReasonPhrase}");
                }

                var json = await response.Content.ReadAsStringAsync();
                var productResponse = JsonConvert.DeserializeObject<ProductJsonResponse.Root>(json);

                if (productResponse != null && productResponse.data != null)
                {
                    allProducts.AddRange(productResponse.data);
                }

                totalPages = productResponse?.pagination?.totalPages ?? 1;
                currentPage++;
            } while (currentPage <= totalPages);

            return allProducts;
        }
    }
}
