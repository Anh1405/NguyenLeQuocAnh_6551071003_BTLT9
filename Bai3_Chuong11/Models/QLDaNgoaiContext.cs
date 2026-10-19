using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection.Emit;

namespace QLDaNgoaiApp.Models
{
    public class ChuyenDi
    {
        public int MaChuyen { get; set; }
        public string TenChuyen { get; set; } = string.Empty;
        public string DiaDiem { get; set; } = string.Empty;
        public DateTime NgayDi { get; set; }
        public int SoNguoi { get; set; }
        public decimal NganSach { get; set; }
        public string PhuongTien { get; set; } = string.Empty;
        public bool DaHoanThanh { get; set; }
        public string? GhiChu { get; set; }
    }

    public class QLDaNgoaiContext : DbContext
    {
        private readonly string _connectionString;

        public QLDaNgoaiContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<ChuyenDi> ChuyenDis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChuyenDi>(entity =>
            {
                entity.HasKey(e => e.MaChuyen);
                entity.ToTable("ChuyenDi");
                entity.Property(e => e.TenChuyen).HasMaxLength(100).IsRequired();
                entity.Property(e => e.DiaDiem).HasMaxLength(100).IsRequired();
                entity.Property(e => e.NgayDi).HasColumnType("date");
                entity.Property(e => e.NganSach).HasColumnType("decimal(18,0)");
                entity.Property(e => e.PhuongTien).HasMaxLength(30).IsRequired();
                entity.Property(e => e.GhiChu).HasMaxLength(200);
            });
        }
    }
}