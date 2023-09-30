namespace OnlineShopping.WebApi.Models
{
    public class ProductModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; } 
        public decimal Price { get; set; }
        public int ProductCategoryId { get; set; }
        public byte[]? Image { get; set; }

        public ProductCategoryModel ProductCategory { get; set; }
    }
}
