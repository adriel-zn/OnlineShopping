using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Data.Entities
{
    [Table("Cart")]
    public  class Cart
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}
