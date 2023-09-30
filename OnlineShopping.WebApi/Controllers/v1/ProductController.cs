using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShopping.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IList<dynamic> GetAllProducts()
        {
             throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public dynamic GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        [HttpGet("categories")]
        public dynamic GetAllProductCategories()
        {
            throw new NotImplementedException();
        }

        [HttpGet("category/{id}")]
        public dynamic GetProductByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
    }
}
