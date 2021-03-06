USE [master]
GO
/****** Object:  Database [inventorydb]    Script Date: 5/12/2015 12:29:38 PM ******/
CREATE DATABASE [inventorydb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'inventorydb', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\inventorydb.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'inventorydb_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\inventorydb_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [inventorydb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [inventorydb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [inventorydb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [inventorydb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [inventorydb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [inventorydb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [inventorydb] SET ARITHABORT OFF 
GO
ALTER DATABASE [inventorydb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [inventorydb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [inventorydb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [inventorydb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [inventorydb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [inventorydb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [inventorydb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [inventorydb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [inventorydb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [inventorydb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [inventorydb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [inventorydb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [inventorydb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [inventorydb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [inventorydb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [inventorydb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [inventorydb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [inventorydb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [inventorydb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [inventorydb] SET  MULTI_USER 
GO
ALTER DATABASE [inventorydb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [inventorydb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [inventorydb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [inventorydb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [inventorydb]
GO
/****** Object:  Table [dbo].[product]    Script Date: 5/12/2015 12:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[product_code] [nvarchar](50) NOT NULL,
	[description] [nvarchar](50) NULL,
	[quantity] [int] NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
	[suppliar_id] [int] NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[suppliar]    Script Date: 5/12/2015 12:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[suppliar](
	[suppliar_id] [int] IDENTITY(1,1) NOT NULL,
	[suppliar_name] [varchar](50) NULL,
 CONSTRAINT [PK_suppliar] PRIMARY KEY CLUSTERED 
(
	[suppliar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[productsuppliar]    Script Date: 5/12/2015 12:29:38 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[productsuppliar]
as
SELECT product.product_code,product.description,product.quantity,suppliar.suppliar_name from product  LEFT OUTER JOIN suppliar ON product.suppliar_id = suppliar.suppliar_id;
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [product_code]    Script Date: 5/12/2015 12:29:38 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [product_code] ON [dbo].[product]
(
	[product_code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[product]  WITH CHECK ADD  CONSTRAINT [FK_product_suppliar] FOREIGN KEY([suppliar_id])
REFERENCES [dbo].[suppliar] ([suppliar_id])
GO
ALTER TABLE [dbo].[product] CHECK CONSTRAINT [FK_product_suppliar]
GO
USE [master]
GO
ALTER DATABASE [inventorydb] SET  READ_WRITE 
GO
