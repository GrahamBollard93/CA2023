using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcPhones.Models;
using Microsoft.AspNetCore.Identity;


namespace MvcPhones.Data
{
    public class MvcPhonesDbContext : IdentityDbContext<IdentityUser>
    {


        public MvcPhonesDbContext(DbContextOptions<MvcPhonesDbContext> options)
            : base(options)
        {
        }

        public object Phone { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        base.OnModelCreating(builder);
        }
    }
}