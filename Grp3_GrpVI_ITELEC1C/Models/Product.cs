using System.ComponentModel.DataAnnotations.Schema;

namespace Grp3_GrpVI_ITELEC1C.Models
{
    [Table("Product")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[]? Photo { get; set; }
        public string? ProductName { get; set; }

        public string? Description {  get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string PesoPrice => Price.ToString("C");
    }
}
