using Level.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Level.Persistance
{
    public class LevelDbContext : DbContext
    {
        public LevelDbContext(DbContextOptions<LevelDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(p =>
            {
                p.ToTable("Cart");
                p.HasKey("id");
                p.Property(p => p.userId).HasColumnType("uniqueidentifier");
                p.HasMany(p => p.items)
                .WithOne(b => b.cart)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
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

            modelBuilder.Entity<ArticleItem>(p =>
            {
                p.ToTable("ArticleItem");
                p.HasKey("id");
                p.Property(p => p.quantity).HasColumnType("int");
                p.Property(p => p.quantity).HasDefaultValue(1).IsRequired();
                p.Property(p => p.discount).HasColumnType("decimal(10,2)").IsRequired();
                p.Property(p => p.discountType).HasColumnType("varchar(50)");
            });

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Articles> Articles { get; set; }

        public DbSet<ArticleItem> items { get; set; }
    }
}
