using System.ComponentModel.DataAnnotations.Schema;

namespace Grp3_GrpVI_ITELEC1C.Models
{
    [Table("Product")]
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? Description {  get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string PhotoFile {  get; set; } //To store file name
        public string PhotoPath { get; set; } // to store the virtual path

        public string PesoPrice => Price.ToString("C");

        [NotMapped]
        public IFormFile Photo { get; set; }
    }
    

}
