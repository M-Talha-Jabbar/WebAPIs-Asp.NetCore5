using ConsoleToWebAPI.Models;
using ConsoleToWebAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleToWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost("")]
        public IActionResult AddProduct([FromBody]ProductModel model)
        {
            _productRepository.AddProduct(model);

            var products = _productRepository.GetAllProducts();

            return Ok(products);
        }

        [HttpGet("")]
        public string GetName()
        {
            var name = _productRepository.GetName();
            return name;
        }
    }
}
