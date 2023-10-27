using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    {
    }
    
    // nested inside ParksApiContext class
    // 'protected' b/c accessible to the class itself; 'override' to override default method
    protected override void OnModelCreating(ModelBuilder builder) // redefining how OnModelCreating() method works
    { 
      builder.Entity<Park>() // call on builder's Entity<Type>(), which returns an EntityTypeBuilder object; allow us to configure the type specified
        .HasData( // call EntityTypeBuilder's HasData() method, passing in any number of entries we'd like to seed database with.
          new Park { ParkId = 1, Name = "Crater Lake", Description = "Crater Lake inspires awe.", Fee = 30, Status = "open", CampingAllowed = "yes", DogsAllowed = "yes"},
          new Park { ParkId = 2, Name = "Agate Beach State Recreation Site", Description = "No agates, but a great place to see the sunset.", Fee = 0, Status = "open", CampingAllowed = "yes", DogsAllowed = "yes"},
          new Park { ParkId = 3, Name = "Fogarty Creek State Recreation Area", Description = "This park has great birdwatching and tidepools to explore.", Fee = 0, Status = "open", CampingAllowed = "yes", DogsAllowed = "yes" },
          new Park { ParkId = 4, Name = "Oregon Caves National Monument", Description = "Eons of acidic water seeping into marble rock created and decorated these wondrous marble halls.", Fee = 5, Status = "closed", CampingAllowed = "no", DogsAllowed = "no"},
          new Park { ParkId = 5, Name = "John Day Fossil Beds National Monument", Description = "Colorful rock formations preserve a world class record of plant and animal evolution, changing climate, and past ecosystems that span over 40 million years.", Fee = 0, Status = "open", CampingAllowed = "no", DogsAllowed = "no"},
          new Park { ParkId = 6, Name = "Cascade-Siskiyou National Monument", Description = "This convergence of three geologically distinct mountain ranges has resulted in an area with unparalleled biological diversity and a tremendously varied landscape.", Fee = 0, Status = "open", CampingAllowed = "yes", DogsAllowed = "yes" }
        );
    }    
  }
}