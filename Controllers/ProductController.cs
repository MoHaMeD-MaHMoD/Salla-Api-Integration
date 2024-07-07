using Microsoft.AspNetCore.Mvc;
using SallaIntegration.Models;
using SallaIntegration.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ProductController(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    [HttpGet("products")]
    public async Task<ActionResult<List<ProductJsonResponse.Datum>>> GetProducts()
    {
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            var serviceProvider = scope.ServiceProvider;
            var productApiClientService = serviceProvider.GetRequiredService<ProductApiClientService>();

            var products = await productApiClientService.GetProductsAsync();
            return Ok(products);
        }
    }
}
