namespace OnlineShopping.WebApi.Models
{
    public class CartModel: BaseModel
    {
        public int UserId { get; set; }
        public DateTime AddedDate { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductModel Product { get; set; }
    }
}
