USE [master]
GO
/****** Object:  Database [Biblioteka]    Script Date: 6/24/2022 8:17:27 PM ******/
CREATE DATABASE [Biblioteka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'biblioteka', FILENAME = N'C:\Users\Vladimir\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\biblioteka.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'biblioteka_log', FILENAME = N'C:\Users\Vladimir\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\biblioteka.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Biblioteka] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Biblioteka] SET ANSI_NULL_DEFAULT ON 
GO
ALTER DATABASE [Biblioteka] SET ANSI_NULLS ON 
GO
ALTER DATABASE [Biblioteka] SET ANSI_PADDING ON 
GO
ALTER DATABASE [Biblioteka] SET ANSI_WARNINGS ON 
GO
ALTER DATABASE [Biblioteka] SET ARITHABORT ON 
GO
ALTER DATABASE [Biblioteka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Biblioteka] SET CURSOR_DEFAULT  LOCAL 
GO
ALTER DATABASE [Biblioteka] SET CONCAT_NULL_YIELDS_NULL ON 
GO
ALTER DATABASE [Biblioteka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Biblioteka] SET QUOTED_IDENTIFIER ON 
GO
ALTER DATABASE [Biblioteka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Biblioteka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Biblioteka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Biblioteka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Biblioteka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Biblioteka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Biblioteka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Biblioteka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Biblioteka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Biblioteka] SET RECOVERY FULL 
GO
ALTER DATABASE [Biblioteka] SET  MULTI_USER 
GO
ALTER DATABASE [Biblioteka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Biblioteka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Biblioteka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Biblioteka] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Biblioteka] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Biblioteka] SET QUERY_STORE = OFF
GO
USE [Biblioteka]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [Biblioteka]
GO
/****** Object:  Table [dbo].[Bibliotekar]    Script Date: 6/24/2022 8:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bibliotekar](
	[OsobaId] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](max) NOT NULL,
	[Prezime] [varchar](max) NOT NULL,
	[KorisnickoIme] [varchar](max) NOT NULL,
	[Sifra] [varchar](max) NOT NULL,
 CONSTRAINT [PK_Table] PRIMARY KEY CLUSTERED 
(
	[OsobaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clan]    Script Date: 6/24/2022 8:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clan](
	[OsobaId] [int] IDENTITY(1,1) NOT NULL,
	[Ime] [varchar](max) NOT NULL,
	[Prezime] [varchar](max) NOT NULL,
	[DugujeKnjige] [bit] NOT NULL,
	[TipClana] [varchar](max) NOT NULL,
	[DatumUclanjenja] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[OsobaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Iznajmljivanje]    Script Date: 6/24/2022 8:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Iznajmljivanje](
	[IznajmljivanjeId] [int] IDENTITY(1,1) NOT NULL,
	[ClanId] [int] NOT NULL,
	[DatumIzdavanja] [datetime] NOT NULL,
	[DatumVracanja] [datetime] NULL,
	[BibliotekarId] [int] NOT NULL,
	[KnjigaId] [int] NOT NULL,
 CONSTRAINT [PK_Izn] PRIMARY KEY CLUSTERED 
(
	[IznajmljivanjeId] ASC,
	[ClanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Knjiga]    Script Date: 6/24/2022 8:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Knjiga](
	[KnjigaId] [int] IDENTITY(1,1) NOT NULL,
	[NazivKnjige] [varchar](max) NOT NULL,
	[AutorKnjige] [varchar](max) NOT NULL,
	[Stanje] [int] NOT NULL,
	[ZanrId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KnjigaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Zanr]    Script Date: 6/24/2022 8:17:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Zanr](
	[ZanrId] [int] IDENTITY(1,1) NOT NULL,
	[NazivZanra] [varchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ZanrId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Bibliotekar] ON 

INSERT [dbo].[Bibliotekar] ([OsobaId], [Ime], [Prezime], [KorisnickoIme], [Sifra]) VALUES (1, N'Vladimir', N'Maljkovic', N'vladimir', N'vladimir')
SET IDENTITY_INSERT [dbo].[Bibliotekar] OFF
GO
SET IDENTITY_INSERT [dbo].[Clan] ON 

INSERT [dbo].[Clan] ([OsobaId], [Ime], [Prezime], [DugujeKnjige], [TipClana], [DatumUclanjenja]) VALUES (1, N'milos', N'milios', 1, N'Fizicko lice', CAST(N'2022-06-13T18:13:26.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Clan] OFF
GO
SET IDENTITY_INSERT [dbo].[Iznajmljivanje] ON 

INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeId], [ClanId], [DatumIzdavanja], [DatumVracanja], [BibliotekarId], [KnjigaId]) VALUES (8, 1, CAST(N'2022-06-21T19:17:31.000' AS DateTime), CAST(N'2022-06-23T01:22:30.000' AS DateTime), 1, 1)
INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeId], [ClanId], [DatumIzdavanja], [DatumVracanja], [BibliotekarId], [KnjigaId]) VALUES (12, 1, CAST(N'2022-06-21T19:21:50.000' AS DateTime), CAST(N'2022-06-23T01:22:30.000' AS DateTime), 1, 1)
INSERT [dbo].[Iznajmljivanje] ([IznajmljivanjeId], [ClanId], [DatumIzdavanja], [DatumVracanja], [BibliotekarId], [KnjigaId]) VALUES (13, 1, CAST(N'2022-06-21T19:21:50.000' AS DateTime), CAST(N'2022-06-23T01:22:30.000' AS DateTime), 1, 2)
SET IDENTITY_INSERT [dbo].[Iznajmljivanje] OFF
GO
SET IDENTITY_INSERT [dbo].[Knjiga] ON 

INSERT [dbo].[Knjiga] ([KnjigaId], [NazivKnjige], [AutorKnjige], [Stanje], [ZanrId]) VALUES (1, N'qqq', N'wwww', 38, 2)
INSERT [dbo].[Knjiga] ([KnjigaId], [NazivKnjige], [AutorKnjige], [Stanje], [ZanrId]) VALUES (2, N'ff', N'fff', 13, 2)
SET IDENTITY_INSERT [dbo].[Knjiga] OFF
GO
SET IDENTITY_INSERT [dbo].[Zanr] ON 

INSERT [dbo].[Zanr] ([ZanrId], [NazivZanra]) VALUES (1, N'Naucna fantastika')
INSERT [dbo].[Zanr] ([ZanrId], [NazivZanra]) VALUES (2, N'Drama')
SET IDENTITY_INSERT [dbo].[Zanr] OFF
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Bibliotekar] FOREIGN KEY([BibliotekarId])
REFERENCES [dbo].[Bibliotekar] ([OsobaId])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Bibliotekar]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Clan] FOREIGN KEY([ClanId])
REFERENCES [dbo].[Clan] ([OsobaId])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Clan]
GO
ALTER TABLE [dbo].[Iznajmljivanje]  WITH CHECK ADD  CONSTRAINT [FK_Iznajmljivanje_Knjiga] FOREIGN KEY([KnjigaId])
REFERENCES [dbo].[Knjiga] ([KnjigaId])
GO
ALTER TABLE [dbo].[Iznajmljivanje] CHECK CONSTRAINT [FK_Iznajmljivanje_Knjiga]
GO
ALTER TABLE [dbo].[Knjiga]  WITH CHECK ADD  CONSTRAINT [FK_Knjiga_Zanr] FOREIGN KEY([ZanrId])
REFERENCES [dbo].[Zanr] ([ZanrId])
GO
ALTER TABLE [dbo].[Knjiga] CHECK CONSTRAINT [FK_Knjiga_Zanr]
GO
USE [master]
GO
ALTER DATABASE [Biblioteka] SET  READ_WRITE 
GO
