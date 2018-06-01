using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreOdata.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.ToTable("Vehicles");
                entity.HasOne(v => v.Model).WithMany(m => m.Vehicles).OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(v => v.Type).WithMany(t => t.Vehicles).OnDelete(DeleteBehavior.ClientSetNull);
                entity.Property(v => v.Color).HasColumnType("VARCHAR(50)");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.ToTable("Models");
                entity.Property(m => m.Name).HasColumnType("VARCHAR(50)");
                entity.HasAlternateKey(m => m.Name);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Types");
                entity.Property(m => m.Name).HasColumnType("VARCHAR(50)");
                entity.HasAlternateKey(m => m.Name);
            });
        }
    }
}
