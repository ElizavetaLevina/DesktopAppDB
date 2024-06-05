using Microsoft.EntityFrameworkCore;
using System.Net;

namespace WinFormsApp1.Model
{
    public class Context : DbContext
    {
        public string path = Properties.Settings.Default.PathDB;
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Master> Masters => Set<Master>();
        public DbSet<TypeTechnic> TypeTechnices => Set<TypeTechnic>();
        public DbSet<BrandTechnic> BrandTechnices => Set<BrandTechnic>();
        public DbSet<Order> Orders => Set<Order>();
        public DbSet<Details> Details => Set<Details>();
        public DbSet<Warehouse> Warehouse => Set<Warehouse>();
        public DbSet<TypeBrand> TypeBrands => Set<TypeBrand>();
        public DbSet<Malfunction> Malfunctions => Set<Malfunction>();
        public DbSet<MalfunctionOrder> MalfunctionOrders => Set<MalfunctionOrder>();
        public Context() => Database.EnsureCreatedAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandTechnic>().HasIndex(n => n.NameBrandTechnic).IsUnique();
            modelBuilder.Entity<TypeTechnic>().HasIndex(n => n.NameTypeTechnic).IsUnique();
            modelBuilder.Entity<Malfunction>().HasIndex(n => n.Name).IsUnique();

            modelBuilder.Entity<Order>()
                .HasOne(b => b.Master)
                .WithMany(a => a.Order)
                .HasForeignKey(b => b.MasterId);

            modelBuilder.Entity<Order>()
                .HasOne(b => b.Client)
                .WithMany(a => a.Order)
                .HasForeignKey(b => b.ClientId);

            modelBuilder.Entity<Order>()
                .HasOne(b => b.BrandTechnic)
                .WithMany(a => a.Order)
                .HasForeignKey(b => b.BrandTechnicId);

            modelBuilder.Entity<Order>()
                .HasOne(b => b.TypeTechnic)
                .WithMany(a => a.Order)
                .HasForeignKey(b => b.TypeTechnicId);

            modelBuilder.Entity<BrandTechnic>()
                .HasMany(b => b.TypeTechnics)
                .WithMany(a => a.BrandTechnics)
                .UsingEntity<TypeBrand>(
                    c => c
                    .HasOne(de => de.TypeTechnic)
                    .WithMany(e => e.TypeBrands)
                    .HasForeignKey(de => de.TypeTechnicsId),
                    c => c
                    .HasOne(de => de.BrandTechnic)
                    .WithMany(d => d.TypeBrands)
                    .HasForeignKey(de => de.BrandTechnicsId),
                    c =>
                    {
                        c.HasKey(e => new { e.TypeTechnicsId, e.BrandTechnicsId });
                        c.ToTable("TypeBrand");
                    });

            modelBuilder.Entity<Malfunction>()
                .HasMany(b => b.Orders)
                .WithMany(a => a.Malfunction)
                .UsingEntity<MalfunctionOrder>(
                    c => c
                    .HasOne(de => de.Order)
                    .WithMany(e => e.MalfunctionOrders)
                    .HasForeignKey(de => de.OrderId),
                    c => c
                    .HasOne(de => de.Malfunction)
                    .WithMany(d => d.MalfunctionOrders)
                    .HasForeignKey(de => de.MalfunctionId),
                    c =>
                    {
                        c.Property(de => de.Price).HasDefaultValue(0);
                        c.HasKey(e => new { e.MalfunctionId, e.OrderId });
                        c.ToTable("MalfunctionOrder");
                    });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                optionsBuilder.UseSqlite(String.Format("Data Source={0};Pooling=false", path));
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }



    } 
}
