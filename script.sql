USE [master]
GO
/****** Object:  Database [LapLichBaoVeLuanVan]    Script Date: 12/23/2018 7:46:15 PM ******/
CREATE DATABASE [LapLichBaoVeLuanVan]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LapLichBaoVeLuanVan', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\LapLichBaoVeLuanVan.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LapLichBaoVeLuanVan_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\LapLichBaoVeLuanVan_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LapLichBaoVeLuanVan].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET ARITHABORT OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET RECOVERY FULL 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET  MULTI_USER 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LapLichBaoVeLuanVan', N'ON'
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET QUERY_STORE = OFF
GO
USE [LapLichBaoVeLuanVan]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [LapLichBaoVeLuanVan]
GO
/****** Object:  Table [dbo].[CaTrongNgay]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CaTrongNgay](
	[Ca] [int] NOT NULL,
	[ThoiDiem] [char](10) NULL,
 CONSTRAINT [PK_CaTrongNgay] PRIMARY KEY CLUSTERED 
(
	[Ca] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DeTai]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeTai](
	[TenDT] [nvarchar](50) NOT NULL,
	[NamHoc] [int] NOT NULL,
	[HocKy] [int] NOT NULL,
 CONSTRAINT [PK_DeTai] PRIMARY KEY CLUSTERED 
(
	[TenDT] ASC,
	[NamHoc] ASC,
	[HocKy] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GiangVien]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiangVien](
	[MaGV] [int] NOT NULL,
	[TenGV] [nvarchar](50) NULL,
	[GioiTinh] [nvarchar](50) NULL,
	[SDT] [varchar](50) NULL,
	[ChucVu] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
	[SLDeTaiToiDa] [int] NULL,
	[myIndex] [int] NULL,
 CONSTRAINT [PK_GiaoVien] PRIMARY KEY CLUSTERED 
(
	[MaGV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Lich]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Lich](
	[Ngay] [int] NOT NULL,
	[Ca] [int] NOT NULL,
	[Phong] [int] NOT NULL,
	[MaPC] [int] NOT NULL,
 CONSTRAINT [PK_Lich_1] PRIMARY KEY CLUSTERED 
(
	[Ngay] ASC,
	[Ca] ASC,
	[Phong] ASC,
	[MaPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Nhom]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Nhom](
	[MaNhom] [int] NOT NULL,
	[SV1] [nvarchar](50) NULL,
	[SV2] [nvarchar](50) NULL,
	[myIndex] [int] NULL,
 CONSTRAINT [PK_Nhom] PRIMARY KEY CLUSTERED 
(
	[MaNhom] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[MaPC] [int] NOT NULL,
	[GVHuongDan] [int] NULL,
	[GVPhanBien] [int] NULL,
	[UyVien] [int] NULL,
	[MaNhom] [int] NULL,
	[myIndex] [int] NULL,
	[TenDeTai] [nvarchar](50) NULL,
	[NamHoc] [int] NULL,
	[HocKy] [int] NULL,
 CONSTRAINT [PK_PhanCong] PRIMARY KEY CLUSTERED 
(
	[MaPC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhongHoc]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhongHoc](
	[MaPH] [int] NOT NULL,
	[TenPH] [nvarchar](50) NULL,
	[myIndex] [int] NULL,
 CONSTRAINT [PK_PhongHoc] PRIMARY KEY CLUSTERED 
(
	[MaPH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[CaTrongNgay] ([Ca], [ThoiDiem]) VALUES (1, N'7h        ')
INSERT [dbo].[CaTrongNgay] ([Ca], [ThoiDiem]) VALUES (2, N'8h30      ')
INSERT [dbo].[CaTrongNgay] ([Ca], [ThoiDiem]) VALUES (3, N'10h       ')
INSERT [dbo].[CaTrongNgay] ([Ca], [ThoiDiem]) VALUES (4, N'13h       ')
INSERT [dbo].[CaTrongNgay] ([Ca], [ThoiDiem]) VALUES (5, N'14h30     ')
INSERT [dbo].[CaTrongNgay] ([Ca], [ThoiDiem]) VALUES (6, N'16h       ')
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'AI', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'AI', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'AI', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'AI', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'AI', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'AI', 2018, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2018, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2019, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game 2048', 2019, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game Đặt Mìn', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game Đặt Mìn', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game Đặt Mìn', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game Đặt Mìn', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game Đặt Mìn', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Game Đặt Mìn', 2018, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Khai Phá Dữ Liệu', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Khai Phá Dữ Liệu', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Khai Phá Dữ Liệu', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Khai Phá Dữ Liệu', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Khai Phá Dữ Liệu', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Khai Phá Dữ Liệu', 2018, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2018, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Trình Nhúng', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Trình Nhúng', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Trình Nhúng', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Trình Nhúng', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Trình Nhúng', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Lập Trình Nhúng', 2018, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Quản Lý Nhà Hàng', 2017, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Quản Lý Nhà Hàng', 2017, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Quản Lý Nhà Hàng', 2017, 3)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Quản Lý Nhà Hàng', 2018, 1)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Quản Lý Nhà Hàng', 2018, 2)
INSERT [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy]) VALUES (N'Quản Lý Nhà Hàng', 2018, 3)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (0, N'Tất Cả', NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (1, N'Lê Văn Vinh', N'Nam', N'0166456456', N'Phó Trưởng Khoa', N'vinhlv@hcmute.edu.vn', N'Q1', 4, 1)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (2, N'Đinh Công Đoan', N'Nam', N'0166789789', N'Phó Trưởng Khoa', N'doandc@hcmute.edu.vn', N'Q2', 4, 2)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (3, N'Đặng Thanh Dũng', N'Nam', N'0166123457', N'Trưởng Khoa', N'dungdt@hcmute.edu.vn', N'Q3', 4, 3)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (4, N'Nguyễn Đăng Quang', N'Nam', N'0166896989', N'Phó Trưởng Khoa', N'quangnd@hcmute.edu.vn', N'Q4', 4, 4)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (5, N'Lê Thanh Phúc', N'Nam', N'0166474589', N'Trưởng Khoa', N'phuclt@hcmute.edu.vn', N'Q5', 4, 5)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (6, N'Nguyễn Văn Long Giang', N'Nam', N'0165788945', N'Phó Trưởng Khoa', N'giangckd@hcmute.edu.vn', N'Q6', 4, 6)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (7, N'Trần Công Tú', N'Nam', N'0165788978', N'Giảng Viên', N'tutc@hcmute.edu.vn', N'Q7', 4, 7)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (8, N'Nguyễn Trần Thi Văn', N'Nam', N'0165448788', N'Giảng Viên', N'thivan@hcmute.edu.vn', N'Q8', 4, 8)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (9, N'Nguyễn Minh Đạo', N'Nam', N'0165774589', N'Trưởng Khoa', N'DaoNguyen@hcmute.edu.vn', N'Q9', 4, 9)
INSERT [dbo].[GiangVien] ([MaGV], [TenGV], [GioiTinh], [SDT], [ChucVu], [Email], [DiaChi], [SLDeTaiToiDa], [myIndex]) VALUES (10, N'Từ Tuyết Hồng ', N'Nữ', N'0134548898', N'Giảng Viên', N'Hongtt@hcmute.edu.vn', N'Q10', 4, 10)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 1, 1)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 1, 2)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 2, 3)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 2, 8)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 3, 15)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 7, 17)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 10, 13)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 1, 20, 20)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 2, 1, 4)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 2, 1, 9)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 2, 2, 16)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 2, 9, 18)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 3, 1, 5)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 3, 1, 10)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 3, 1, 19)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 4, 2, 6)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 4, 9, 12)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 5, 1, 7)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (1, 5, 3, 11)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (2, 1, 2, 14)
INSERT [dbo].[Lich] ([Ngay], [Ca], [Phong], [MaPC]) VALUES (2, 1, 19, 24)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (1, N'Đào Lê Văn Vinh', N'Hà Minh Trí', 1)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (2, N'Dương Quốc Bảo', N'Nguyễn Phúc Tú', 2)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (3, N'Trang Hóa Thịnh', N'Văn Duệ Đức', 3)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (4, N'Lê Thanh Sang', N'Huỳnh Minh Nhựt', 4)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (5, N'Lê Thanh Liêm ', N'Nguyễn Trường Giang', 5)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (6, N'Tăng Anh Tuấn', N'Nguyễn Trung Hiếu', 6)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (7, N'Xe Hoàng Phú', N'Lê Thế Anh', 7)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (8, N'Nguyễn Thanh Huy', N'Nguyễn Hữu Huy', 8)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (9, N'Lê Tấn Lộc', N'Trọng Hiếu', 9)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (10, N'Tăng Anh Hào', N'Nguyễn Xuân Hoàng', 10)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (11, N'Trà Đăng Khoa', N'Nguyễn Mai Hùng', 11)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (12, N'Lê Đức Anh', N'Nguyễn Văn Hùng', 12)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (13, N'Đức Quy', N'Nguyễn Duy Hưng', 13)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (14, N'A', N'B', 14)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (15, N'C', N'D', 15)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (16, N'E', N'F', 16)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (17, N'H', N'G', 17)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (18, N'L', N'O', 18)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (19, N'M', N'N', 19)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (20, N'Y', N'Izxc', 20)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (22, N'asd', N'asdsssssss', 22)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (23, N'dasdsad', N'wdwdwdw', 23)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (24, N'zxxzx', N'zxxzxzxzxzxzx', 24)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (25, N'Dao Le Van Vinh', N'Nguyen Xuan Hoang', 25)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (26, N'asdasdasd', N'dfdsfsdfsd', 26)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (27, N'V1', N'V1', 27)
INSERT [dbo].[Nhom] ([MaNhom], [SV1], [SV2], [myIndex]) VALUES (28, N'B1', N'B2', 28)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (1, 1, 9, 7, 23, 1, N'Khai Phá Dữ Liệu', 2017, 1)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (2, 2, 1, 4, 2, 2, N'Game 2048', 2019, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (3, 3, 4, 2, 3, 3, N'Game Đặt Mìn', 2018, 1)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (4, 4, 2, 6, 4, 4, N'Khai Phá Dữ Liệu', 2018, 1)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (5, 5, 6, 4, 5, 5, N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2018, 1)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (6, 6, 4, 8, 6, 6, N'Lập Trình Nhúng', 2018, 1)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (7, 7, 8, 2, 7, 7, N'Quản Lý Nhà Hàng', 2018, 1)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (8, 8, 2, 10, 8, 8, N'AI', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (9, 9, 10, 4, 9, 9, N'Game 2048', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (10, 10, 4, 7, 10, 10, N'Game Đặt Mìn', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (11, 1, 7, 6, 11, 11, N'Khai Phá Dữ Liệu', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (12, 2, 6, 9, 12, 12, N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (13, 3, 9, 7, 13, 13, N'Lập Trình Nhúng', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (14, 4, 7, 1, 14, 14, N'Quản Lý Nhà Hàng', 2018, 2)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (15, 5, 1, 3, 15, 15, N'AI', 2018, 3)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (16, 6, 3, 7, 16, 16, N'Game 2048', 2018, 3)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (17, 7, 9, 2, 17, 17, N'Game Đặt Mìn', 2018, 3)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (18, 8, 10, 4, 18, 18, N'Khai Phá Dữ Liệu', 2018, 3)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (19, 9, 4, 8, 19, 19, N'Lập Lịch Hội Đồng Bảo Vệ Luận Án', 2018, 3)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (20, 10, 8, 6, 20, 20, N'Quản Lý Nhà Hàng', 2018, 3)
INSERT [dbo].[PhanCong] ([MaPC], [GVHuongDan], [GVPhanBien], [UyVien], [MaNhom], [myIndex], [TenDeTai], [NamHoc], [HocKy]) VALUES (24, 6, 10, 3, 25, 23, N'AI', 2018, 2)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (1, N'A1-201', 1)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (2, N'A1-202', 2)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (3, N'A1-103', 3)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (4, N'A1-104', 4)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (5, N'A2-201', 5)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (6, N'A2-301', 6)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (7, N'A2-303', 7)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (8, N'E1-405', 8)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (9, N'A3-302', 9)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (10, N'A4-301', 10)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (11, N'A5-201', 11)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (12, N'A2-401', 12)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (13, N'A1-505', 13)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (14, N'A3-401', 14)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (15, N'A4-403', 15)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (16, N'A2-202', 16)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (17, N'A1-303', 17)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (18, N'A4-105', 18)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (19, N'A3-102', 19)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (20, N'A4-405', 20)
INSERT [dbo].[PhongHoc] ([MaPH], [TenPH], [myIndex]) VALUES (21, N'A5-203Z', 21)
ALTER TABLE [dbo].[Lich]  WITH CHECK ADD  CONSTRAINT [FK_Lich_CaTrongNgay] FOREIGN KEY([Ca])
REFERENCES [dbo].[CaTrongNgay] ([Ca])
GO
ALTER TABLE [dbo].[Lich] CHECK CONSTRAINT [FK_Lich_CaTrongNgay]
GO
ALTER TABLE [dbo].[Lich]  WITH CHECK ADD  CONSTRAINT [FK_Lich_PhanCong] FOREIGN KEY([MaPC])
REFERENCES [dbo].[PhanCong] ([MaPC])
GO
ALTER TABLE [dbo].[Lich] CHECK CONSTRAINT [FK_Lich_PhanCong]
GO
ALTER TABLE [dbo].[Lich]  WITH CHECK ADD  CONSTRAINT [FK_Lich_PhongHoc] FOREIGN KEY([Phong])
REFERENCES [dbo].[PhongHoc] ([MaPH])
GO
ALTER TABLE [dbo].[Lich] CHECK CONSTRAINT [FK_Lich_PhongHoc]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_DeTai] FOREIGN KEY([TenDeTai], [NamHoc], [HocKy])
REFERENCES [dbo].[DeTai] ([TenDT], [NamHoc], [HocKy])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_DeTai]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_GiangVien] FOREIGN KEY([GVHuongDan])
REFERENCES [dbo].[GiangVien] ([MaGV])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_GiangVien]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_GiangVien1] FOREIGN KEY([GVPhanBien])
REFERENCES [dbo].[GiangVien] ([MaGV])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_GiangVien1]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_GiangVien2] FOREIGN KEY([UyVien])
REFERENCES [dbo].[GiangVien] ([MaGV])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_GiangVien2]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_Nhom] FOREIGN KEY([MaNhom])
REFERENCES [dbo].[Nhom] ([MaNhom])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_Nhom]
GO
/****** Object:  StoredProcedure [dbo].[sp_getDanhSachPhanCongChuaTaoLich]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getDanhSachPhanCongChuaTaoLich]

AS
BEGIN
	select * from PhanCong
	where MaPC not in (select MaPC from Lich)
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getDanhSachPhanCongChuaTaoLichTheoGiangVien]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getDanhSachPhanCongChuaTaoLichTheoGiangVien]
@MaGV int
AS
BEGIN
	select * from PhanCong
	where (GVHuongDan=@MaGV or GVPhanBien = @MaGV or UyVien = @MaGV) and (MaPC not in (select MaPC from Lich))
END
GO
/****** Object:  StoredProcedure [dbo].[sp_getDeTaiChuaDuocPhanCong]    Script Date: 12/23/2018 7:46:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sp_getDeTaiChuaDuocPhanCong]
@HocKy int,
@NamHoc int
AS
BEGIN
	
	select * from DeTai dt
	where dt.HocKy = @HocKy and dt.NamHoc = @NamHoc and dt.TenDT not in (   select pc.TenDeTai
																			from PhanCong pc
																			where pc.HocKy = @HocKy and pc.NamHoc = @NamHoc
																			)

END
GO
USE [master]
GO
ALTER DATABASE [LapLichBaoVeLuanVan] SET  READ_WRITE 
GO
