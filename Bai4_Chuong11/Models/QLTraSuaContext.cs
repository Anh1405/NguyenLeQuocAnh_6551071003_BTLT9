using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace QLTraSuaApp.Models
{
    public class DanhMucMon
    {
        public int MaDM { get; set; }
        public string TenDM { get; set; } = string.Empty;
        public virtual ICollection<MonUong> MonUongs { get; set; } = new List<MonUong>();
    }

    public class MonUong
    {
        public int MaMon { get; set; }
        public string TenMon { get; set; } = string.Empty;
        public decimal GiaBan { get; set; }
        public bool DangBan { get; set; }
        public int MaDM { get; set; }
        public virtual DanhMucMon DanhMucMon { get; set; } = null!;

        public string DisplayText => $"{TenMon} - {GiaBan:N0}";
    }

    public class HoaDon
    {
        public int MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public string HinhThucTT { get; set; } = string.Empty;
        public bool DaThanhToan { get; set; }
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }

    public class ChiTietHoaDon
    {
        public int MaHD { get; set; }
        public int MaMon { get; set; }
        public int SoLy { get; set; }
        public decimal DonGia { get; set; }
        public virtual HoaDon HoaDon { get; set; } = null!;
        public virtual MonUong MonUong { get; set; } = null!;
    }

    public class QLTraSuaContext : DbContext
    {
        private readonly string _connectionString;

        public QLTraSuaContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<DanhMucMon> DanhMucMons { get; set; } = null!;
        public DbSet<MonUong> MonUongs { get; set; } = null!;
        public DbSet<HoaDon> HoaDons { get; set; } = null!;
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanhMucMon>(e =>
            {
                e.ToTable("DanhMucMon");
                e.HasKey(x => x.MaDM);
            });

            modelBuilder.Entity<MonUong>(e =>
            {
                e.ToTable("MonUong");
                e.HasKey(x => x.MaMon);

                e.HasOne(x => x.DanhMucMon)
                 .WithMany(d => d.MonUongs)
                 .HasForeignKey(x => x.MaDM);
            });

            modelBuilder.Entity<HoaDon>(e =>
            {
                e.ToTable("HoaDon");
                e.HasKey(x => x.MaHD);
            });

            modelBuilder.Entity<ChiTietHoaDon>(e =>
            {
                e.ToTable("ChiTietHoaDon");
                e.HasKey(x => new { x.MaHD, x.MaMon });

                e.HasOne(x => x.HoaDon)
                 .WithMany(h => h.ChiTietHoaDons)
                 .HasForeignKey(x => x.MaHD);

                e.HasOne(x => x.MonUong)
                 .WithMany()
                 .HasForeignKey(x => x.MaMon);
            });
        }
    }
}