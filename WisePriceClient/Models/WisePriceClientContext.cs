using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WisePriceClient.Models
{
  public class WisePriceClientContext : IdentityDbContext<ApplicationUser>
  {

    public WisePriceClientContext(DbContextOptions<WisePriceClientContext> options) : base(options) { }
  }
}