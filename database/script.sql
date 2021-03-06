USE [master]
GO
/****** Object:  Database [Car_Hire_System]    Script Date: 31.12.2020 00:48:05 ******/
CREATE DATABASE [Car_Hire_System]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Car_Hire_System', FILENAME = N'C:\Users\Huseyin\Desktop\Huseyin\Üniversite\proje\Car_Hire_System\WindowsFormsApp1\Database\Car_Hire_System.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Car_Hire_System_log', FILENAME = N'C:\Users\Huseyin\Desktop\Huseyin\Üniversite\proje\Car_Hire_System\WindowsFormsApp1\Database\Car_Hire_System_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Car_Hire_System] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Car_Hire_System].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Car_Hire_System] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Car_Hire_System] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Car_Hire_System] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Car_Hire_System] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Car_Hire_System] SET ARITHABORT OFF 
GO
ALTER DATABASE [Car_Hire_System] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Car_Hire_System] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Car_Hire_System] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Car_Hire_System] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Car_Hire_System] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Car_Hire_System] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Car_Hire_System] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Car_Hire_System] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Car_Hire_System] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Car_Hire_System] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Car_Hire_System] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Car_Hire_System] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Car_Hire_System] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Car_Hire_System] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Car_Hire_System] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Car_Hire_System] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Car_Hire_System] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Car_Hire_System] SET RECOVERY FULL 
GO
ALTER DATABASE [Car_Hire_System] SET  MULTI_USER 
GO
ALTER DATABASE [Car_Hire_System] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Car_Hire_System] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Car_Hire_System] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Car_Hire_System] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Car_Hire_System] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Car_Hire_System] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Car_Hire_System', N'ON'
GO
ALTER DATABASE [Car_Hire_System] SET QUERY_STORE = OFF
GO
USE [Car_Hire_System]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[AdminID] [int] IDENTITY(0,1) NOT NULL,
	[KullanıcıAdı] [nchar](30) NOT NULL,
	[Şifre] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[AdminID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Araç]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Araç](
	[ŞasiID] [nvarchar](17) NOT NULL,
	[Model] [nvarchar](30) NOT NULL,
	[Marka] [nvarchar](30) NOT NULL,
	[MevcutKilometre] [int] NOT NULL,
	[MotorGücü] [float] NOT NULL,
	[YakıtTürü] [nvarchar](20) NOT NULL,
	[VitesTürü] [nvarchar](20) NOT NULL,
	[BagajHacmi] [float] NOT NULL,
	[Rengi] [nvarchar](30) NOT NULL,
	[KoltukSayısı] [int] NOT NULL,
	[KaskoDurumu] [nvarchar](10) NOT NULL,
	[HavaYastığıDurumu] [nvarchar](10) NOT NULL,
	[AdminID] [int] NULL,
	[TCkimlik] [nvarchar](11) NOT NULL,
	[KategoriID] [int] NULL,
	[Resim1] [image] NULL,
	[Resim2] [image] NULL,
	[Resim3] [image] NULL,
	[Resim4] [image] NULL,
 CONSTRAINT [PK_Araç] PRIMARY KEY CLUSTERED 
(
	[ŞasiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AraçKategorisi]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AraçKategorisi](
	[KategoriID] [int] IDENTITY(100,1) NOT NULL,
	[KategoriAdı] [nvarchar](30) NOT NULL,
	[KategoriAçıklaması] [nvarchar](500) NOT NULL,
	[AdminID] [int] NULL,
 CONSTRAINT [PK_AraçKategorisi] PRIMARY KEY CLUSTERED 
(
	[KategoriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kiralama]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kiralama](
	[KiralamaID] [int] IDENTITY(1000,1) NOT NULL,
	[TeklifBaslangıçTarihi] [datetime] NOT NULL,
	[TeklifBitişTarihi] [datetime] NOT NULL,
	[GünlükTeklifFiyatı] [float] NOT NULL,
	[YaşSınırı] [int] NOT NULL,
	[AdminID] [int] NULL,
	[ŞasiID] [nvarchar](17) NOT NULL,
 CONSTRAINT [PK_Kiralama] PRIMARY KEY CLUSTERED 
(
	[KiralamaID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Müşteri]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Müşteri](
	[MüşteriID] [int] IDENTITY(1,1) NOT NULL,
	[Adı] [nvarchar](30) NOT NULL,
	[Soyadı] [nvarchar](30) NOT NULL,
	[Cinsiyeti] [nvarchar](6) NOT NULL,
	[Yaşı] [int] NOT NULL,
	[EmailAdresi] [nvarchar](50) NOT NULL,
	[TelefonNumarası] [nvarchar](20) NOT NULL,
	[EvAdresi] [nvarchar](500) NULL,
	[İli] [nvarchar](30) NOT NULL,
	[İlçesi] [nvarchar](30) NOT NULL,
	[Ülkesi] [nvarchar](30) NOT NULL,
	[Şifresi] [nvarchar](50) NOT NULL,
	[AdminID] [int] NULL,
 CONSTRAINT [PK_Müşteri] PRIMARY KEY CLUSTERED 
(
	[MüşteriID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ödeme]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ödeme](
	[ÖdemeID] [int] IDENTITY(1,1000) NOT NULL,
	[BaşlangıçTarihi] [datetime] NOT NULL,
	[BitişTarihi] [datetime] NOT NULL,
	[KiralamaDurumu] [nvarchar](30) NOT NULL,
	[MüşteriID] [int] NOT NULL,
	[KiralamaID] [int] NOT NULL,
	[AdminID] [int] NULL,
 CONSTRAINT [PK_Ödeme] PRIMARY KEY CLUSTERED 
(
	[ÖdemeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Satıcı]    Script Date: 31.12.2020 00:48:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Satıcı](
	[TCkimlik] [nvarchar](11) NOT NULL,
	[Adı] [nvarchar](30) NOT NULL,
	[Soyadı] [nvarchar](30) NOT NULL,
	[Cinsiyeti] [nvarchar](6) NOT NULL,
	[Yaşı] [int] NOT NULL,
	[EmailAdresi] [nvarchar](50) NOT NULL,
	[TelefonNumarası] [nvarchar](20) NOT NULL,
	[EvAdresi] [nvarchar](500) NOT NULL,
	[İli] [nvarchar](30) NOT NULL,
	[İlçesi] [nvarchar](30) NOT NULL,
	[Ülkesi] [nvarchar](30) NOT NULL,
	[Şifresi] [nvarchar](50) NOT NULL,
	[AdminID] [int] NULL,
	[Resim] [image] NULL,
 CONSTRAINT [PK_Satıcı] PRIMARY KEY CLUSTERED 
(
	[TCkimlik] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Admin] ON 

INSERT [dbo].[Admin] ([AdminID], [KullanıcıAdı], [Şifre], [Email]) VALUES (1, N'hs                            ', N'12345678', N'h@')
SET IDENTITY_INSERT [dbo].[Admin] OFF
GO
INSERT [dbo].[Araç] ([ŞasiID], [Model], [Marka], [MevcutKilometre], [MotorGücü], [YakıtTürü], [VitesTürü], [BagajHacmi], [Rengi], [KoltukSayısı], [KaskoDurumu], [HavaYastığıDurumu], [AdminID], [TCkimlik], [KategoriID], [Resim1], [Resim2], [Resim3], [Resim4]) VALUES (N'11111111111111111', N'A7', N'Mercedes', 0, 500, N'benzin', N'Tam Otomatik', 200, N'siyah', 4, N'var', N'yok', NULL, N'11111111111', NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[AraçKategorisi] ON 

INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (100, N'yok', N'a', NULL)
INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (101, N'Motor', N'a', NULL)
INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (102, N'Otomobil', N'a', NULL)
INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (103, N'Kamyonet', N'a', NULL)
INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (104, N'Kamyon', N'a', NULL)
INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (105, N'Minibüs', N'a', NULL)
INSERT [dbo].[AraçKategorisi] ([KategoriID], [KategoriAdı], [KategoriAçıklaması], [AdminID]) VALUES (106, N'Otobüs', N'a', NULL)
SET IDENTITY_INSERT [dbo].[AraçKategorisi] OFF
GO
SET IDENTITY_INSERT [dbo].[Kiralama] ON 

INSERT [dbo].[Kiralama] ([KiralamaID], [TeklifBaslangıçTarihi], [TeklifBitişTarihi], [GünlükTeklifFiyatı], [YaşSınırı], [AdminID], [ŞasiID]) VALUES (1000, CAST(N'2020-12-22T00:00:00.000' AS DateTime), CAST(N'2020-12-30T00:00:00.000' AS DateTime), 10, 18, NULL, N'11111111111111111')
SET IDENTITY_INSERT [dbo].[Kiralama] OFF
GO
SET IDENTITY_INSERT [dbo].[Müşteri] ON 

INSERT [dbo].[Müşteri] ([MüşteriID], [Adı], [Soyadı], [Cinsiyeti], [Yaşı], [EmailAdresi], [TelefonNumarası], [EvAdresi], [İli], [İlçesi], [Ülkesi], [Şifresi], [AdminID]) VALUES (1, N'k', N'k', N'Kadın', 28, N'k@', N'(555) 555-5555', N'a', N'a', N'a', N'a', N'12345678', NULL)
SET IDENTITY_INSERT [dbo].[Müşteri] OFF
GO
SET IDENTITY_INSERT [dbo].[Ödeme] ON 

INSERT [dbo].[Ödeme] ([ÖdemeID], [BaşlangıçTarihi], [BitişTarihi], [KiralamaDurumu], [MüşteriID], [KiralamaID], [AdminID]) VALUES (1001, CAST(N'2020-12-23T00:00:00.000' AS DateTime), CAST(N'2020-12-27T00:00:00.000' AS DateTime), N'Tamamlandı', 1, 1000, NULL)
SET IDENTITY_INSERT [dbo].[Ödeme] OFF
GO
INSERT [dbo].[Satıcı] ([TCkimlik], [Adı], [Soyadı], [Cinsiyeti], [Yaşı], [EmailAdresi], [TelefonNumarası], [EvAdresi], [İli], [İlçesi], [Ülkesi], [Şifresi], [AdminID], [Resim]) VALUES (N'11111111111', N'ali', N'veli', N'erkek', 25, N'b@', N'(555) 555-5555', N'a', N'a', N'a', N'a', N'12345678', NULL, NULL)
GO
ALTER TABLE [dbo].[Araç]  WITH CHECK ADD  CONSTRAINT [FK_Araç_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Araç] CHECK CONSTRAINT [FK_Araç_Admin]
GO
ALTER TABLE [dbo].[Araç]  WITH CHECK ADD  CONSTRAINT [FK_Araç_AraçKategorisi] FOREIGN KEY([KategoriID])
REFERENCES [dbo].[AraçKategorisi] ([KategoriID])
GO
ALTER TABLE [dbo].[Araç] CHECK CONSTRAINT [FK_Araç_AraçKategorisi]
GO
ALTER TABLE [dbo].[Araç]  WITH CHECK ADD  CONSTRAINT [FK_Araç_Satıcı] FOREIGN KEY([TCkimlik])
REFERENCES [dbo].[Satıcı] ([TCkimlik])
GO
ALTER TABLE [dbo].[Araç] CHECK CONSTRAINT [FK_Araç_Satıcı]
GO
ALTER TABLE [dbo].[AraçKategorisi]  WITH CHECK ADD  CONSTRAINT [FK_AraçKategorisi_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[AraçKategorisi] CHECK CONSTRAINT [FK_AraçKategorisi_Admin]
GO
ALTER TABLE [dbo].[Kiralama]  WITH CHECK ADD  CONSTRAINT [FK_Kiralama_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Kiralama] CHECK CONSTRAINT [FK_Kiralama_Admin]
GO
ALTER TABLE [dbo].[Kiralama]  WITH CHECK ADD  CONSTRAINT [FK_Kiralama_Araç] FOREIGN KEY([ŞasiID])
REFERENCES [dbo].[Araç] ([ŞasiID])
GO
ALTER TABLE [dbo].[Kiralama] CHECK CONSTRAINT [FK_Kiralama_Araç]
GO
ALTER TABLE [dbo].[Müşteri]  WITH CHECK ADD  CONSTRAINT [FK_Müşteri_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Müşteri] CHECK CONSTRAINT [FK_Müşteri_Admin]
GO
ALTER TABLE [dbo].[Ödeme]  WITH CHECK ADD  CONSTRAINT [FK_Ödeme_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Ödeme] CHECK CONSTRAINT [FK_Ödeme_Admin]
GO
ALTER TABLE [dbo].[Ödeme]  WITH CHECK ADD  CONSTRAINT [FK_Ödeme_Kiralama] FOREIGN KEY([KiralamaID])
REFERENCES [dbo].[Kiralama] ([KiralamaID])
GO
ALTER TABLE [dbo].[Ödeme] CHECK CONSTRAINT [FK_Ödeme_Kiralama]
GO
ALTER TABLE [dbo].[Ödeme]  WITH CHECK ADD  CONSTRAINT [FK_Ödeme_Müşteri] FOREIGN KEY([MüşteriID])
REFERENCES [dbo].[Müşteri] ([MüşteriID])
GO
ALTER TABLE [dbo].[Ödeme] CHECK CONSTRAINT [FK_Ödeme_Müşteri]
GO
ALTER TABLE [dbo].[Satıcı]  WITH CHECK ADD  CONSTRAINT [FK_Satıcı_Admin] FOREIGN KEY([AdminID])
REFERENCES [dbo].[Admin] ([AdminID])
GO
ALTER TABLE [dbo].[Satıcı] CHECK CONSTRAINT [FK_Satıcı_Admin]
GO
USE [master]
GO
ALTER DATABASE [Car_Hire_System] SET  READ_WRITE 
GO
