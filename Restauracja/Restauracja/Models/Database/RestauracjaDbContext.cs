using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Restauracja.Models.Database.Entities;

namespace Restauracja.Models.Database
{
    public class RestauracjaDbContext : DbContext
    {
        public DbSet<DaneRestauracji> Restauracjas {  get; set; }
        public DbSet<AdresRestauracji> AdresRestauracji {  get; set; }
        public DbSet<DaniaRestauracji> DaniaRestauracji { get; set; }
        public DbSet<DaneKontaktoweRestauracji> DaneKontaktoweRestauracji { get; set; }
        public DbSet<AplikacjaInformacje> AplikacjaInformacje { get; set; }
        public DbSet<ParametryKonfiguracyjne> ParametryKonfiguracyjne { get; set; }
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

            modelBuilder.Entity<DaneRestauracji>(entity =>
            {
                entity.HasMany(x => x.Adres)
                .WithOne(x => x.DaneRestauracji)
                .HasForeignKey(x => x.RestauracjaId);
            });

            modelBuilder.Entity<DaneRestauracji>(entity =>
            {
                entity.HasMany(x => x.DaniaRestauracji)
                .WithOne(x => x.DaneRestauracji)
                .HasForeignKey(x => x.RestauracjaID);
            });

            modelBuilder.Entity<DaneRestauracji>(entity =>
            {
                entity.HasOne(x => x.DaneKontaktoweRestauracji)
                .WithOne(x => x.DaneRestauracji)
                .HasForeignKey<DaneKontaktoweRestauracji>(d => d.RestauracjaId);
            });

            modelBuilder.Entity<AplikacjaInformacje>(entity =>
            {
                entity.Property(x => x.NazwaAplikacji)
                .IsRequired()
                .HasMaxLength(50);
            });

            modelBuilder.Entity<ParametryKonfiguracyjne>(entity =>
            {
                entity.Property(x => x.CzyWlaczone)
                .IsRequired();

                entity.Property(x => x.DataWlaczenia)
                .IsRequired();

                entity.Property(x => x.Nazwa)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(x => x.Opis)
                .IsRequired()
                .HasMaxLength(500);
            });
        }
    }
}
