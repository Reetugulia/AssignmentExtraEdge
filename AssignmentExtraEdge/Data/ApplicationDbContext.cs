using AssignmentExtraEdge.Model;
using Microsoft.EntityFrameworkCore;

namespace AssignmentExtraEdge.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<MobilePhones> mobilephone { get; set; }
        public DbSet<Brand> brand { get; set; }
        public DbSet<Sales> Sales { get; set; }
        public  DbSet<SalesReport> SalesReport { get; set; }
    }
}
