using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QLNhaTroApp.Models
{
    public class PhongTro
    {
        public int MaPhong { get; set; }
        public string TenPhong { get; set; } = string.Empty;
        public decimal GiaThue { get; set; }
        public string TinhTrang { get; set; } = string.Empty;
        public virtual ICollection<KhachThue> KhachThues { get; set; } = new List<KhachThue>();

        public string DisplayText => $"{TenPhong} - {GiaThue:N0} đ";
    }

    public class KhachThue
    {
        public int MaKhach { get; set; }
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; } = string.Empty;
        public int MaTinh { get; set; }
        public string TenTinh { get; set; } = string.Empty;
        public int MaPhuongXa { get; set; }
        public string TenPhuongXa { get; set; } = string.Empty;
        public bool DaDangKyTamTru { get; set; }
        public int MaPhong { get; set; }
        public virtual PhongTro PhongTro { get; set; } = null!;
    }

    public class QLNhaTroContext : DbContext
    {
        private readonly string _connectionString;

        public QLNhaTroContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<PhongTro> PhongTros { get; set; } = null!;
        public DbSet<KhachThue> KhachThues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhongTro>(entity =>
            {
                entity.HasKey(e => e.MaPhong);
                entity.ToTable("PhongTro");
                entity.Property(e => e.TenPhong).HasMaxLength(20).IsRequired();
                entity.Property(e => e.GiaThue).HasColumnType("decimal(18,0)");
                entity.Property(e => e.TinhTrang).HasMaxLength(20).IsRequired();
            });

            modelBuilder.Entity<KhachThue>(entity =>
            {
                entity.HasKey(e => e.MaKhach);
                entity.ToTable("KhachThue");
                entity.Property(e => e.HoTen).HasMaxLength(100).IsRequired();
                entity.Property(e => e.GioiTinh).HasMaxLength(5).IsRequired();
                entity.Property(e => e.SoDienThoai).HasMaxLength(15).IsUnicode(false);
                entity.HasOne(d => d.PhongTro).WithMany(p => p.KhachThues).HasForeignKey(d => d.MaPhong);
            });
        }
    }
}