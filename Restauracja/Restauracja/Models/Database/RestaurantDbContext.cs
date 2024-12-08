using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Restauracja.Models.Database
{
    public class RestaurantDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            var daneDoLogowania = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration configuration = daneDoLogowania.Build();

            string connection = configuration["ConnectionStrings:Default"] ?? string.Empty;

            builder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
