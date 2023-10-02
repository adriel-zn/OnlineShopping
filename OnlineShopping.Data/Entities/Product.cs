using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int ProductCategoryId { get; set; }
        //[Required]
        public int ProductRatingId { get; set; }

        public byte[]? Image { get; set; } = null;


        public ProductCategory ProductCategory { get; set; }
        public ProductCategory ProductRating { get; set; }
    }
}
