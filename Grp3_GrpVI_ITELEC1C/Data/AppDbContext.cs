using Grp3_GrpVI_ITELEC1C.Models;
using Microsoft.EntityFrameworkCore;

namespace Grp3_GrpVI_ITELEC1C.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
