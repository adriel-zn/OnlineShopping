using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Entities
{
    [Table("ProductRating")]
    public class ProductRating
    {
        [Key]
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public int Count { get; set; }
    }
}
