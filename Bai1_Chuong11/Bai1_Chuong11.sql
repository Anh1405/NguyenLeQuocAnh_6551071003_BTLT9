CREATE DATABASE QL_ChiTieu;
GO
USE QL_ChiTieu;
GO

CREATE TABLE ChiTieu (
    MaCT INT IDENTITY(1,1) PRIMARY KEY,
    NgayChi DATE NOT NULL,
    NoiDung NVARCHAR(100) NOT NULL,
    SoTien DECIMAL(18,0) NOT NULL,
    LoaiChi NVARCHAR(30) NOT NULL,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Chèn 10 dòng dữ liệu mẫu
INSERT INTO ChiTieu (NgayChi, NoiDung, SoTien, LoaiChi, GhiChu) VALUES
('2026-10-01', N'Cơm trưa', 35000, N'Ăn uống', N'Ăn tại quán bình dân'),
('2026-10-02', N'Xăng xe', 60000, N'Đi lại', N'Đầy bình xe Wave'),
('2026-10-03', N'Photo giáo trình', 25000, N'Học tập', N'In tài liệu môn C#'),
('2026-10-04', N'Xem phim', 90000, N'Giải trí', N'Vé xem phim cuối tuần'),
('2026-10-05', N'Trà sữa', 40000, N'Ăn uống', N'Uống cùng bạn học'),
('2026-10-06', N'Mua sắm', 150000, N'Khác', N'Mua đồ dùng cá nhân'),
('2026-10-07', N'Tiền điện', 500000, N'Khác', N'Tháng 9/2026'),
('2026-10-08', N'Ăn sáng', 25000, N'Ăn uống', N'Bún riêu'),
('2026-10-09', N'Sách tham khảo', 120000, N'Học tập', N'Sách C# Nâng cao'),
('2026-10-10', N'Bảo dưỡng xe', 200000, N'Đi lại', N'Thay nhớt');
GO