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
                Price = 1200,
                ImageUrl = "https://images.samsung.com/is/image/samsung/p6pim/ie/sm-a546blvceub/gallery/ie-galaxy-a54-5g-sm-a546-sm-a546blvceub-535797498?$650_519_PNG$",
                Description = "Brand New Phone"
            },
            
            new Phones
            {
                Id = 2,
                Brand = "Samsung",
                Model = "Galaxy",
                Price = 1200,
                ImageUrl = "https://images.samsung.com/is/image/samsung/p6pim/ie/sm-a546blvceub/gallery/ie-galaxy-a54-5g-sm-a546-sm-a546blvceub-535797498?$650_519_PNG$",
                Description = "Brand New Phone"

            }
            );
            context.SaveChanges();
        }
    }
}