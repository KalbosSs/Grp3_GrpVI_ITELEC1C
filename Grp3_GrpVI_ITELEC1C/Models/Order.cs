using System.ComponentModel.DataAnnotations.Schema;

namespace Grp3_GrpVI_ITELEC1C.Models
{
    [Table("Orders")]
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? CustomerName{ get; set; }
        public string? OrderDetails { get; set; }
        public decimal TotalOrders { get; set; }     
    }


}