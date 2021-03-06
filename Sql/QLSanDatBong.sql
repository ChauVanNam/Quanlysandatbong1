USE [QLDatSanBongDa]
GO
ALTER TABLE [dbo].[SuatDatBong] DROP CONSTRAINT [FK_SuatDatBong_SanBong]
GO
/****** Object:  Table [dbo].[SuatDatBong]    Script Date: 1/3/2022 12:03:46 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SuatDatBong]') AND type in (N'U'))
DROP TABLE [dbo].[SuatDatBong]
GO
/****** Object:  Table [dbo].[SanBong]    Script Date: 1/3/2022 12:03:46 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SanBong]') AND type in (N'U'))
DROP TABLE [dbo].[SanBong]
GO
/****** Object:  Table [dbo].[SanBong]    Script Date: 1/3/2022 12:03:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanBong](
	[MaSanBong] [varchar](50) NOT NULL,
	[DiaChiSanBong] [nvarchar](100) NULL,
 CONSTRAINT [PK_SanBong] PRIMARY KEY CLUSTERED 
(
	[MaSanBong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SuatDatBong]    Script Date: 1/3/2022 12:03:46 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SuatDatBong](
	[MaSuat] [varchar](50) NOT NULL,
	[HoTenKhachHang] [nvarchar](100) NULL,
	[SoDienThoai] [varchar](10) NULL,
	[GiaTien] [bigint] NULL,
	[NgaySuDung] [datetime] NULL,
	[SuatDa] [nvarchar](50) NULL,
	[MaSanBong] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SuatDatBong] PRIMARY KEY CLUSTERED 
(
	[MaSuat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[SanBong] ([MaSanBong], [DiaChiSanBong]) VALUES (N'S01', N'77 Nguyễn Huệ')
INSERT [dbo].[SanBong] ([MaSanBong], [DiaChiSanBong]) VALUES (N'S02', N'82 Đống Đa')
INSERT [dbo].[SanBong] ([MaSanBong], [DiaChiSanBong]) VALUES (N'S03', N'75 Nguyễn Huệ')
INSERT [dbo].[SanBong] ([MaSanBong], [DiaChiSanBong]) VALUES (N'S04', N'22 Lý Thường ')
GO
INSERT [dbo].[SuatDatBong] ([MaSuat], [HoTenKhachHang], [SoDienThoai], [GiaTien], [NgaySuDung], [SuatDa], [MaSanBong]) VALUES (N'SUAT01', N'Hiếu Lê', N'0123456744', 200000, CAST(N'2021-12-20T00:00:00.000' AS DateTime), N'5pm', N'S02')
INSERT [dbo].[SuatDatBong] ([MaSuat], [HoTenKhachHang], [SoDienThoai], [GiaTien], [NgaySuDung], [SuatDa], [MaSanBong]) VALUES (N'SUAT02', N'Nguyễn Văn A', N'0366474834', 300000, CAST(N'2022-01-05T00:00:00.000' AS DateTime), N'8am', N'S03')
INSERT [dbo].[SuatDatBong] ([MaSuat], [HoTenKhachHang], [SoDienThoai], [GiaTien], [NgaySuDung], [SuatDa], [MaSanBong]) VALUES (N'SUAT03', N'Trần Hữu C', N'0233443323', 350000, CAST(N'2022-01-15T00:00:00.000' AS DateTime), N'6pm', N'S01')
INSERT [dbo].[SuatDatBong] ([MaSuat], [HoTenKhachHang], [SoDienThoai], [GiaTien], [NgaySuDung], [SuatDa], [MaSanBong]) VALUES (N'SUAT04', N'Nguyễn D', N'0987643455', 290000, CAST(N'2022-01-15T00:00:00.000' AS DateTime), N'9am', N'S02')
GO
ALTER TABLE [dbo].[SuatDatBong]  WITH CHECK ADD  CONSTRAINT [FK_SuatDatBong_SanBong] FOREIGN KEY([MaSanBong])
REFERENCES [dbo].[SanBong] ([MaSanBong])
GO
ALTER TABLE [dbo].[SuatDatBong] CHECK CONSTRAINT [FK_SuatDatBong_SanBong]
GO
