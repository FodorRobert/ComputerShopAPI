using Microsoft.EntityFrameworkCore;

namespace ComputerShopAPI.Models
{
    public class CMPShopDbContext : DbContext
    {
        public CMPShopDbContext(DbContextOptions<CMPShopDbContext> options) : base(options)
        {
        }
        public CMPShopDbContext()
        {
        }

        public DbSet<Osystem> Osystems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseMySQL("server=localhost;user=root;password=;database=computer");
        }
    }
}
