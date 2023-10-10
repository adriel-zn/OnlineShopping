using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.WebApi.Models;

namespace OnlineShopping.WebApi.Controllers.v1
{
    [ApiController]
    [Route("api/carts")]
    public class CartController : ControllerBase
    {
        private readonly ILogger<CartController> _logger;

        public CartController(ILogger<CartController> logger)
        {
            _logger = logger;
        }

        #region GET: api/carts/user/{userId}
        [HttpGet("user/{userId}")]
        public IList<CartModel> GetCartsForUser(int userId)
        {
            return new List<CartModel>();
        }
        #endregion
    }
}
