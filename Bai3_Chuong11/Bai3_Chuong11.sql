CREATE DATABASE QL_DaNgoai;
GO
USE QL_DaNgoai;
GO

CREATE TABLE ChuyenDi (
    MaChuyen INT IDENTITY(1,1) PRIMARY KEY,
    TenChuyen NVARCHAR(100) NOT NULL,
    DiaDiem NVARCHAR(100) NOT NULL,
    NgayDi DATE NOT NULL,
    SoNguoi INT NOT NULL,
    NganSach DECIMAL(18,0) NOT NULL,
    PhuongTien NVARCHAR(30) NOT NULL,
    DaHoanThanh BIT NOT NULL DEFAULT 0,
    GhiChu NVARCHAR(200) NULL
);
GO

-- Chèn 8 chuyến đi mẫu chuẩn xác khớp với hình ảnh
INSERT INTO ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
(N'Cắm trại đồi chè', N'Đà Lạt', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Mang theo lều trại'),
(N'Cắm trại đồi chè', N'Bỉa Hạp', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Chuyến đi phụ'),
(N'Cắm trại đồi chè', N'Đà Lạt', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Chuẩn bị bếp nướng'),
(N'Cắm trại ban tối', N'Địa Hương', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Ngắm sao'),
(N'Cắm trại văn', N'Bỉa Hạp', '2026-10-25', 4, 3500000, N'Ô tô', 0, N'Đi trong ngày'),
(N'Cắm trại thao cả chà rịch', N'Pha Năm', '2026-10-25', 6, 3500000, N'Ô tô', 0, N'Dã ngoại ven sông'),
(N'Săn mây Fansipan', N'Sa Pa', '2026-10-28', 4, 5000000, N'Tàu hỏa', 0, N'Đã đặt vé tàu'),
(N'Tắm biển Vũng Tàu', N'Vũng Tàu', '2026-11-02', 8, 2000000, N'Xe máy', 0, N'Đi phượt cuối tuần');
GO