using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grp3_GrpVI_ITELEC1C.Models
{
    [Table("Admin")]
    public class Admin
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? AdminEmail { get; set; }
        [Required]
        public string? AdminPassword { get; set; }
    }


}