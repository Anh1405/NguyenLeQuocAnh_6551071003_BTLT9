CREATE DATABASE QL_TraSua;
GO
USE QL_TraSua;
GO

CREATE TABLE DanhMucMon (
    MaDM INT IDENTITY(1,1) PRIMARY KEY,
    TenDM NVARCHAR(50) NOT NULL
);
GO

CREATE TABLE MonUong (
    MaMon INT IDENTITY(1,1) PRIMARY KEY,
    TenMon NVARCHAR(100) NOT NULL,
    GiaBan DECIMAL(18,0) NOT NULL,
    DangBan BIT NOT NULL DEFAULT 1,
    MaDM INT NOT NULL FOREIGN KEY REFERENCES DanhMucMon(MaDM)
);
GO

CREATE TABLE HoaDon (
    MaHD INT IDENTITY(1,1) PRIMARY KEY,
    NgayLap DATETIME NOT NULL,
    TongTien DECIMAL(18,0) NOT NULL,
    HinhThucTT NVARCHAR(20) NOT NULL, -- N'Tiền mặt' / N'Chuyển khoản'
    DaThanhToan BIT NOT NULL DEFAULT 0
);
GO

CREATE TABLE ChiTietHoaDon (
    MaHD INT NOT NULL FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaMon INT NOT NULL FOREIGN KEY REFERENCES MonUong(MaMon),
    SoLy INT NOT NULL,
    DonGia DECIMAL(18,0) NOT NULL,
    PRIMARY KEY (MaHD, MaMon)
);
GO

-- Chèn danh mục mẫu
INSERT INTO DanhMucMon (TenDM) VALUES 
(N'Trà sữa'), (N'Trà trái cây'), (N'Topping'), (N'Đồ ăn vặt');
GO

-- Chèn 12 món uống chuẩn theo hình ảnh mẫu
INSERT INTO MonUong (TenMon, GiaBan, DangBan, MaDM) VALUES
(N'Trà sữa trân châu', 35000, 1, 1),
(N'Trà sữa matcha', 40000, 1, 1),
(N'Hồng trà sữa', 32000, 1, 1),
(N'Trà sữa khoai môn', 38000, 1, 1),
(N'Trà đào cam sả', 42000, 1, 2),
(N'Trà vải khiếm đao', 45000, 1, 2),
(N'Trà xoài kem cheese', 48000, 1, 2),
(N'Trân châu đen', 5000, 1, 3),
(N'Trân châu trắng', 5000, 1, 3),
(N'Pudding trứng', 8000, 1, 3),
(N'Bánh mì que', 15000, 1, 4),
(N'Cá viên chiên', 25000, 1, 4);
GO