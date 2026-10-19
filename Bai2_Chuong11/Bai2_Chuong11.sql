CREATE DATABASE QL_NhaTro;
GO
USE QL_NhaTro;
GO

CREATE TABLE PhongTro (
    MaPhong INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong NVARCHAR(20) NOT NULL,
    GiaThue DECIMAL(18,0) NOT NULL,
    TinhTrang NVARCHAR(20) NOT NULL DEFAULT N'Trống' -- N'Trống' / N'Đang thuê'
);
GO

CREATE TABLE KhachThue (
    MaKhach INT IDENTITY(1,1) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    GioiTinh NVARCHAR(5) NOT NULL,
    NgaySinh DATE NOT NULL,
    SoDienThoai VARCHAR(15) NOT NULL,
    MaTinh INT NOT NULL,
    TenTinh NVARCHAR(100) NOT NULL,
    MaPhuongXa INT NOT NULL,
    TenPhuongXa NVARCHAR(100) NOT NULL,
    DaDangKyTamTru BIT NOT NULL DEFAULT 0,
    MaPhong INT NOT NULL FOREIGN KEY REFERENCES PhongTro(MaPhong)
);
GO

-- Chèn dữ liệu mẫu 6 phòng trọ
INSERT INTO PhongTro (TenPhong, GiaThue, TinhTrang) VALUES
(N'P01', 1500000, N'Đang thuê'),
(N'P02', 1600000, N'Đang thuê'),
(N'P03', 1800000, N'Đang thuê'),
(N'P04', 2000000, N'Đang thuê'),
(N'P05', 1700000, N'Đang thuê'),
(N'P06', 1900000, N'Trống');
GO

-- Chèn dữ liệu khách thuê khớp đúng hình mẫu đề bài
INSERT INTO KhachThue (HoTen, GioiTinh, NgaySinh, SoDienThoai, MaTinh, TenTinh, MaPhuongXa, TenPhuongXa, DaDangKyTamTru, MaPhong) VALUES
(N'Nguyễn Văn', N'Nam', '2000-01-01', '0912345678', 1, N'Hà Nội', 1, N'Phường Ba Đình', 0, 3),
(N'Nguyễn Văn An', N'Nam', '2004-05-12', '0912345678', 1, N'Hà Nội', 1, N'Phường Ba Đình', 1, 3),
(N'Trần Thị Bình', N'Nữ', '2002-08-20', '0876543210', 36, N'Nam Định', 135, N'Phường Nam Định', 0, 1),
(N'Lê Văn Cường', N'Nam', '2001-11-15', '0901234567', 38, N'Thanh Hóa', 150, N'Phường Hạc Thành', 0, 2),
(N'Phạm Minh Đức', N'Nam', '2003-03-30', '0987654321', 38, N'Thanh Hóa', 152, N'Phường Điện Biên', 0, 4),
(N'Hoàng Thị Dung', N'Nữ', '2005-01-05', '0765432109', 27, N'Bắc Ninh', 98, N'Phường Bắc Ninh', 0, 5);
GO