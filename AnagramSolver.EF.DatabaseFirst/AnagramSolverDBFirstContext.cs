using Microsoft.EntityFrameworkCore;
using System;
using AnagramSolver.Contracts;

namespace AnagramSolver.EF.DatabaseFirst
{
    public class AnagramSolverDBFirstContext : DbContext
    {
        private readonly string connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;" +
            "Integrated Security = true;Uid=auth_windows";
        public virtual DbSet<WordModel> Word { get; set; }
        public virtual DbSet<UserLog> UserLog { get; set; }
        public virtual DbSet<CachedWord> CachedWord { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordModel>(entity =>
            {
                entity.Property(e => e.Word)
                .HasColumnName("Word")
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

                entity.Property(e => e.Category)
                .HasColumnName("Category")
                .HasColumnType("nvarchar")
                .HasMaxLength(255);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.Property(e => e.UserIp)
                .HasColumnName("UserIp")
                .HasColumnType("nvarchar");

                entity.Property(e => e.SearchWordId)
                .HasColumnName("Category")
                .HasColumnType("nvarchar")
                .HasMaxLength(255);

            });
        }
    }
}
