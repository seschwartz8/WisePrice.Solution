using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WisePriceClient.Models
{
  public class WisePriceClientContext : IdentityDbContext<ApplicationUser>
  {
    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    public WisePriceClientContext(DbContextOptions<WisePriceClientContext> options) : base(options) { }
  }
}