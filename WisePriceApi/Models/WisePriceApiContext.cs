using Microsoft.EntityFrameworkCore;

namespace WisePriceApi.Models
{
  public class WisePriceApiContext : DbContext
  {
    public WisePriceApiContext(DbContextOptions<WisePriceApiContext> options)
      : base(options)
    {
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Deal> Deals { get; set; }
    public DbSet<PinnedDeal> PinnedDeals { get; set; }
  }
}