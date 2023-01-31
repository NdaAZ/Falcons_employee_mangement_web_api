USE [master]
GO
/****** Object:  Database [Falcons]    Script Date: 28/01/2023 4:02:14 PM ******/
CREATE DATABASE [Falcons]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Falcons', FILENAME = N'D:\Software\MSserver2019\MSSQL15.NADEESH\MSSQL\DATA\Falcons.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Falcons_log', FILENAME = N'D:\Software\MSserver2019\MSSQL15.NADEESH\MSSQL\DATA\Falcons_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Falcons] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Falcons].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Falcons] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Falcons] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Falcons] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Falcons] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Falcons] SET ARITHABORT OFF 
GO
ALTER DATABASE [Falcons] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Falcons] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Falcons] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Falcons] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Falcons] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Falcons] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Falcons] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Falcons] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Falcons] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Falcons] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Falcons] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Falcons] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Falcons] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Falcons] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Falcons] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Falcons] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Falcons] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Falcons] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Falcons] SET  MULTI_USER 
GO
ALTER DATABASE [Falcons] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Falcons] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Falcons] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Falcons] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Falcons] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Falcons] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Falcons] SET QUERY_STORE = OFF
GO
USE [Falcons]
GO
/****** Object:  Table [dbo].[Auth_role]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Auth_role](
	[Auth_id] [int] IDENTITY(1,1) NOT NULL,
	[Auth_role] [nvarchar](200) NULL,
 CONSTRAINT [PK__Auth_rol__DD76FB8ECB3C6FD7] PRIMARY KEY CLUSTERED 
(
	[Auth_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Company_role]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Company_role](
	[CompanyRole_id] [int] IDENTITY(1,1) NOT NULL,
	[C_Role] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[CompanyRole_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contract_type]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contract_type](
	[Contract_id] [int] IDENTITY(1,1) NOT NULL,
	[Contract] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[Contract_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[CUSId] [int] IDENTITY(1,1) NOT NULL,
	[CUSKey]  AS ('Cus'+right('000'+CONVERT([varchar](5),[CUSId]),(6))) PERSISTED,
	[CusName] [varchar](50) NULL,
	[mobileno] [int] NULL,
	[Gender] [varchar](10) NULL,
PRIMARY KEY CLUSTERED 
(
	[CUSId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EmployeeDetails]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeDetails](
	[Emp_id] [int] IDENTITY(1,1) NOT NULL,
	[EmpFist_Name] [nvarchar](300) NULL,
	[EmpLast_Namec] [nvarchar](300) NULL,
	[Auth_role] [nvarchar](200) NULL,
	[comapny_role] [nvarchar](200) NULL,
	[Contract_type] [nvarchar](200) NULL,
	[Note] [nvarchar](500) NULL,
	[Joined_Date] [date] NULL,
	[SkypeId] [nvarchar](300) NULL,
	[Whatsapp] [nvarchar](150) NULL,
	[Company_Email] [nvarchar](200) NULL,
	[Personal_Email] [nvarchar](200) NULL,
	[UserName] [nvarchar](200) NULL,
	[Password] [nvarchar](200) NULL,
 CONSTRAINT [PK__Employee__263E2DD3CB8C70BA] PRIMARY KEY CLUSTERED 
(
	[Emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Project]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Project](
	[projectID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](200) NULL,
	[Description] [nvarchar](500) NULL,
	[Customer] [nvarchar](200) NULL,
	[AssignTo] [nvarchar](200) NULL,
	[Assigned_Date] [date] NULL,
	[Due_Date] [date] NULL,
	[Comments] [nvarchar](1000) NULL,
	[Status] [nvarchar](100) NULL,
	[Tasks] [nvarchar](500) NULL,
	[Task_ID] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Status]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Status](
	[Status_id] [int] IDENTITY(1,1) NOT NULL,
	[Status] [nvarchar](200) NULL,
 CONSTRAINT [PK__Status__51910524B1B2707B] PRIMARY KEY CLUSTERED 
(
	[Status_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tasks]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tasks](
	[Task_ID] [int] IDENTITY(1,1) NOT NULL,
	[ProjectName] [nvarchar](300) NULL,
	[Task_description] [nvarchar](300) NULL,
	[Emp_id] [int] NULL,
	[Assigned_to] [nvarchar](300) NULL,
	[Status_id] [int] NULL,
	[Developer_notes] [nvarchar](300) NULL,
 CONSTRAINT [PK__Tasks__716F4ACD9A0E6485] PRIMARY KEY CLUSTERED 
(
	[Task_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Timesheetlogs]    Script Date: 28/01/2023 4:02:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Timesheetlogs](
	[timesheet_id] [int] IDENTITY(1,1) NOT NULL,
	[Emp_id] [int] NULL,
	[Date] [date] NULL,
	[Description] [nvarchar](300) NULL,
	[Task_ID] [int] NULL,
	[start_time] [time](7) NULL,
	[end_time] [time](7) NULL,
	[break_time] [time](7) NULL,
	[total_hours_time]  AS (CONVERT([varchar](8),dateadd(second,datediff(second,(0),CONVERT([time],dateadd(hour,datediff(hour,[start_time],[end_time]),(0)))),(0)),(108))),
	[net_hours_time]  AS (CONVERT([varchar](8),dateadd(second,datediff(second,(0),CONVERT([time],dateadd(hour,datediff(hour,[start_time],[end_time])-datediff(hour,(0),[break_time]),(0)))),(0)),(108))),
 CONSTRAINT [PK__Timeshee__7BBF5068AB1796FD] PRIMARY KEY CLUSTERED 
(
	[timesheet_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_EmployeeDetails] FOREIGN KEY([Emp_id])
REFERENCES [dbo].[EmployeeDetails] ([Emp_id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_EmployeeDetails]
GO
ALTER TABLE [dbo].[Tasks]  WITH CHECK ADD  CONSTRAINT [FK_Tasks_Status] FOREIGN KEY([Status_id])
REFERENCES [dbo].[Status] ([Status_id])
GO
ALTER TABLE [dbo].[Tasks] CHECK CONSTRAINT [FK_Tasks_Status]
GO
USE [master]
GO
ALTER DATABASE [Falcons] SET  READ_WRITE 
GO
