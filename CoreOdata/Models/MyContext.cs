using Microsoft.EntityFrameworkCore;

namespace CoreOdata.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        //public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Item> Items { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items");
                entity.HasMany(i => i.Notes).WithOne(n => n.Item);
                entity.Property(i => i.Description).HasColumnType("VARCHAR(100)");
                entity.Property(i => i.RetailPrice).HasColumnType("DECIMAL(12,2)");
                entity.Property(i => i.AquiredDate).HasColumnType("DATETIMEOFFSET(0)");
            });

            modelBuilder.Entity<Note>(entity =>
            {
                entity.ToTable("Notes");
                entity.Property(n => n.Detail).HasColumnType("VARCHAR(1000)");
            });

            //modelBuilder.Entity<Vehicle>(entity =>
            //{
            //    entity.ToTable("Vehicles");
            //    entity.HasOne(v => v.Model).WithMany(m => m.Vehicles).OnDelete(DeleteBehavior.ClientSetNull);
            //    entity.HasOne(v => v.Type).WithMany(t => t.Vehicles).OnDelete(DeleteBehavior.ClientSetNull);
            //    entity.Property(v => v.Color).HasColumnType("VARCHAR(50)");
            //});

            //modelBuilder.Entity<Model>(entity =>
            //{
            //    entity.ToTable("Models");
            //    entity.Property(m => m.Name).HasColumnType("VARCHAR(50)");
            //    entity.HasAlternateKey(m => m.Name);
            //});

            //modelBuilder.Entity<Type>(entity =>
            //{
            //    entity.ToTable("Types");
            //    entity.Property(m => m.Name).HasColumnType("VARCHAR(50)");
            //    entity.HasAlternateKey(m => m.Name);
            //});
        }
    }
}
