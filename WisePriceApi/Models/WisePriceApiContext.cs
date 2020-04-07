using Microsoft.EntityFrameworkCore;
using System;

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
    public DbSet<PostedDeal> PostedDeals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(
          new User {UserId = 1},
          new User {UserId =2}
        );

        modelBuilder.Entity<Location>().HasData(
          new Location {LocationId = 1, Name = "SafeWay", ZipCode = 98015, Address="300 Bellevue Way NE"},
          new Location {LocationId = 2, Name = "QFC", ZipCode = 98004, Address="2636 Bellevue Way NE"},
          new Location {LocationId = 3, Name = "QFC", ZipCode = 98004, Address="1212 Bellevue Way NE"},
          new Location {LocationId = 4, Name = "SafeWay", ZipCode = 98015, Address="1212 Seattle Way NE"}
        );

        modelBuilder.Entity<Item>().HasData(
          new Item {ItemId = 1, ItemName = "Strawberry"},
          new Item {ItemId = 2, ItemName = "Milk"}
        );

        modelBuilder.Entity<Deal>().HasData(
          new Deal {DealId = 1, ItemId = 1, LocationId = 1, UserId = 1,  Price = 20, TimeUpdated = DateTime.Parse("4/3/2020"), UpVotes = 10, DownVotes = 2},
          new Deal {DealId = 2, ItemId = 2, LocationId = 2, UserId = 2,Price = 10, TimeUpdated = DateTime.Parse("4/3/2020"), UpVotes = 8, DownVotes = 1}
        );

        modelBuilder.Entity<PinnedDeal>().HasData(
          new PinnedDeal {PinnedDealId = 1, 
          UserId = 1, DealId = 1},
          new PinnedDeal {PinnedDealId = 2, 
          UserId = 2, DealId = 2}
        );

        modelBuilder.Entity<PostedDeal>().HasData(
          new PostedDeal {PostedDealId = 1, 
          UserId = 1, DealId = 1},
          new PostedDeal {PostedDealId = 2, 
          UserId = 2, DealId = 2}
        );
    }
  }
}