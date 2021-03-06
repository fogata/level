using Level.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Level.Persistance
{
    public class LevelDbContext : DbContext
    {
        public LevelDbContext(DbContextOptions<LevelDbContext> options)
            : base(options)
        { }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Articles> Articles { get; set; }
        public DbSet<Delivery> Deliveries{ get; set; }
        public DbSet<Discount> Discounts{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(p =>
            {
                p.ToTable("Cart");
                p.HasKey("id");
                p.Property(p => p.articleId).HasColumnType("int");
                p.Property(p => p.userId).HasColumnType("uniqueidentifier");
                p.Property(p => p.quantity).HasColumnType("int");
            });

            modelBuilder.Entity<Articles>(p =>
            {
                p.ToTable("Article");
                p.HasKey("id");
                p.Property(p => p.name).HasColumnType("varchar(50)");
                p.Property(p => p.name).IsRequired();
                p.Property(p => p.price).HasColumnType("decimal(10,2)");
                p.Property(p => p.price).IsRequired();
            });

            modelBuilder.Entity<Delivery>(p =>
            {
                p.ToTable("Delivery");
                p.HasKey("id");
                p.Property(p => p.maxPrice).HasColumnType("decimal(10,2)").IsRequired();
                p.Property(p => p.minPrice).HasColumnType("decimal(10,2)").IsRequired();
                p.Property(p => p.price).HasColumnType("decimal(10,2)").IsRequired();
            });

            modelBuilder.Entity<Discount>(p =>
            {
                p.ToTable("Discount");
                p.HasKey("id");
                p.Property(p => p.userId).HasColumnType("uniqueidentifier").IsRequired();
                p.Property(p => p.articleId).HasColumnType("int").IsRequired();
                p.Property(p => p.type).HasColumnType("varchar(250)").IsRequired();
                p.Property(p => p.total).HasColumnType("int").IsRequired();
            });

        }
    }
}
