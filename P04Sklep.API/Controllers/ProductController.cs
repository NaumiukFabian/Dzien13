using Microsoft.AspNetCore.Mvc;
using P04Sklep.API.Services.ProductService;
using P05Sklep.Shared;

namespace P04Sklep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<Product[]>>> GetProducts()
        {
            var result = await _productService.GetProductAsync();
            return Ok(result);
        }
    }
}
