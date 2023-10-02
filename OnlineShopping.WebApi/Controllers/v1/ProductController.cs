using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Data.Entities;
using OnlineShopping.Infrastructure.Interfaces;
using OnlineShopping.WebApi.Models;

namespace OnlineShopping.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductController(ILogger<ProductController> logger,
            IMapper mapper,
            IProductRepository productRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productRepository = productRepository;
        }

        #region GET: api/products
        [HttpGet]
        public async Task<IList<ProductModel>> GetAllProducts()
        {
            var entity = await _productRepository.GetAll();
            return _mapper.Map<IList<ProductModel>>(entity);
        }
        #endregion

        #region GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<ProductModel> GetProductById(int id)
        {
            var entity = await _productRepository.GetById(id);
            return _mapper.Map<ProductModel>(entity);
        }
        #endregion

        #region GET: api/products/categories
        [HttpGet("categories")]
        public dynamic GetAllProductCategories()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region GET: api/products/category/{categoryId}
        [HttpGet("category/{categoryId}")]
        public dynamic GetProductByCategory(int categoryId)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region POST: api/products
        [HttpPost]
        public async Task<ProductModel> CreateProduct(ProductModel model)
        {
            var product = _mapper.Map<Product>(model);
            
            await _productRepository.Create(product);

            return _mapper.Map<ProductModel>(product);

        }
        #endregion

        #region PUT: api/products
        [HttpPut]
        public async Task<ProductModel> UpdateProduct(ProductModel model)
        {
            var product = _mapper.Map<Product>(model);

            await _productRepository.Update(product);

            return _mapper.Map<ProductModel>(product);
        }
        #endregion

        #region DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task DeleteProduct(int id)
        {
            await _productRepository.Delete(id);
        }
        #endregion
    }
}
