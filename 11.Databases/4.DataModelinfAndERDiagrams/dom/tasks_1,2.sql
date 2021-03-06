USE [master]
GO
/****** Object:  Database [Continents_Population]    Script Date: 22.8.2014 г. 0:25:19 ******/
CREATE DATABASE [Continents_Population]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Continents_Population', FILENAME = N'D:\Programs\Microsoft SQL Server 2014\MSSQL12.MSSQLSERVER\MSSQL\DATA\Continents_Population.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Continents_Population_log', FILENAME = N'D:\Programs\Microsoft SQL Server 2014\MSSQL12.MSSQLSERVER\MSSQL\DATA\Continents_Population_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Continents_Population] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Continents_Population].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Continents_Population] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Continents_Population] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Continents_Population] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Continents_Population] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Continents_Population] SET ARITHABORT OFF 
GO
ALTER DATABASE [Continents_Population] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Continents_Population] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Continents_Population] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Continents_Population] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Continents_Population] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Continents_Population] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Continents_Population] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Continents_Population] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Continents_Population] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Continents_Population] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Continents_Population] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Continents_Population] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Continents_Population] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Continents_Population] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Continents_Population] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Continents_Population] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Continents_Population] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Continents_Population] SET RECOVERY FULL 
GO
ALTER DATABASE [Continents_Population] SET  MULTI_USER 
GO
ALTER DATABASE [Continents_Population] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Continents_Population] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Continents_Population] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Continents_Population] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Continents_Population] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Continents_Population', N'ON'
GO
USE [Continents_Population]
GO
/****** Object:  Table [dbo].[ADDRESS]    Script Date: 22.8.2014 г. 0:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ADDRESS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[address_text] [nchar](30) NULL,
	[town_id] [int] NOT NULL,
 CONSTRAINT [PK_ADDRESS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CONTINENT]    Script Date: 22.8.2014 г. 0:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTINENT](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](20) NULL,
 CONSTRAINT [PK_CONTINENT] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 22.8.2014 г. 0:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](20) NULL,
	[continent_id] [int] NOT NULL,
 CONSTRAINT [PK_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PERSON]    Script Date: 22.8.2014 г. 0:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PERSON](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nchar](20) NULL,
	[last_name] [nchar](20) NULL,
	[address_id] [int] NOT NULL,
 CONSTRAINT [PK_PERSON] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TOWN]    Script Date: 22.8.2014 г. 0:25:19 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TOWN](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nchar](20) NULL,
	[country_id] [int] NOT NULL,
 CONSTRAINT [PK_TOWN] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ADDRESS] ON 

INSERT [dbo].[ADDRESS] ([Id], [address_text], [town_id]) VALUES (6, N'23 batka str                  ', 1)
INSERT [dbo].[ADDRESS] ([Id], [address_text], [town_id]) VALUES (7, N'666 Schlampe strasse          ', 2)
INSERT [dbo].[ADDRESS] ([Id], [address_text], [town_id]) VALUES (8, N'123 something                 ', 3)
INSERT [dbo].[ADDRESS] ([Id], [address_text], [town_id]) VALUES (9, N'73 Lane                       ', 4)
SET IDENTITY_INSERT [dbo].[ADDRESS] OFF
SET IDENTITY_INSERT [dbo].[CONTINENT] ON 

INSERT [dbo].[CONTINENT] ([Id], [name]) VALUES (1, N'Africa              ')
INSERT [dbo].[CONTINENT] ([Id], [name]) VALUES (2, N'Europe              ')
INSERT [dbo].[CONTINENT] ([Id], [name]) VALUES (3, N'North America       ')
SET IDENTITY_INSERT [dbo].[CONTINENT] OFF
SET IDENTITY_INSERT [dbo].[COUNTRY] ON 

INSERT [dbo].[COUNTRY] ([Id], [name], [continent_id]) VALUES (1, N'United States       ', 3)
INSERT [dbo].[COUNTRY] ([Id], [name], [continent_id]) VALUES (2, N'SAR                 ', 1)
INSERT [dbo].[COUNTRY] ([Id], [name], [continent_id]) VALUES (3, N'Germany             ', 2)
INSERT [dbo].[COUNTRY] ([Id], [name], [continent_id]) VALUES (4, N'Bulgaria            ', 2)
SET IDENTITY_INSERT [dbo].[COUNTRY] OFF
SET IDENTITY_INSERT [dbo].[PERSON] ON 

INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (4, N'Niki                ', N'Nikev               ', 6)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (5, N'Minko               ', N'Minkov              ', 7)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (6, N'Donko               ', N'Donkov              ', 8)
INSERT [dbo].[PERSON] ([id], [first_name], [last_name], [address_id]) VALUES (7, N'Ivko                ', N'Ivkov               ', 9)
SET IDENTITY_INSERT [dbo].[PERSON] OFF
SET IDENTITY_INSERT [dbo].[TOWN] ON 

INSERT [dbo].[TOWN] ([Id], [name], [country_id]) VALUES (1, N'Burgas              ', 4)
INSERT [dbo].[TOWN] ([Id], [name], [country_id]) VALUES (2, N'Koln                ', 3)
INSERT [dbo].[TOWN] ([Id], [name], [country_id]) VALUES (3, N'Pretoria            ', 2)
INSERT [dbo].[TOWN] ([Id], [name], [country_id]) VALUES (4, N'San Antonio         ', 1)
SET IDENTITY_INSERT [dbo].[TOWN] OFF
ALTER TABLE [dbo].[ADDRESS]  WITH CHECK ADD  CONSTRAINT [FK_ADDRESS_TOWN] FOREIGN KEY([town_id])
REFERENCES [dbo].[TOWN] ([Id])
GO
ALTER TABLE [dbo].[ADDRESS] CHECK CONSTRAINT [FK_ADDRESS_TOWN]
GO
ALTER TABLE [dbo].[COUNTRY]  WITH CHECK ADD  CONSTRAINT [FK_COUNTRY_CONTINENT] FOREIGN KEY([continent_id])
REFERENCES [dbo].[CONTINENT] ([Id])
GO
ALTER TABLE [dbo].[COUNTRY] CHECK CONSTRAINT [FK_COUNTRY_CONTINENT]
GO
ALTER TABLE [dbo].[PERSON]  WITH CHECK ADD  CONSTRAINT [FK_PERSON_ADDRESS] FOREIGN KEY([address_id])
REFERENCES [dbo].[ADDRESS] ([Id])
GO
ALTER TABLE [dbo].[PERSON] CHECK CONSTRAINT [FK_PERSON_ADDRESS]
GO
ALTER TABLE [dbo].[TOWN]  WITH CHECK ADD  CONSTRAINT [FK_TOWN_COUNTRY] FOREIGN KEY([country_id])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[TOWN] CHECK CONSTRAINT [FK_TOWN_COUNTRY]
GO
USE [master]
GO
ALTER DATABASE [Continents_Population] SET  READ_WRITE 
GO
