USE QL_DaNgoai;
GO

-- Chèn thêm 20 dữ liệu thử nghiệm phong phú
INSERT INTO ChuyenDi (TenChuyen, DiaDiem, NgayDi, SoNguoi, NganSach, PhuongTien, DaHoanThanh, GhiChu) VALUES
-- Dã ngoại vùng cao & Đông Tây Bắc
(N'Khám phá Mù Cang Chải', N'Mù Cang Chải', '2026-10-22', 4, 4500000, N'Xe máy', 0, N'Ngắm lúa chín mâm xôi'),
(N'Chinh phục Hà Giang', N'Hà Giang', '2026-10-26', 6, 6000000, N'Xe khách', 0, N'Đi đèo Mã Pí Lèng'),
(N'Săn mây Tà Xùa', N'Mộc Châu', '2026-10-29', 5, 3200000, N'Ô tô', 0, N'Cắm trại đỉnh gió'),
(N'Check-in Thác Bản Giốc', N'Cao Bằng', '2026-11-05', 4, 4800000, N'Ô tô', 0, N'Ghé suối Lê Nin'),
(N'Dã ngoại Tràng An', N'Ninh Bình', '2026-11-10', 10, 2500000, N'Ô tô', 0, N'Đi thuyền hang Múa'),

-- Dã ngoại miền Trung & Cố đô
(N'Dạo phố cổ Hội An', N'Hội An', '2026-10-24', 2, 5500000, N'Máy bay', 0, N'Thả hoa đăng sông Hoài'),
(N'Thăm Cố đô Huế', N'Huế', '2026-11-01', 5, 4000000, N'Tàu hỏa', 0, N'Thưởng thức ẩm thực cung đình'),
(N'Nghỉ dưỡng Bà Nà Hills', N'Đà Nẵng', '2026-11-08', 8, 8500000, N'Máy bay', 0, N'Check-in Cầu Vàng'),
(N'Lặn ngắm san hô', N'Quy Nhơn', '2026-11-12', 6, 6200000, N'Máy bay', 0, N'Đi Kỳ Co - Eo Gió'),
(N'Phượt biển Cổ Thạch', N'Phan Thiết', '2026-11-15', 4, 2800000, N'Xe máy', 0, N'Ngắm bãi đá 7 màu'),

-- Dã ngoại miền Nam & Biển đảo
(N'Nghỉ dưỡng đảo Ngọc', N'Phú Quốc', '2026-10-30', 4, 12000000, N'Máy bay', 0, N'Ngắm hoàng hôn Grand World'),
(N'Khám phá Đảo Yến', N'Nha Trang', '2026-11-03', 6, 7500000, N'Tàu hỏa', 0, N'Tắm bãi đôi duy nhất'),
(N'Chợ nổi Cái Răng', N'Cần Thơ', '2026-11-18', 12, 1800000, N'Xe khách', 0, N'Thưởng thức trái cây nhà vườn'),
(N'Cắm trại Biển Hồ', N'Gia Lai', '2026-11-20', 5, 3800000, N'Ô tô', 0, N'Ghé đồi hoa dại'),
(N'Cắm trại hồ Trị An', N'Đồng Nai', '2026-11-22', 8, 1500000, N'Xe máy', 0, N'Nướng BBQ ngoài trời'),

-- Chuyến đi đã hoàn thành (Dùng để test tính năng lọc "Chỉ hiện chuyến chưa hoàn thành")
(N'Dã ngoại Thảo Cầm Viên', N'Hồ Chí Minh', '2026-09-10', 4, 800000, N'Xe máy', 1, N'Đã hoàn thành xuất sắc'),
(N me=N'Tắm biển Bãi Sau', N'Vũng Tàu', '2026-09-15', 6, 2200000, N'Ô tô', 1, N'Chuyến đi ngắn ngày'),
(N'Trekking Suối Tiên', N'Đà Lạt', '2026-09-20', 3, 3000000, N'Xe khách', 1, N'Đã hoàn thành đúng kế hoạch'),
(N'Cắm trại Núi Bà Đen', N'Tây Ninh', '2026-10-01', 5, 1200000, N'Xe máy', 1, N'Săn mây thành công'),
(N'Tham quan Vinh Cửa Lò', N'Nghệ An', '2026-10-05', 7, 4500000, N'Tàu hỏa', 1, N'Đã về lại trường');
GO