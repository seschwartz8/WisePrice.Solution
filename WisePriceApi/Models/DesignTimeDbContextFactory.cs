using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace WisePriceApi.Models
{
  public class WisePriceApiContextFactory : IDesignTimeDbContextFactory<WisePriceApiContext>
  {

    WisePriceApiContext IDesignTimeDbContextFactory<WisePriceApiContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<WisePriceApiContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new WisePriceApiContext(builder.Options);
    }
  }
}