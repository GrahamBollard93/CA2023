using Microsoft.EntityFrameworkCore;
using PhonesApi.Model;
namespace PhonesApi.Data;
public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new PhonesDbContext(
        serviceProvider.GetRequiredService<
        DbContextOptions<PhonesDbContext>>()))
        {
            // Look for any movies.
            if (context.Phone.Any())
            {
                return; // DB has been seeded
            }
            context.Phone.AddRange(
            new Phones
            {
                Id = 1,
                Brand = "Samsung",
                Model = "Galaxy",
                Price =
            Convert.ToDecimal(12.99)
            },
            new Phones
            {
               Id = 2,
                Brand = "Samsung",
                Model = "Galaxy",
                Price =
            Convert.ToDecimal(15.99)
            }
            );
            context.SaveChanges();
        }
    }
}