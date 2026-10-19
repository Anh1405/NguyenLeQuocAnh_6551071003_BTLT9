using System;
using Microsoft.EntityFrameworkCore;

namespace Bai1_Chuong11.Models
{
    public class ChiTieu
    {
        public int MaCT { get; set; }
        public DateTime NgayChi { get; set; }
        public string NoiDung { get; set; } = string.Empty;
        public decimal SoTien { get; set; }
        public string LoaiChi { get; set; } = string.Empty;
        public string? GhiChu { get; set; }
    }

    public class QLChiTieuContext : DbContext
    {
        private readonly string _connectionString;

        public QLChiTieuContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<ChiTieu> ChiTieus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTieu>(entity =>
            {
                entity.HasKey(e => e.MaCT);
                entity.ToTable("ChiTieu");
                entity.Property(e => e.NgayChi).HasColumnType("date");
                entity.Property(e => e.NoiDung).HasMaxLength(100).IsRequired();
                entity.Property(e => e.LoaiChi).HasMaxLength(30).IsRequired();
                entity.Property(e => e.SoTien).HasColumnType("decimal(18,0)");
                entity.Property(e => e.GhiChu).HasMaxLength(200);
            });
        }
    }

    public class AppSettings
    {
        public ConnectionStringsOptions ConnectionStrings { get; set; } = new();
    }

    public class ConnectionStringsOptions
    {
        public string DefaultConnection { get; set; } = string.Empty;
    }
}