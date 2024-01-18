using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Entity.DTO;
using Product.Service.Service;

namespace Product.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost(Name = "AddProduct")]
        public IActionResult AddProduct(ProductDTO product)
        {
            var result = _productService.Add(product);
            return Ok(result);
        }
    }
}
