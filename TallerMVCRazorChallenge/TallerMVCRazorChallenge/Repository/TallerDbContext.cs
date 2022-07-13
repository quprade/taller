using Microsoft.EntityFrameworkCore;
using TallerMVCRazorChallenge.Models;

namespace TallerMVCRazorChallenge.Repository
{
    public class TallerDbContext:DbContext
    {
        public TallerDbContext(DbContextOptions<TallerDbContext> options) : base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
