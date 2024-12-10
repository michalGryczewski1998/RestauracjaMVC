using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Restauracja.Models.Database.Entities;

namespace Restauracja.Models.Database
{
    public class RestauracjaDbContext : DbContext
    {
        public DbSet<DaneRestauracji> restauracjas {  get; set; }
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
            modelBuilder.Entity<DaneRestauracji>(entity =>
            {
                entity.Property(x => x.Nazwa)
                        .IsRequired()
                        .HasMaxLength(100);

                entity.Property(x => x.Opis)
                        .HasMaxLength(350)
                        .IsRequired();

                entity.Property(x => x.GodzinaOtwarcia)
                        .IsRequired();

                entity.Property(x => x.GodzinaZamkniecia)
                        .IsRequired();

                entity.Property(x => x.CzasOtwarcia)
                        .IsRequired();

                entity.Property(x => x.CzyDostawa)
                        .IsRequired();
            });               
        }
    }
}
