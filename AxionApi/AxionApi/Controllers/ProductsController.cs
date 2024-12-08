using AxionApi.Domain.DTOs;
using AxionApi.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AxionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateDto request)
        {
            var result = await _productService.CreateProduct(request);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromForm] ProductUpdateDto request)
        {
            var result = await _productService.UpdateProduct(id, request);
            if (result == "Product not found.")
                return NotFound();
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var result = await _productService.DeleteProduct(id);
            if (result == "Product not found.")
                return NotFound();
            return Ok(result);
        }
    }
}
