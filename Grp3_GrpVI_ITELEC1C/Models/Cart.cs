using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grp3_GrpVI_ITELEC1C.Models
{
    [Table("Cart")]
    public class Cart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
      
        public string ProductName { get; set; }

        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

        public int Stock { get; set; }
        public int Quantity { get; set; }
        public string PhotoPath { get; set; }

    }
}
