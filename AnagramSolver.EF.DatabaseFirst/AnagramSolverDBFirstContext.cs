using Microsoft.EntityFrameworkCore;
using System;
using AnagramSolver.Contracts.Entities;

namespace AnagramSolver.EF.DatabaseFirst
{
    public class AnagramSolverDBFirstContext : DbContext
    {
        private readonly string connectionString = "Server=LT-LIT-SC-0513;Database=AnagramSolver;" +
            "Integrated Security = true;Uid=auth_windows";
        public virtual DbSet<WordEntity> Word { get; set; }
        public virtual DbSet<UserLogEntity> UserLog { get; set; }
        public virtual DbSet<CachedWordEntity> CachedWord { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WordEntity>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

                entity.Property(e => e.Word)
                .HasColumnName("Word")
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

                entity.Property(e => e.Category)
                .HasColumnName("Category")
                .HasColumnType("nvarchar")
                .HasMaxLength(255)
                .IsRequired();

                entity.HasKey(e => e.Id);

            });

            modelBuilder.Entity<UserLogEntity>(entity =>
            {
                entity.Property(e => e.UserIp)
                .HasColumnName("UserIp")
                .HasColumnType("nvarchar");

                entity.Property(e => e.SearchWordId)
                .HasColumnName("Category")
                .HasColumnType("int");

                entity.Property(e => e.SearchTime)
                .HasColumnName("SearchTime")
                .HasColumnType("datetime");

            });

            modelBuilder.Entity<CachedWordEntity>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();

                entity.Property(e => e.SearchWord)
                .HasColumnName("SearchWord")
                .HasColumnType("nvarchar")
                .IsRequired();

                entity.Property(e => e.AnagramWordId)
                .HasColumnName("AnagramWordId")
                .HasColumnType("int")
                .IsRequired();

                entity.HasKey(e => e.Id);
                //entity.HasOne(d => d.WordModel)
                //.WithOne(p => p.CachedWord)
                //.HasForeignKey<CachedWord>(d => d.WordId);

            });
        }
    }
}
