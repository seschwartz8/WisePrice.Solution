using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace WisePriceClient.Models
{
  public class WisePriceClientContextFactory : IDesignTimeDbContextFactory<WisePriceClientContext>
  {

    WisePriceClientContext IDesignTimeDbContextFactory<WisePriceClientContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<WisePriceClientContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new WisePriceClientContext(builder.Options);
    }
  }
}