USE [QLTuyenDung]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_DonUngTuyen]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_DonUngTuyen](
	[iMaDon] [int] IDENTITY(1,1) NOT NULL,
	[iMaViecLam] [int] NOT NULL,
	[sMoTa] [nvarchar](max) NOT NULL,
	[iMaND] [int] NOT NULL,
 CONSTRAINT [PK_tbl_DonUngTuyen] PRIMARY KEY CLUSTERED 
(
	[iMaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_NguoiDung]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_NguoiDung](
	[iMaND] [int] IDENTITY(1,1) NOT NULL,
	[sTenND] [nvarchar](50) NOT NULL,
	[sEmail] [nvarchar](50) NOT NULL,
	[sSDT] [nvarchar](15) NULL,
	[dNgaySinh] [datetime2](7) NULL,
	[sGioiTinh] [nvarchar](10) NULL,
	[iMaTaiKhoan] [int] NOT NULL,
 CONSTRAINT [PK_tbl_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[iMaND] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_QuyenHan]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_QuyenHan](
	[iMaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[sTenQuyen] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_tbl_QuyenHan] PRIMARY KEY CLUSTERED 
(
	[iMaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_TaiKhoan]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_TaiKhoan](
	[iMaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[sTaiKhoan] [nvarchar](50) NOT NULL,
	[sMatKhau] [nvarchar](50) NOT NULL,
	[iMaQuyen] [int] NOT NULL,
 CONSTRAINT [PK_tbl_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[iMaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ThongBao]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ThongBao](
	[iMaTB] [int] IDENTITY(1,1) NOT NULL,
	[sToEmail] [nvarchar](50) NOT NULL,
	[sFromEmail] [nvarchar](50) NOT NULL,
	[sTieuDe] [nvarchar](100) NOT NULL,
	[sNoiDung] [nvarchar](max) NOT NULL,
	[iMaND] [int] NOT NULL,
 CONSTRAINT [PK_tbl_ThongBao] PRIMARY KEY CLUSTERED 
(
	[iMaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tbl_ViecLam]    Script Date: 12/07/2024 11:20:22 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tbl_ViecLam](
	[iMaViecLam] [int] IDENTITY(1,1) NOT NULL,
	[sTieuDe] [nvarchar](255) NOT NULL,
	[sMota] [nvarchar](max) NOT NULL,
	[fMucLuong] [float] NOT NULL,
	[dNgayTao] [date] NULL,
	[dNgayHetHan] [date] NULL,
	[bTrangThai] [bit] NOT NULL,
 CONSTRAINT [PK_tbl_ViecLam] PRIMARY KEY CLUSTERED 
(
	[iMaViecLam] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704033620_FirstMigration', N'6.0.31')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704035155_AddQuyenHan', N'6.0.31')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704105930_UpdateTK', N'6.0.31')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704185538_AddAll', N'6.0.31')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240706053324_UpdateDonUT_ViecLam', N'6.0.31')
GO
SET IDENTITY_INSERT [dbo].[tbl_NguoiDung] ON 

INSERT [dbo].[tbl_NguoiDung] ([iMaND], [sTenND], [sEmail], [sSDT], [dNgaySinh], [sGioiTinh], [iMaTaiKhoan]) VALUES (1, N'Admin', N'anhduc220403@gmail.com', NULL, NULL, NULL, 1)
INSERT [dbo].[tbl_NguoiDung] ([iMaND], [sTenND], [sEmail], [sSDT], [dNgaySinh], [sGioiTinh], [iMaTaiKhoan]) VALUES (2, N'Anh Đức', N'anhducws2204@gmail.com', NULL, NULL, NULL, 2)
SET IDENTITY_INSERT [dbo].[tbl_NguoiDung] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_QuyenHan] ON 

INSERT [dbo].[tbl_QuyenHan] ([iMaQuyen], [sTenQuyen]) VALUES (1, N'Admin')
INSERT [dbo].[tbl_QuyenHan] ([iMaQuyen], [sTenQuyen]) VALUES (2, N'User')
SET IDENTITY_INSERT [dbo].[tbl_QuyenHan] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_TaiKhoan] ON 

INSERT [dbo].[tbl_TaiKhoan] ([iMaTaiKhoan], [sTaiKhoan], [sMatKhau], [iMaQuyen]) VALUES (1, N'anhduc220403@gmail.com', N'admin', 1)
INSERT [dbo].[tbl_TaiKhoan] ([iMaTaiKhoan], [sTaiKhoan], [sMatKhau], [iMaQuyen]) VALUES (2, N'anhducws2204@gmail.com', N'12345', 2)
SET IDENTITY_INSERT [dbo].[tbl_TaiKhoan] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_ViecLam] ON 

INSERT [dbo].[tbl_ViecLam] ([iMaViecLam], [sTieuDe], [sMota], [fMucLuong], [dNgayTao], [dNgayHetHan], [bTrangThai]) VALUES (1, N'Tuyển dụng vị trí X', N'Mô tả chi tiết....', 5600000, CAST(N'2024-07-06' AS Date), CAST(N'2024-07-10' AS Date), 1)
INSERT [dbo].[tbl_ViecLam] ([iMaViecLam], [sTieuDe], [sMota], [fMucLuong], [dNgayTao], [dNgayHetHan], [bTrangThai]) VALUES (2, N'Tuyển nhân viên vị trí X', N'Lương thỏa thuận', 10000000, CAST(N'2024-07-07' AS Date), CAST(N'2024-07-09' AS Date), 0)
SET IDENTITY_INSERT [dbo].[tbl_ViecLam] OFF
GO
ALTER TABLE [dbo].[tbl_NguoiDung] ADD  DEFAULT ((0)) FOR [iMaTaiKhoan]
GO
ALTER TABLE [dbo].[tbl_TaiKhoan] ADD  DEFAULT ((0)) FOR [iMaQuyen]
GO
ALTER TABLE [dbo].[tbl_DonUngTuyen]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DonUngTuyen_tbl_NguoiDung_iMaND] FOREIGN KEY([iMaND])
REFERENCES [dbo].[tbl_NguoiDung] ([iMaND])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_DonUngTuyen] CHECK CONSTRAINT [FK_tbl_DonUngTuyen_tbl_NguoiDung_iMaND]
GO
ALTER TABLE [dbo].[tbl_DonUngTuyen]  WITH CHECK ADD  CONSTRAINT [FK_tbl_DonUngTuyen_tbl_ViecLam_iMaViecLam] FOREIGN KEY([iMaViecLam])
REFERENCES [dbo].[tbl_ViecLam] ([iMaViecLam])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_DonUngTuyen] CHECK CONSTRAINT [FK_tbl_DonUngTuyen_tbl_ViecLam_iMaViecLam]
GO
ALTER TABLE [dbo].[tbl_NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_tbl_NguoiDung_tbl_TaiKhoan_iMaTaiKhoan] FOREIGN KEY([iMaTaiKhoan])
REFERENCES [dbo].[tbl_TaiKhoan] ([iMaTaiKhoan])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_NguoiDung] CHECK CONSTRAINT [FK_tbl_NguoiDung_tbl_TaiKhoan_iMaTaiKhoan]
GO
ALTER TABLE [dbo].[tbl_TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_tbl_TaiKhoan_tbl_QuyenHan_iMaQuyen] FOREIGN KEY([iMaQuyen])
REFERENCES [dbo].[tbl_QuyenHan] ([iMaQuyen])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_TaiKhoan] CHECK CONSTRAINT [FK_tbl_TaiKhoan_tbl_QuyenHan_iMaQuyen]
GO
ALTER TABLE [dbo].[tbl_ThongBao]  WITH CHECK ADD  CONSTRAINT [FK_tbl_ThongBao_tbl_NguoiDung_iMaND] FOREIGN KEY([iMaND])
REFERENCES [dbo].[tbl_NguoiDung] ([iMaND])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tbl_ThongBao] CHECK CONSTRAINT [FK_tbl_ThongBao_tbl_NguoiDung_iMaND]
GO
