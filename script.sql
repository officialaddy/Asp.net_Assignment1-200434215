USE [master]
GO
/****** Object:  Database [CollegeDB]    Script Date: 06-10-2020 13:43:57 ******/
CREATE DATABASE [CollegeDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CollegeDB', FILENAME = N'D:\DataBases\2017\CollegeDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CollegeDB_log', FILENAME = N'D:\DataBases\2017\CollegeDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [CollegeDB] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CollegeDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CollegeDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CollegeDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CollegeDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CollegeDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CollegeDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [CollegeDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CollegeDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CollegeDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CollegeDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CollegeDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CollegeDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CollegeDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CollegeDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CollegeDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CollegeDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CollegeDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CollegeDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CollegeDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CollegeDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CollegeDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CollegeDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CollegeDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CollegeDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CollegeDB] SET  MULTI_USER 
GO
ALTER DATABASE [CollegeDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CollegeDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CollegeDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CollegeDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CollegeDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CollegeDB] SET QUERY_STORE = OFF
GO
USE [CollegeDB]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [CollegeDB]
GO
/****** Object:  Table [dbo].[College]    Script Date: 06-10-2020 13:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[College](
	[CollegeID] [int] IDENTITY(1,1) NOT NULL,
	[CollegeName] [varchar](250) NULL,
	[Address] [varchar](500) NULL,
	[City] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[Country] [varchar](50) NULL,
	[ContactNumber] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[Password] [varchar](50) NULL,
	[Role] [int] NULL,
 CONSTRAINT [PK_College] PRIMARY KEY CLUSTERED 
(
	[CollegeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student]    Script Date: 06-10-2020 13:43:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NULL,
	[Gender] [varchar](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[ContactNumber] [varchar](50) NULL,
	[Address] [varchar](500) NULL,
	[Email] [varchar](50) NULL,
	[CollegeID] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[College] ON 

INSERT [dbo].[College] ([CollegeID], [CollegeName], [Address], [City], [State], [Country], [ContactNumber], [Email], [Password], [Role]) VALUES (1, N'Admin', NULL, NULL, NULL, NULL, N'+13343567546', N'Admin@gmail.com', N'12345', 1)
INSERT [dbo].[College] ([CollegeID], [CollegeName], [Address], [City], [State], [Country], [ContactNumber], [Email], [Password], [Role]) VALUES (2, N'College of business  ', N'Chandigarh ', N'Mohali', N'PB', N'india', N'2345555433', N'Cob@gmail.com', N'12345', 2)
INSERT [dbo].[College] ([CollegeID], [CollegeName], [Address], [City], [State], [Country], [ContactNumber], [Email], [Password], [Role]) VALUES (4, N'College of Computer Science ', N'Punjba', N'Mohali', N'PB', N'India', N'234', N'cocs@gamil.com', N'12345', 2)
SET IDENTITY_INSERT [dbo].[College] OFF
SET IDENTITY_INSERT [dbo].[Student] ON 

INSERT [dbo].[Student] ([StudentID], [StudentName], [Gender], [DateOfBirth], [ContactNumber], [Address], [Email], [CollegeID]) VALUES (1, N'Test User', N'Male', CAST(N'2010-10-01T00:00:00.000' AS DateTime), N'12345678', N'PB', N'user@gmail.com', 2)
INSERT [dbo].[Student] ([StudentID], [StudentName], [Gender], [DateOfBirth], [ContactNumber], [Address], [Email], [CollegeID]) VALUES (2, N'Test User2', N'Male', CAST(N'2002-10-02T00:00:00.000' AS DateTime), N'12345678', N'PB', N'user2@gmail.com', 4)
SET IDENTITY_INSERT [dbo].[Student] OFF
ALTER TABLE [dbo].[Student]  WITH CHECK ADD  CONSTRAINT [FK_Student_College] FOREIGN KEY([CollegeID])
REFERENCES [dbo].[College] ([CollegeID])
GO
ALTER TABLE [dbo].[Student] CHECK CONSTRAINT [FK_Student_College]
GO
USE [master]
GO
ALTER DATABASE [CollegeDB] SET  READ_WRITE 
GO
