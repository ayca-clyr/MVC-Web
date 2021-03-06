
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MhrsWebDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MhrsWebDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MhrsWebDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MhrsWebDB_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MhrsWebDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MhrsWebDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MhrsWebDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MhrsWebDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MhrsWebDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MhrsWebDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MhrsWebDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [MhrsWebDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MhrsWebDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MhrsWebDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MhrsWebDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MhrsWebDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MhrsWebDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MhrsWebDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MhrsWebDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MhrsWebDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MhrsWebDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MhrsWebDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MhrsWebDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MhrsWebDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MhrsWebDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MhrsWebDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MhrsWebDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MhrsWebDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MhrsWebDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MhrsWebDB] SET  MULTI_USER 
GO
ALTER DATABASE [MhrsWebDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MhrsWebDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MhrsWebDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MhrsWebDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MhrsWebDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MhrsWebDB]
GO
/****** Object:  Table [dbo].[Cinsiyet]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cinsiyet](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Cinsiyet] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Command]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Command](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Command] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doktor]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doktor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[CinsiyetId] [int] NULL,
	[UzmanlıkId] [int] NULL,
	[HastaneId] [int] NULL,
 CONSTRAINT [PK_Doktor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hastane]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastane](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[IlceId] [int] NULL,
 CONSTRAINT [PK_Hastane] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Hastane_Klinik]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastane_Klinik](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[HastaneId] [int] NOT NULL,
	[KlinikId] [int] NOT NULL,
 CONSTRAINT [PK_Hastane_Klinik_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ilce]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ilce](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[SehirId] [int] NULL,
 CONSTRAINT [PK_Ilce] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Klinik]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Klinik](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Klinik] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kullanici]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanici](
	[TC] [nvarchar](11) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[CinsiyetId] [int] NOT NULL,
	[DateOfBirth] [date] NULL,
	[CommandId] [int] NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Kullanici] PRIMARY KEY CLUSTERED 
(
	[TC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Login]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Login](
	[TC] [nvarchar](11) NOT NULL,
	[Password] [nvarchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[TC] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Randevu]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Randevu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LoginTC] [nvarchar](11) NULL,
	[Hastane_Klinik_Id] [int] NULL,
	[DoktorId] [int] NULL,
	[RandevuSaatiId] [int] NULL,
	[Tarih] [date] NULL,
 CONSTRAINT [PK_Randevu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RandevuSaati]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RandevuSaati](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Saat] [time](7) NULL,
 CONSTRAINT [PK_RandevuSaati] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[RandvuSaati_Doktor]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RandvuSaati_Doktor](
	[RandevuTarihi] [date] NOT NULL,
	[RandevuSaatiId] [int] NOT NULL,
	[DoktorId] [int] NOT NULL,
	[Durum] [bit] NULL,
 CONSTRAINT [PK_RandvuSaati_Doktor] PRIMARY KEY CLUSTERED 
(
	[RandevuTarihi] ASC,
	[RandevuSaatiId] ASC,
	[DoktorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sehir]    Script Date: 23.08.2018 14:42:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sehir](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK_Sehir] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Cinsiyet] ON 

INSERT [dbo].[Cinsiyet] ([Id], [Name]) VALUES (1, N'Erkek')
INSERT [dbo].[Cinsiyet] ([Id], [Name]) VALUES (2, N'Kadın')
SET IDENTITY_INSERT [dbo].[Cinsiyet] OFF
SET IDENTITY_INSERT [dbo].[Command] ON 

INSERT [dbo].[Command] ([Id], [Name]) VALUES (2, N'Admin')
INSERT [dbo].[Command] ([Id], [Name]) VALUES (3, N'Hasta')
SET IDENTITY_INSERT [dbo].[Command] OFF
SET IDENTITY_INSERT [dbo].[Doktor] ON 

INSERT [dbo].[Doktor] ([Id], [FullName], [CinsiyetId], [UzmanlıkId], [HastaneId]) VALUES (1, N'Ayça Calayır', 2, 4, 4)
INSERT [dbo].[Doktor] ([Id], [FullName], [CinsiyetId], [UzmanlıkId], [HastaneId]) VALUES (2, N'Burak Kaya', 1, 5, 3)
INSERT [dbo].[Doktor] ([Id], [FullName], [CinsiyetId], [UzmanlıkId], [HastaneId]) VALUES (4, N'ferhat', 1, 4, 5)
INSERT [dbo].[Doktor] ([Id], [FullName], [CinsiyetId], [UzmanlıkId], [HastaneId]) VALUES (5, N'turgay', 1, 4, 5)
INSERT [dbo].[Doktor] ([Id], [FullName], [CinsiyetId], [UzmanlıkId], [HastaneId]) VALUES (7, N'Kamuran Kuru', 1, 5, 3)
INSERT [dbo].[Doktor] ([Id], [FullName], [CinsiyetId], [UzmanlıkId], [HastaneId]) VALUES (8, N'Hasan Çelik', 1, 5, 3)
SET IDENTITY_INSERT [dbo].[Doktor] OFF
SET IDENTITY_INSERT [dbo].[Hastane] ON 

INSERT [dbo].[Hastane] ([Id], [Name], [IlceId]) VALUES (3, N'Okmeydanı SSK', 44)
INSERT [dbo].[Hastane] ([Id], [Name], [IlceId]) VALUES (4, N'Avcılar Murat Körlüklü', 5)
INSERT [dbo].[Hastane] ([Id], [Name], [IlceId]) VALUES (5, N'Bornova Hastanesi', 51)
SET IDENTITY_INSERT [dbo].[Hastane] OFF
SET IDENTITY_INSERT [dbo].[Hastane_Klinik] ON 

INSERT [dbo].[Hastane_Klinik] ([Id], [HastaneId], [KlinikId]) VALUES (13, 3, 4)
INSERT [dbo].[Hastane_Klinik] ([Id], [HastaneId], [KlinikId]) VALUES (14, 4, 5)
INSERT [dbo].[Hastane_Klinik] ([Id], [HastaneId], [KlinikId]) VALUES (15, 4, 4)
INSERT [dbo].[Hastane_Klinik] ([Id], [HastaneId], [KlinikId]) VALUES (16, 3, 5)
INSERT [dbo].[Hastane_Klinik] ([Id], [HastaneId], [KlinikId]) VALUES (20, 4, 6)
SET IDENTITY_INSERT [dbo].[Hastane_Klinik] OFF
SET IDENTITY_INSERT [dbo].[Ilce] ON 

INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (1, N'SEYHAN', 1)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (2, N'CEYHAN', 1)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (3, N'FEKE', 1)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (4, N'KARAİSALI', 2)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (5, N'AVCILAR', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (6, N'KOZAN', 2)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (7, N'POZANTI', 3)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (8, N'SAİMBEYLİ', 3)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (9, N'TUFANBEYLİ', 3)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (10, N'YUMURTALIK', 4)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (11, N'YÜREĞİR', 4)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (12, N'ALADAĞ', 4)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (13, N'AISUDY', 5)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (14, N'ADIYAMAN MERKEZ', 5)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (15, N'BESNİ', 5)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (16, N'ÇELİKHAN', 6)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (17, N'GERGER', 7)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (18, N'GÖLBAŞI', 8)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (19, N'KAHTA', 9)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (20, N'SAMSAT', 10)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (21, N'SİNCİK', 11)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (22, N'TUT', 12)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (23, N'AFYONMERKEZ', 13)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (24, N'BOLVADİN', 14)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (25, N'ÇAY', 15)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (26, N'DAZKIRI', 16)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (27, N'DİNAR', 17)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (28, N'EMİRDAĞ', 18)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (29, N'İHSANİYE', 19)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (30, N'SANDIKLI', 20)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (31, N'SİNANPAŞA', 21)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (32, N'SULDANDAĞI', 22)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (33, N'ŞUHUT', 23)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (34, N'BAŞMAKÇI', 24)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (35, N'BAYAT', 25)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (36, N'İŞCEHİSAR', 26)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (37, N'ÇOBANLAR', 27)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (38, N'EVCİLER', 28)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (39, N'HOCALAR', 29)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (40, N'KIZILÖREN', 30)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (41, N'AKSARAY MERKEZ', 31)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (42, N'ORTAKÖY', 32)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (43, N'AĞAÇÖREN', 33)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (44, N'OKMEYDANI', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (45, N'SARIYAHŞİ', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (46, N'ESKİL', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (47, N'GÜLAĞAÇ', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (48, N'AMASYA MERKEZ', 35)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (49, N'GÖYNÜÇEK', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (50, N'GÜMÜŞHACIKÖYÜ', 34)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (51, N'BORNOVA', 35)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (52, N'SULUOVA', 35)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (53, N'TAŞOVA', 35)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (54, N'HAMAMÖZÜ', 36)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (55, N'ALTINDAĞ', 37)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (56, N'AYAS', 38)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (57, N'BALA', 39)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (58, N'BEYPAZARI', 40)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (59, N'ÇAMLIDERE', 41)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (60, N'ÇANKAYA', 42)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (61, N'ÇUBUK', 43)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (62, N'ELMADAĞ', 44)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (63, N'GÜDÜL', 45)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (64, N'HAYMANA', 46)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (65, N'KALECİK', 47)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (66, N'KIZILCAHAMAM', 48)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (67, N'NALLIHAN', 49)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (68, N'POLATLI', 50)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (69, N'ŞEREFLİKOÇHİSAR', 51)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (70, N'YENİMAHALLE', 52)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (71, N'GÖLBAŞI', 53)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (72, N'KEÇİÖREN', 54)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (73, N'MAMAK', 55)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (74, N'SİNCAN', 56)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (75, N'KAZAN', 57)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (76, N'AKYURT', 58)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (77, N'ETİMESGUT', 59)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (78, N'EVREN', 60)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (79, N'ANSEKİ', 61)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (80, N'ALANYA', 62)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (81, N'ANTALYA MERKEZİ', 63)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (82, N'ELMALI', 64)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (83, N'FİNİKE', 65)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (84, N'GAZİPAŞA', 66)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (85, N'GÜNDOĞMUŞ', 67)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (86, N'KAŞ', 68)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (87, N'KORKUTELİ', 69)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (88, N'KUMLUCA', 70)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (89, N'MANAVGAT', 71)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (90, N'SERİK', 72)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (91, N'DEMRE', 73)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (92, N'İBRADI', 74)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (93, N'KEMER', 75)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (94, N'ARDAHAN MERKEZ', 75)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (95, N'GÖLE', 76)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (96, N'ÇILDIR', 77)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (97, N'HANAK', 78)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (98, N'POSOF', 79)
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (99, N'DAMAL', 80)
GO
INSERT [dbo].[Ilce] ([Id], [Name], [SehirId]) VALUES (100, N'ARDANUÇ', 81)
SET IDENTITY_INSERT [dbo].[Ilce] OFF
SET IDENTITY_INSERT [dbo].[Klinik] ON 

INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (4, N'Cildiye')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (5, N'Ortopedi')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (6, N'Nöroloji')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (7, N'KBB')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (8, N'Fizik Tedavi')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (9, N'Dahiliye')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (10, N'Genel Cerrahi')
INSERT [dbo].[Klinik] ([Id], [Name]) VALUES (11, N'Plastik Cerrahi')
SET IDENTITY_INSERT [dbo].[Klinik] OFF
INSERT [dbo].[Kullanici] ([TC], [Name], [Surname], [CinsiyetId], [DateOfBirth], [CommandId], [Email]) VALUES (N'11111111111', N'Ayça', N'Calayır', 2, CAST(N'1992-10-15' AS Date), 3, N'asdasd@asd.com')
INSERT [dbo].[Kullanici] ([TC], [Name], [Surname], [CinsiyetId], [DateOfBirth], [CommandId], [Email]) VALUES (N'12345678901', N'Burak', N'Kaya', 1, CAST(N'1991-11-15' AS Date), 2, N'gunduz-kusagi@hotmail.com')
INSERT [dbo].[Kullanici] ([TC], [Name], [Surname], [CinsiyetId], [DateOfBirth], [CommandId], [Email]) VALUES (N'22222222222', N'Serkan', N'Soydam', 1, CAST(N'1991-05-30' AS Date), 3, N'serkan@gmail.com')
INSERT [dbo].[Kullanici] ([TC], [Name], [Surname], [CinsiyetId], [DateOfBirth], [CommandId], [Email]) VALUES (N'44444444444', N'test', N'test', 1, CAST(N'1991-02-22' AS Date), 3, N'serkanddddd@gmail.com')
INSERT [dbo].[Login] ([TC], [Password]) VALUES (N'11111111111', N'39109a5bb10ccb7aff1313d369804b74')
INSERT [dbo].[Login] ([TC], [Password]) VALUES (N'12345678901', N'39109a5bb10ccb7aff1313d369804b74')
INSERT [dbo].[Login] ([TC], [Password]) VALUES (N'22222222222', N'39109a5bb10ccb7aff1313d369804b74')
INSERT [dbo].[Login] ([TC], [Password]) VALUES (N'44444444444', N'39109a5bb10ccb7aff1313d369804b74')
SET IDENTITY_INSERT [dbo].[Randevu] ON 

INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (1, N'11111111111', 15, 1, 1, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (2, N'11111111111', 15, 1, 5, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (3, N'11111111111', 15, 1, 5, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (4, N'11111111111', 15, 1, 5, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (5, N'11111111111', 15, 1, 5, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (6, N'11111111111', 15, 1, 2, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (7, N'11111111111', 15, 1, 7, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (8, N'11111111111', 15, 1, 7, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (9, N'11111111111', 15, 1, 7, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (10, N'11111111111', 15, 1, 7, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (11, N'11111111111', 15, 1, 7, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (12, N'11111111111', 15, 1, 4, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (13, N'11111111111', 15, 1, 6, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (14, N'11111111111', 15, 1, 3, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (15, N'22222222222', 16, 7, 1, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (16, N'22222222222', 16, 7, 3, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (17, N'22222222222', 16, 7, 2, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (18, N'22222222222', 16, 7, 5, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (19, N'22222222222', 16, 8, 14, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (20, N'22222222222', 16, 7, 11, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (21, N'22222222222', 16, 7, 13, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (22, N'22222222222', 16, 8, 1, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (23, N'22222222222', 16, 8, 5, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (24, N'22222222222', 15, 1, 24, CAST(N'2018-08-12' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (25, N'22222222222', 15, 1, 1, CAST(N'2018-08-12' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (26, N'44444444444', 15, 1, 23, CAST(N'2018-08-09' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (27, N'44444444444', 16, 8, 23, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (28, N'44444444444', 16, 7, 24, CAST(N'2018-08-27' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (29, N'44444444444', 15, 1, 24, CAST(N'2018-09-07' AS Date))
INSERT [dbo].[Randevu] ([Id], [LoginTC], [Hastane_Klinik_Id], [DoktorId], [RandevuSaatiId], [Tarih]) VALUES (30, N'44444444444', 15, 1, 5, CAST(N'2018-09-07' AS Date))
SET IDENTITY_INSERT [dbo].[Randevu] OFF
SET IDENTITY_INSERT [dbo].[RandevuSaati] ON 

INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (1, CAST(N'09:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (2, CAST(N'09:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (3, CAST(N'09:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (4, CAST(N'10:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (5, CAST(N'10:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (6, CAST(N'10:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (7, CAST(N'11:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (8, CAST(N'11:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (9, CAST(N'11:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (10, CAST(N'13:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (11, CAST(N'13:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (12, CAST(N'13:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (13, CAST(N'14:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (14, CAST(N'14:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (15, CAST(N'14:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (16, CAST(N'15:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (17, CAST(N'15:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (18, CAST(N'15:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (19, CAST(N'16:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (20, CAST(N'16:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (21, CAST(N'16:40:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (22, CAST(N'17:00:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (23, CAST(N'17:20:00' AS Time))
INSERT [dbo].[RandevuSaati] ([Id], [Saat]) VALUES (24, CAST(N'17:40:00' AS Time))
SET IDENTITY_INSERT [dbo].[RandevuSaati] OFF
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 1, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 4, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 5, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 6, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 7, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 8, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 9, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 10, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 11, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 12, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 13, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 14, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 15, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 16, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 17, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 18, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 19, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 20, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 21, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 23, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-09' AS Date), 24, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 1, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 1, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 2, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 3, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 4, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 4, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 5, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 5, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 6, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 6, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 7, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 7, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 8, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 8, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 9, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 9, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 10, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 10, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 11, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 11, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 12, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 12, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 13, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 13, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 14, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 14, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 15, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 15, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 16, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 16, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 17, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 17, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 18, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 18, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 19, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 19, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 20, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 20, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 21, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 21, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 22, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 23, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 23, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 24, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-12' AS Date), 24, 5, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 1, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 4, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 5, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 6, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 7, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 8, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 9, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 10, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 11, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 12, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 13, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 14, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 15, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 16, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 17, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 18, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 19, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 20, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 21, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 23, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-20' AS Date), 24, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 1, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 4, 1, 1)
GO
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 5, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 6, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 7, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 8, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 9, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 10, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 11, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 12, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 13, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 14, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 15, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 16, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 17, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 18, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 19, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 20, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 21, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 23, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-24' AS Date), 24, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 1, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 1, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 1, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 1, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 1, 8, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 2, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 2, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 2, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 2, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 2, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 3, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 3, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 3, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 3, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 3, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 4, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 4, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 4, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 4, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 4, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 5, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 5, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 5, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 5, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 5, 8, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 6, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 6, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 6, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 6, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 6, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 7, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 7, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 7, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 7, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 7, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 8, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 8, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 8, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 8, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 8, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 9, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 9, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 9, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 9, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 9, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 10, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 10, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 10, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 10, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 10, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 11, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 11, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 11, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 11, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 11, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 12, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 12, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 12, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 12, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 12, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 13, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 13, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 13, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 13, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 13, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 14, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 14, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 14, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 14, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 14, 8, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 15, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 15, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 15, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 15, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 15, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 16, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 16, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 16, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 16, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 16, 8, 1)
GO
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 17, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 17, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 17, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 17, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 17, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 18, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 18, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 18, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 18, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 18, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 19, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 19, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 19, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 19, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 19, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 20, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 20, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 20, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 20, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 20, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 21, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 21, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 21, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 21, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 21, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 22, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 22, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 22, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 22, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 22, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 23, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 23, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 23, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 23, 7, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 23, 8, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 24, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 24, 4, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 24, 5, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 24, 7, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-27' AS Date), 24, 8, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 1, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 4, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 5, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 6, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 7, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 8, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 9, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 10, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 11, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 12, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 13, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 14, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 15, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 16, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 17, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 18, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 19, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 20, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 21, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 23, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-28' AS Date), 24, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 1, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 4, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 5, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 6, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 7, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 8, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 9, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 10, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 11, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 12, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 13, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 14, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 15, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 16, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 17, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 18, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 19, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 20, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 21, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 23, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-08-31' AS Date), 24, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 1, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 2, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 3, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 4, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 5, 1, 0)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 6, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 7, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 8, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 9, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 10, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 11, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 12, 1, 1)
GO
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 13, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 14, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 15, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 16, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 17, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 18, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 19, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 20, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 21, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 22, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 23, 1, 1)
INSERT [dbo].[RandvuSaati_Doktor] ([RandevuTarihi], [RandevuSaatiId], [DoktorId], [Durum]) VALUES (CAST(N'2018-09-07' AS Date), 24, 1, 0)
SET IDENTITY_INSERT [dbo].[Sehir] ON 

INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (1, N'ADANA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (2, N'ADIYAMAN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (3, N'AFYON')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (4, N'AĞRI')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (5, N'AMASYA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (6, N'ANKARA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (7, N'ANTALYA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (8, N'ARTVİN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (9, N'AYDIN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (10, N'BALIKESİR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (11, N'BİLECİK')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (12, N'BİNGÖL')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (13, N'BİTLİS')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (14, N'BOLU')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (15, N'BURDUR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (16, N'BURSA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (17, N'ÇANAKKALE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (18, N'ÇANKIRI')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (19, N'ÇORUM')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (20, N'DENİZLİ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (21, N'DİYARBAKIR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (22, N'EDİRNE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (23, N'ELAZIĞ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (24, N'ERZİNCAN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (25, N'ERZURUM')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (26, N'ESKİŞEHİR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (27, N'GAZİANTEP')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (28, N'GİRESUN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (29, N'GÜMÜŞHANE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (30, N'HAKKARİ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (31, N'HATAY')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (32, N'ISPARTA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (33, N'İÇEL')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (34, N'İSTANBUL')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (35, N'İZMİR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (36, N'KARS')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (37, N'KASTAMONU')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (38, N'KAYSERİ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (39, N'KIRKLARELİ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (40, N'KIRŞEHİR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (41, N'KOCAELİ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (42, N'KONYA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (43, N'KÜTAHYA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (44, N'MALATYA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (45, N'MANİSA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (46, N'KAHRAMANMARAŞ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (47, N'MARDİN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (48, N'MUĞLA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (49, N'MUŞ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (50, N'NEVŞEHİR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (51, N'NİĞDE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (52, N'ORDU')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (53, N'RİZE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (54, N'SAKARYA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (55, N'SAMSUN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (56, N'SİİRT')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (57, N'SİNOP')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (58, N'SİVAS')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (59, N'TEKİRDAĞ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (60, N'TOKAT')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (61, N'TRABZON')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (62, N'TUNCELİ')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (63, N'ŞANLIURFA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (64, N'UŞAK')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (65, N'VAN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (66, N'YOZGAT')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (67, N'ZONGULDAK')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (68, N'AKSARAY')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (69, N'BAYBURT')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (70, N'KARAMAN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (71, N'KIRIKKALE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (72, N'BATMAN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (73, N'ŞIRNAK')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (74, N'BARTIN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (75, N'ARDAHAN')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (76, N'IĞDIR')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (77, N'YALOVA')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (78, N'KARABÜK')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (79, N'KİLİS')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (80, N'OSMANİYE')
INSERT [dbo].[Sehir] ([Id], [Name]) VALUES (81, N'DÜZCE')
SET IDENTITY_INSERT [dbo].[Sehir] OFF
ALTER TABLE [dbo].[Doktor]  WITH CHECK ADD  CONSTRAINT [FK_Doktor_Cinsiyet] FOREIGN KEY([CinsiyetId])
REFERENCES [dbo].[Cinsiyet] ([Id])
GO
ALTER TABLE [dbo].[Doktor] CHECK CONSTRAINT [FK_Doktor_Cinsiyet]
GO
ALTER TABLE [dbo].[Doktor]  WITH CHECK ADD  CONSTRAINT [FK_Doktor_Hastane] FOREIGN KEY([HastaneId])
REFERENCES [dbo].[Hastane] ([Id])
GO
ALTER TABLE [dbo].[Doktor] CHECK CONSTRAINT [FK_Doktor_Hastane]
GO
ALTER TABLE [dbo].[Doktor]  WITH CHECK ADD  CONSTRAINT [FK_Doktor_Klinik] FOREIGN KEY([UzmanlıkId])
REFERENCES [dbo].[Klinik] ([Id])
GO
ALTER TABLE [dbo].[Doktor] CHECK CONSTRAINT [FK_Doktor_Klinik]
GO
ALTER TABLE [dbo].[Hastane]  WITH CHECK ADD  CONSTRAINT [FK_Hastane_Ilce] FOREIGN KEY([IlceId])
REFERENCES [dbo].[Ilce] ([Id])
GO
ALTER TABLE [dbo].[Hastane] CHECK CONSTRAINT [FK_Hastane_Ilce]
GO
ALTER TABLE [dbo].[Hastane_Klinik]  WITH CHECK ADD  CONSTRAINT [FK_Hastane_Klinik_Hastane] FOREIGN KEY([HastaneId])
REFERENCES [dbo].[Hastane] ([Id])
GO
ALTER TABLE [dbo].[Hastane_Klinik] CHECK CONSTRAINT [FK_Hastane_Klinik_Hastane]
GO
ALTER TABLE [dbo].[Hastane_Klinik]  WITH CHECK ADD  CONSTRAINT [FK_Hastane_Klinik_Klinik] FOREIGN KEY([KlinikId])
REFERENCES [dbo].[Klinik] ([Id])
GO
ALTER TABLE [dbo].[Hastane_Klinik] CHECK CONSTRAINT [FK_Hastane_Klinik_Klinik]
GO
ALTER TABLE [dbo].[Ilce]  WITH CHECK ADD  CONSTRAINT [FK_Ilce_Sehir] FOREIGN KEY([SehirId])
REFERENCES [dbo].[Sehir] ([Id])
GO
ALTER TABLE [dbo].[Ilce] CHECK CONSTRAINT [FK_Ilce_Sehir]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Cinsiyet] FOREIGN KEY([CinsiyetId])
REFERENCES [dbo].[Cinsiyet] ([Id])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Cinsiyet]
GO
ALTER TABLE [dbo].[Kullanici]  WITH CHECK ADD  CONSTRAINT [FK_Kullanici_Command] FOREIGN KEY([CommandId])
REFERENCES [dbo].[Command] ([Id])
GO
ALTER TABLE [dbo].[Kullanici] CHECK CONSTRAINT [FK_Kullanici_Command]
GO
ALTER TABLE [dbo].[Login]  WITH CHECK ADD  CONSTRAINT [FK_Login_Kullanici] FOREIGN KEY([TC])
REFERENCES [dbo].[Kullanici] ([TC])
GO
ALTER TABLE [dbo].[Login] CHECK CONSTRAINT [FK_Login_Kullanici]
GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_Doktor] FOREIGN KEY([DoktorId])
REFERENCES [dbo].[Doktor] ([Id])
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_Doktor]
GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_Login] FOREIGN KEY([LoginTC])
REFERENCES [dbo].[Login] ([TC])
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_Login]
GO
ALTER TABLE [dbo].[Randevu]  WITH CHECK ADD  CONSTRAINT [FK_Randevu_RandevuSaati] FOREIGN KEY([RandevuSaatiId])
REFERENCES [dbo].[RandevuSaati] ([Id])
GO
ALTER TABLE [dbo].[Randevu] CHECK CONSTRAINT [FK_Randevu_RandevuSaati]
GO
ALTER TABLE [dbo].[RandvuSaati_Doktor]  WITH CHECK ADD  CONSTRAINT [FK_RandvuSaati_Doktor_Doktor] FOREIGN KEY([DoktorId])
REFERENCES [dbo].[Doktor] ([Id])
GO
ALTER TABLE [dbo].[RandvuSaati_Doktor] CHECK CONSTRAINT [FK_RandvuSaati_Doktor_Doktor]
GO
ALTER TABLE [dbo].[RandvuSaati_Doktor]  WITH CHECK ADD  CONSTRAINT [FK_RandvuSaati_Doktor_RandevuSaati] FOREIGN KEY([RandevuSaatiId])
REFERENCES [dbo].[RandevuSaati] ([Id])
GO
ALTER TABLE [dbo].[RandvuSaati_Doktor] CHECK CONSTRAINT [FK_RandvuSaati_Doktor_RandevuSaati]
GO
USE [master]
GO
ALTER DATABASE [MhrsWebDB] SET  READ_WRITE 
GO
