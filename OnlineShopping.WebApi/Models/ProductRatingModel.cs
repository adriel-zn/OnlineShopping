namespace OnlineShopping.WebApi.Models
{
    public class ProductRatingModel : BaseModel
    {
        public decimal Rate { get; set; }
        public int Count { get; set; }
    }
}
