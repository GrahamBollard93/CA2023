using Microsoft.EntityFrameworkCore;
using PhonesApi.Model;

namespace PhonesApi.Data
{
    public class PhonesDbContext : DbContext
    {
        public PhonesDbContext (DbContextOptions<PhonesDbContext> options) :
        base (options)

        {}

        public DbSet<Phones> Phone { get; set; } = null!;
    
    }
}