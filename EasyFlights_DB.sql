USE [master]
GO
/****** Object:  Database [EasyFlights]    Script Date: 24/08/2019 16:03:22 ******/
CREATE DATABASE [EasyFlights]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EasyFlights', FILENAME = N'C:\Users\schey\EasyFlights.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EasyFlights_log', FILENAME = N'C:\Users\schey\EasyFlights_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [EasyFlights] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EasyFlights].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EasyFlights] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EasyFlights] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EasyFlights] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EasyFlights] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EasyFlights] SET ARITHABORT OFF 
GO
ALTER DATABASE [EasyFlights] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EasyFlights] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EasyFlights] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EasyFlights] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EasyFlights] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EasyFlights] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EasyFlights] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EasyFlights] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EasyFlights] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EasyFlights] SET  DISABLE_BROKER 
GO
ALTER DATABASE [EasyFlights] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EasyFlights] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EasyFlights] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EasyFlights] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EasyFlights] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EasyFlights] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EasyFlights] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EasyFlights] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EasyFlights] SET  MULTI_USER 
GO
ALTER DATABASE [EasyFlights] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EasyFlights] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EasyFlights] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EasyFlights] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EasyFlights] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EasyFlights] SET QUERY_STORE = OFF
GO
USE [EasyFlights]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [EasyFlights]
GO
/****** Object:  Table [dbo].[BonusPoints]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BonusPoints](
	[Id] [uniqueidentifier] NOT NULL,
	[Points] [int] NULL,
	[DateAquired] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Countries](
	[ID] [uniqueidentifier] NOT NULL,
	[CountryCode] [nvarchar](50) NOT NULL,
	[Country] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DepartureTimes]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DepartureTimes](
	[ID] [uniqueidentifier] NOT NULL,
	[DepartureTime] [datetime] NOT NULL,
 CONSTRAINT [PK_DepartureTimes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketDepartureTimes]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketDepartureTimes](
	[ID] [uniqueidentifier] NOT NULL,
	[TicketID] [uniqueidentifier] NOT NULL,
	[DepartureTimeID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_TicketDepartureTimes] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TicketDestinations]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TicketDestinations](
	[ID] [uniqueidentifier] NOT NULL,
	[TicketID] [uniqueidentifier] NOT NULL,
	[CountryID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_TicketDestinations] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[ID] [uniqueidentifier] NOT NULL,
	[Available] [int] NULL,
	[CountryID] [uniqueidentifier] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_Tickets] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserBonusPoints]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserBonusPoints](
	[Id] [uniqueidentifier] NOT NULL,
	[UserID] [uniqueidentifier] NULL,
	[PointID] [uniqueidentifier] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 24/08/2019 16:03:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [uniqueidentifier] NOT NULL,
	[Email] [nvarchar](50) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UsersTickets]    Script Date: 24/08/2019 16:03:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UsersTickets](
	[ID] [uniqueidentifier] NULL,
	[TicketID] [uniqueidentifier] NULL,
	[UserID] [uniqueidentifier] NULL,
	[DestinationID] [uniqueidentifier] NULL,
	[DepartureID] [uniqueidentifier] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BonusPoints] ADD  DEFAULT ((5)) FOR [Points]
GO
ALTER TABLE [dbo].[Tickets] ADD  CONSTRAINT [DF__tmp_ms_xx__Avail__793DFFAF]  DEFAULT ((1)) FOR [Available]
GO
ALTER TABLE [dbo].[TicketDepartureTimes]  WITH CHECK ADD  CONSTRAINT [FK_TicketDepartureTimes_DepartureTimes] FOREIGN KEY([DepartureTimeID])
REFERENCES [dbo].[DepartureTimes] ([ID])
GO
ALTER TABLE [dbo].[TicketDepartureTimes] CHECK CONSTRAINT [FK_TicketDepartureTimes_DepartureTimes]
GO
ALTER TABLE [dbo].[TicketDepartureTimes]  WITH CHECK ADD  CONSTRAINT [FK_TicketDepartureTimes_Tickets] FOREIGN KEY([TicketID])
REFERENCES [dbo].[Tickets] ([ID])
GO
ALTER TABLE [dbo].[TicketDepartureTimes] CHECK CONSTRAINT [FK_TicketDepartureTimes_Tickets]
GO
ALTER TABLE [dbo].[TicketDestinations]  WITH CHECK ADD  CONSTRAINT [FK_TicketDestinations_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[TicketDestinations] CHECK CONSTRAINT [FK_TicketDestinations_Countries]
GO
ALTER TABLE [dbo].[TicketDestinations]  WITH CHECK ADD  CONSTRAINT [FK_TicketDestinations_Tickets] FOREIGN KEY([TicketID])
REFERENCES [dbo].[Tickets] ([ID])
GO
ALTER TABLE [dbo].[TicketDestinations] CHECK CONSTRAINT [FK_TicketDestinations_Tickets]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Countries2] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([ID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Countries2]
GO
ALTER TABLE [dbo].[UserBonusPoints]  WITH CHECK ADD  CONSTRAINT [FK_UserBonusPoints_BonusPoints] FOREIGN KEY([PointID])
REFERENCES [dbo].[BonusPoints] ([Id])
GO
ALTER TABLE [dbo].[UserBonusPoints] CHECK CONSTRAINT [FK_UserBonusPoints_BonusPoints]
GO
ALTER TABLE [dbo].[UserBonusPoints]  WITH CHECK ADD  CONSTRAINT [FK_UserBonusPoints_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UserBonusPoints] CHECK CONSTRAINT [FK_UserBonusPoints_Users]
GO
ALTER TABLE [dbo].[UsersTickets]  WITH CHECK ADD  CONSTRAINT [FK_UsersTickets_Tickets] FOREIGN KEY([TicketID])
REFERENCES [dbo].[Tickets] ([ID])
GO
ALTER TABLE [dbo].[UsersTickets] CHECK CONSTRAINT [FK_UsersTickets_Tickets]
GO
ALTER TABLE [dbo].[UsersTickets]  WITH CHECK ADD  CONSTRAINT [FK_UsersTickets_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[UsersTickets] CHECK CONSTRAINT [FK_UsersTickets_Users]
GO
USE [master]
GO
ALTER DATABASE [EasyFlights] SET  READ_WRITE 
GO
