USE [master]
GO
/****** Object:  Database [Avtomat]    Script Date: 11.02.2022 20:16:16 ******/
CREATE DATABASE [Avtomat]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Avtomat', FILENAME = N'b:\SQL\MSSQL11.SQLEXPRESS\MSSQL\DATA\Avtomat.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Avtomat_log', FILENAME = N'b:\SQL\MSSQL11.SQLEXPRESS\MSSQL\DATA\Avtomat_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Avtomat] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Avtomat].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Avtomat] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Avtomat] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Avtomat] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Avtomat] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Avtomat] SET ARITHABORT OFF 
GO
ALTER DATABASE [Avtomat] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Avtomat] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Avtomat] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Avtomat] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Avtomat] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Avtomat] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Avtomat] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Avtomat] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Avtomat] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Avtomat] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Avtomat] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Avtomat] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Avtomat] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Avtomat] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Avtomat] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Avtomat] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Avtomat] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Avtomat] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Avtomat] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Avtomat] SET  MULTI_USER 
GO
ALTER DATABASE [Avtomat] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Avtomat] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Avtomat] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Avtomat] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Avtomat]
GO
/****** Object:  Table [dbo].[Coins]    Script Date: 11.02.2022 20:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coins](
	[id] [int] NOT NULL,
	[Denominator] [int] NOT NULL,
 CONSTRAINT [PK_Coins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drinks]    Script Date: 11.02.2022 20:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drinks](
	[id] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[image] [nvarchar](50) NOT NULL,
	[Cost] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Drinks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VendingMachineCoins]    Script Date: 11.02.2022 20:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendingMachineCoins](
	[id] [int] NOT NULL,
	[VendingMachineCoins] [int] NOT NULL,
	[Coinsld] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[isActive] [int] NOT NULL,
 CONSTRAINT [PK_VendingMachineCoins] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VendingMachineDrinks]    Script Date: 11.02.2022 20:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendingMachineDrinks](
	[id] [int] NOT NULL,
	[VendingMachineDrinks] [int] NOT NULL,
	[Drinksld] [int] NOT NULL,
	[Count_after_last_update] [int] NOT NULL,
	[Count] [int] NOT NULL,
	[ProfitSum] [int] NOT NULL,
	[Sold] [int] NULL,
 CONSTRAINT [PK_VendingMachineDrinks] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[VendingMachines]    Script Date: 11.02.2022 20:16:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VendingMachines](
	[id] [int] NOT NULL,
	[SecretCode] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_VendingMachines] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
INSERT [dbo].[Coins] ([id], [Denominator]) VALUES (1, 1)
INSERT [dbo].[Coins] ([id], [Denominator]) VALUES (2, 2)
INSERT [dbo].[Coins] ([id], [Denominator]) VALUES (3, 5)
INSERT [dbo].[Coins] ([id], [Denominator]) VALUES (4, 10)
INSERT [dbo].[Drinks] ([id], [Name], [image], [Cost]) VALUES (1, N'Coca-Cola', N'Resources/coca-cola.png', CAST(78 AS Decimal(18, 0)))
INSERT [dbo].[Drinks] ([id], [Name], [image], [Cost]) VALUES (2, N'Fanta ', N'Resources/Fanta.png', CAST(86 AS Decimal(18, 0)))
INSERT [dbo].[Drinks] ([id], [Name], [image], [Cost]) VALUES (3, N'Sprite', N'Resources/Sprite.png ', CAST(84 AS Decimal(18, 0)))
INSERT [dbo].[Drinks] ([id], [Name], [image], [Cost]) VALUES (4, N'Mountain Dew', N'Resources/Mountain_Dew.png', CAST(84 AS Decimal(18, 0)))
INSERT [dbo].[VendingMachineCoins] ([id], [VendingMachineCoins], [Coinsld], [Count], [isActive]) VALUES (1, 1001, 1, 30, 1)
INSERT [dbo].[VendingMachineCoins] ([id], [VendingMachineCoins], [Coinsld], [Count], [isActive]) VALUES (2, 1001, 2, 30, 1)
INSERT [dbo].[VendingMachineCoins] ([id], [VendingMachineCoins], [Coinsld], [Count], [isActive]) VALUES (3, 1001, 3, 30, 1)
INSERT [dbo].[VendingMachineCoins] ([id], [VendingMachineCoins], [Coinsld], [Count], [isActive]) VALUES (4, 1001, 4, 30, 1)
INSERT [dbo].[VendingMachineDrinks] ([id], [VendingMachineDrinks], [Drinksld], [Count_after_last_update], [Count], [ProfitSum], [Sold]) VALUES (1, 2002, 1, 50, 50, 0, 0)
INSERT [dbo].[VendingMachineDrinks] ([id], [VendingMachineDrinks], [Drinksld], [Count_after_last_update], [Count], [ProfitSum], [Sold]) VALUES (2, 2002, 2, 50, 50, 0, 0)
INSERT [dbo].[VendingMachineDrinks] ([id], [VendingMachineDrinks], [Drinksld], [Count_after_last_update], [Count], [ProfitSum], [Sold]) VALUES (3, 2002, 3, 50, 50, 0, 0)
INSERT [dbo].[VendingMachineDrinks] ([id], [VendingMachineDrinks], [Drinksld], [Count_after_last_update], [Count], [ProfitSum], [Sold]) VALUES (4, 2002, 4, 50, 50, 0, 0)
INSERT [dbo].[VendingMachines] ([id], [SecretCode]) VALUES (1001, N'par1')
INSERT [dbo].[VendingMachines] ([id], [SecretCode]) VALUES (2002, N'par2')
ALTER TABLE [dbo].[VendingMachineCoins]  WITH CHECK ADD  CONSTRAINT [FK_VendingMachineCoins_Coins] FOREIGN KEY([Coinsld])
REFERENCES [dbo].[Coins] ([id])
GO
ALTER TABLE [dbo].[VendingMachineCoins] CHECK CONSTRAINT [FK_VendingMachineCoins_Coins]
GO
ALTER TABLE [dbo].[VendingMachineCoins]  WITH CHECK ADD  CONSTRAINT [FK_VendingMachineCoins_VendingMachines] FOREIGN KEY([VendingMachineCoins])
REFERENCES [dbo].[VendingMachines] ([id])
GO
ALTER TABLE [dbo].[VendingMachineCoins] CHECK CONSTRAINT [FK_VendingMachineCoins_VendingMachines]
GO
ALTER TABLE [dbo].[VendingMachineDrinks]  WITH CHECK ADD  CONSTRAINT [FK_VendingMachineDrinks_Drinks] FOREIGN KEY([Drinksld])
REFERENCES [dbo].[Drinks] ([id])
GO
ALTER TABLE [dbo].[VendingMachineDrinks] CHECK CONSTRAINT [FK_VendingMachineDrinks_Drinks]
GO
ALTER TABLE [dbo].[VendingMachineDrinks]  WITH CHECK ADD  CONSTRAINT [FK_VendingMachineDrinks_VendingMachines] FOREIGN KEY([VendingMachineDrinks])
REFERENCES [dbo].[VendingMachines] ([id])
GO
ALTER TABLE [dbo].[VendingMachineDrinks] CHECK CONSTRAINT [FK_VendingMachineDrinks_VendingMachines]
GO
USE [master]
GO
ALTER DATABASE [Avtomat] SET  READ_WRITE 
GO
