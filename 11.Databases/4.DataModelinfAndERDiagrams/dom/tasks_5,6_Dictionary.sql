USE [master]
GO
/****** Object:  Database [Dictionary]    Script Date: 24.8.2014 г. 1:12:50 ******/
CREATE DATABASE [Dictionary]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Dictionary', FILENAME = N'D:\Programs\Microsoft SQL Server 2014\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dictionary.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Dictionary_log', FILENAME = N'D:\Programs\Microsoft SQL Server 2014\MSSQL12.MSSQLSERVER\MSSQL\DATA\Dictionary_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Dictionary] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Dictionary].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Dictionary] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Dictionary] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Dictionary] SET ARITHABORT OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Dictionary] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Dictionary] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Dictionary] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Dictionary] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Dictionary] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Dictionary] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Dictionary] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Dictionary] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Dictionary] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Dictionary] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Dictionary] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Dictionary] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Dictionary] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Dictionary] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Dictionary] SET RECOVERY FULL 
GO
ALTER DATABASE [Dictionary] SET  MULTI_USER 
GO
ALTER DATABASE [Dictionary] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Dictionary] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Dictionary] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Dictionary] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Dictionary] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Dictionary', N'ON'
GO
USE [Dictionary]
GO
/****** Object:  Table [dbo].[Antonyms]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Antonyms](
	[firstwordID] [int] NOT NULL,
	[secondwordID] [int] NOT NULL,
 CONSTRAINT [PK_Antonyms] PRIMARY KEY CLUSTERED 
(
	[firstwordID] ASC,
	[secondwordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Explanations]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Explanations](
	[explanationID] [int] IDENTITY(1,1) NOT NULL,
	[wordID] [int] NOT NULL,
	[languageID] [int] NOT NULL,
	[value] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED 
(
	[explanationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Languages]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Languages](
	[languageID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](20) NOT NULL,
 CONSTRAINT [PK_Languages] PRIMARY KEY CLUSTERED 
(
	[languageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PartsOfSpeech]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PartsOfSpeech](
	[PartOfSpeechID] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nchar](20) NOT NULL,
 CONSTRAINT [PK_PartsOfSpeech] PRIMARY KEY CLUSTERED 
(
	[PartOfSpeechID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Synonyms]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Synonyms](
	[firstwordID] [int] NOT NULL,
	[secondwordID] [int] NOT NULL,
 CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED 
(
	[firstwordID] ASC,
	[secondwordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Translations]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Translations](
	[translationID] [int] NOT NULL,
	[wordID] [int] NOT NULL,
 CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED 
(
	[translationID] ASC,
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Words]    Script Date: 24.8.2014 г. 1:12:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Words](
	[wordID] [int] IDENTITY(1,1) NOT NULL,
	[languageID] [int] NOT NULL,
	[value] [nchar](30) NOT NULL,
	[partofspeechID] [int] NULL,
	[hypernymID] [int] NULL,
 CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED 
(
	[wordID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Antonyms_Words] FOREIGN KEY([firstwordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Antonyms] CHECK CONSTRAINT [FK_Antonyms_Words]
GO
ALTER TABLE [dbo].[Antonyms]  WITH CHECK ADD  CONSTRAINT [FK_Antonyms_Words1] FOREIGN KEY([secondwordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Antonyms] CHECK CONSTRAINT [FK_Antonyms_Words1]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Languages] FOREIGN KEY([languageID])
REFERENCES [dbo].[Languages] ([languageID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Languages]
GO
ALTER TABLE [dbo].[Explanations]  WITH CHECK ADD  CONSTRAINT [FK_Explanations_Words] FOREIGN KEY([wordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Explanations] CHECK CONSTRAINT [FK_Explanations_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words] FOREIGN KEY([firstwordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words]
GO
ALTER TABLE [dbo].[Synonyms]  WITH CHECK ADD  CONSTRAINT [FK_Synonyms_Words1] FOREIGN KEY([secondwordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Synonyms] CHECK CONSTRAINT [FK_Synonyms_Words1]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words2] FOREIGN KEY([translationID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words2]
GO
ALTER TABLE [dbo].[Translations]  WITH CHECK ADD  CONSTRAINT [FK_Translations_Words3] FOREIGN KEY([wordID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Translations] CHECK CONSTRAINT [FK_Translations_Words3]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Languages] FOREIGN KEY([languageID])
REFERENCES [dbo].[Languages] ([languageID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Languages]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_PartsOfSpeech] FOREIGN KEY([partofspeechID])
REFERENCES [dbo].[PartsOfSpeech] ([PartOfSpeechID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_PartsOfSpeech]
GO
ALTER TABLE [dbo].[Words]  WITH CHECK ADD  CONSTRAINT [FK_Words_Words] FOREIGN KEY([hypernymID])
REFERENCES [dbo].[Words] ([wordID])
GO
ALTER TABLE [dbo].[Words] CHECK CONSTRAINT [FK_Words_Words]
GO
USE [master]
GO
ALTER DATABASE [Dictionary] SET  READ_WRITE 
GO
