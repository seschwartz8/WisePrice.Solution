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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<User>().HasData(
        new User {UserId = 1, FirstName = "jiwon", LastName = "han", Email = "carpediemjiwon@gmail.com", Zip = "98004", Password = 2067715},
        new User {UserId =2, FirstName = "sewon", LastName = "han", Email = "carpediemsewon@gmail.com", Zip = "98004", Password = 2067715}
        );

        modelBuilder.Entity<Location>().HasData(
        new Location {LocationId = 1, Name = "SafeWay", ZipCode = 98015, Address=""},
        new Location {LocationId = 2, Name = "QFC", ZipCode = 98004, Address=""}
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
    }
  }
}