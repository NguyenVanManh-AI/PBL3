USE [System_Library]
GO
ALTER TABLE [dbo].[borrows] DROP CONSTRAINT [FK_borrows_readers]
GO
ALTER TABLE [dbo].[borrows] DROP CONSTRAINT [FK_borrows_employees]
GO
ALTER TABLE [dbo].[borrow_details] DROP CONSTRAINT [FK_borrow_details_borrows]
GO
ALTER TABLE [dbo].[borrow_details] DROP CONSTRAINT [FK_borrow_details_books]
GO
ALTER TABLE [dbo].[books] DROP CONSTRAINT [FK_books_book_titles]
GO
ALTER TABLE [dbo].[book_titles] DROP CONSTRAINT [FK_book_titles_publishers]
GO
ALTER TABLE [dbo].[book_titles] DROP CONSTRAINT [FK_book_titles_categorys]
GO
ALTER TABLE [dbo].[book_titles] DROP CONSTRAINT [FK_book_titles_authors]
GO
/****** Object:  Table [dbo].[readers]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[readers]') AND type in (N'U'))
DROP TABLE [dbo].[readers]
GO
/****** Object:  Table [dbo].[publishers]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[publishers]') AND type in (N'U'))
DROP TABLE [dbo].[publishers]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[employees]') AND type in (N'U'))
DROP TABLE [dbo].[employees]
GO
/****** Object:  Table [dbo].[categorys]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[categorys]') AND type in (N'U'))
DROP TABLE [dbo].[categorys]
GO
/****** Object:  Table [dbo].[borrows]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[borrows]') AND type in (N'U'))
DROP TABLE [dbo].[borrows]
GO
/****** Object:  Table [dbo].[borrow_details]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[borrow_details]') AND type in (N'U'))
DROP TABLE [dbo].[borrow_details]
GO
/****** Object:  Table [dbo].[books]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[books]') AND type in (N'U'))
DROP TABLE [dbo].[books]
GO
/****** Object:  Table [dbo].[book_titles]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[book_titles]') AND type in (N'U'))
DROP TABLE [dbo].[book_titles]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 6/2/2022 9:07:37 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[authors]') AND type in (N'U'))
DROP TABLE [dbo].[authors]
GO
USE [master]
GO
/****** Object:  Database [System_Library]    Script Date: 6/2/2022 9:07:37 AM ******/
DROP DATABASE [System_Library]
GO
/****** Object:  Database [System_Library]    Script Date: 6/2/2022 9:07:37 AM ******/
CREATE DATABASE [System_Library]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'System_Library', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.VANMANH\MSSQL\DATA\System_Library.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'System_Library_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.VANMANH\MSSQL\DATA\System_Library_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [System_Library] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [System_Library].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [System_Library] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [System_Library] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [System_Library] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [System_Library] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [System_Library] SET ARITHABORT OFF 
GO
ALTER DATABASE [System_Library] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [System_Library] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [System_Library] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [System_Library] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [System_Library] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [System_Library] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [System_Library] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [System_Library] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [System_Library] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [System_Library] SET  DISABLE_BROKER 
GO
ALTER DATABASE [System_Library] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [System_Library] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [System_Library] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [System_Library] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [System_Library] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [System_Library] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [System_Library] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [System_Library] SET RECOVERY FULL 
GO
ALTER DATABASE [System_Library] SET  MULTI_USER 
GO
ALTER DATABASE [System_Library] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [System_Library] SET DB_CHAINING OFF 
GO
ALTER DATABASE [System_Library] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [System_Library] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [System_Library] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [System_Library] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'System_Library', N'ON'
GO
ALTER DATABASE [System_Library] SET QUERY_STORE = OFF
GO
USE [System_Library]
GO
/****** Object:  Table [dbo].[authors]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[authors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NULL,
	[gender] [bit] NULL,
	[description] [nvarchar](max) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[book_titles]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[book_titles](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](max) NOT NULL,
	[author_id] [int] NULL,
	[category_id] [int] NULL,
	[publisher_id] [int] NULL,
	[description] [nvarchar](max) NULL,
	[publication_date] [date] NULL,
	[number_of_pages] [int] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[books]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[books](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[book_title_id] [int] NULL,
	[imported_at] [date] NULL,
	[status] [bit] NOT NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[borrow_details]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[borrow_details](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[borrow_id] [int] NULL,
	[book_id] [int] NULL,
	[borrow_at] [date] NOT NULL,
	[return_at] [date] NULL,
	[book_title] [nvarchar](max) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[borrows]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[borrows](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[creator_id] [int] NULL,
	[creator_name] [nvarchar](50) NULL,
	[reader_id] [int] NULL,
	[reader_name] [nvarchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[categorys]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categorys](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[created_at] [datetime] NOT NULL,
	[updated_at] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employees]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employees](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[role] [varchar](50) NOT NULL,
	[first_name] [nvarchar](50) NULL,
	[last_name] [nvarchar](50) NULL,
	[phone] [varchar](50) NULL,
	[email] [varchar](50) NULL,
	[address] [nvarchar](50) NULL,
	[date_of_birth] [date] NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[publishers]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[publishers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[description] [nvarchar](max) NULL,
	[address] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[readers]    Script Date: 6/2/2022 9:07:38 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[readers](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[first_name] [nvarchar](50) NOT NULL,
	[last_name] [nvarchar](50) NULL,
	[gender] [bit] NULL,
	[date_of_birth] [date] NULL,
	[email] [varchar](50) NULL,
	[identity_card_number] [varchar](50) NOT NULL,
	[phone] [varchar](50) NOT NULL,
	[address] [nvarchar](50) NULL,
	[created_at] [datetime] NULL,
	[updated_at] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[authors] ON 

INSERT [dbo].[authors] ([id], [first_name], [last_name], [gender], [description], [created_at], [updated_at]) VALUES (3, N'Văn Mạnh', N'Nguyễn', 1, N'', CAST(N'2022-05-21T22:26:59.000' AS DateTime), CAST(N'2022-05-21T22:26:59.000' AS DateTime))
INSERT [dbo].[authors] ([id], [first_name], [last_name], [gender], [description], [created_at], [updated_at]) VALUES (4, N'Ngọc Quốc', N'Trần', 0, N'', CAST(N'2022-05-21T22:27:12.000' AS DateTime), CAST(N'2022-06-01T14:11:56.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[authors] OFF
GO
SET IDENTITY_INSERT [dbo].[book_titles] ON 

INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (7, N'Lập trình web', NULL, 2, 3, N'sách v? l?p trình', CAST(N'2022-10-10' AS Date), 120, CAST(N'2022-05-17T11:18:39.000' AS DateTime), CAST(N'2022-06-01T06:48:40.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (8, N'Mắt Biếc', NULL, 2, 3, N'sách hay', CAST(N'2022-10-10' AS Date), 120, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (10, N'Lap trinh PHP', 4, 5, 6, N'abcd ', CAST(N'2001-08-08' AS Date), 90, CAST(N'2022-05-21T22:33:56.000' AS DateTime), CAST(N'2022-06-01T17:03:35.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (11, N'Lap trinh PHP', 4, 5, 3, N'vjhvisd ivhs', CAST(N'2002-08-08' AS Date), 90, CAST(N'2022-05-21T22:51:18.000' AS DateTime), CAST(N'2022-05-21T22:51:18.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (12, N'L?p trình web', NULL, 2, 3, N'sách v? l?p trình', CAST(N'2022-10-10' AS Date), 120, CAST(N'2022-05-21T22:52:03.000' AS DateTime), CAST(N'2022-05-21T22:52:52.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (13, N'L?p trình web', NULL, 2, 3, N'sách v? l?p trình', CAST(N'2022-10-10' AS Date), 120, CAST(N'2022-05-21T22:54:43.000' AS DateTime), CAST(N'2022-05-21T22:54:43.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (14, N'Lap trinh PHP', 4, 5, 6, N'abcd ', CAST(N'2001-08-08' AS Date), 90, CAST(N'2022-05-21T22:58:52.000' AS DateTime), CAST(N'2022-05-21T22:58:52.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (15, N'M?t Bi?c', NULL, 2, 3, N'sách hay', CAST(N'2022-10-10' AS Date), 120, CAST(N'2022-05-21T22:59:00.000' AS DateTime), CAST(N'2022-05-21T22:59:00.000' AS DateTime))
INSERT [dbo].[book_titles] ([id], [title], [author_id], [category_id], [publisher_id], [description], [publication_date], [number_of_pages], [created_at], [updated_at]) VALUES (16, N'L?p trình web', NULL, 2, 3, N'sách v? l?p trình', CAST(N'2022-10-10' AS Date), 120, CAST(N'2022-05-21T23:24:40.000' AS DateTime), CAST(N'2022-05-21T23:24:40.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[book_titles] OFF
GO
SET IDENTITY_INSERT [dbo].[books] ON 

INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (3, 7, NULL, 1, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (4, 8, NULL, 1, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (5, 8, NULL, 1, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (6, 8, NULL, 1, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (8, 7, NULL, 1, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (9, 8, NULL, 0, CAST(N'2022-05-17T11:18:39.000' AS DateTime), NULL)
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (11, 10, CAST(N'2022-05-08' AS Date), 1, CAST(N'2022-05-31T23:55:59.000' AS DateTime), CAST(N'2022-05-31T23:55:59.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (12, 10, CAST(N'2022-05-10' AS Date), 1, CAST(N'2022-05-31T23:56:10.000' AS DateTime), CAST(N'2022-05-31T23:56:10.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (13, 10, CAST(N'2022-05-18' AS Date), 1, CAST(N'2022-05-31T23:56:14.000' AS DateTime), CAST(N'2022-05-31T23:56:14.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (14, 10, CAST(N'2022-05-15' AS Date), 1, CAST(N'2022-05-31T23:56:17.000' AS DateTime), CAST(N'2022-05-31T23:56:17.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (15, 10, CAST(N'2022-05-24' AS Date), 1, CAST(N'2022-05-31T23:56:20.000' AS DateTime), CAST(N'2022-05-31T23:56:20.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (16, 10, CAST(N'2022-05-22' AS Date), 1, CAST(N'2022-05-31T23:56:24.000' AS DateTime), CAST(N'2022-05-31T23:56:24.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (17, 10, CAST(N'2022-05-11' AS Date), 1, CAST(N'2022-05-31T23:56:27.000' AS DateTime), CAST(N'2022-05-31T23:56:27.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (18, 7, CAST(N'2022-06-05' AS Date), 1, CAST(N'2022-06-01T15:43:12.000' AS DateTime), CAST(N'2022-06-01T15:43:12.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (19, 11, CAST(N'2022-06-19' AS Date), 1, CAST(N'2022-06-01T15:46:02.000' AS DateTime), CAST(N'2022-06-01T15:46:07.000' AS DateTime))
INSERT [dbo].[books] ([id], [book_title_id], [imported_at], [status], [created_at], [updated_at]) VALUES (20, 11, CAST(N'2022-06-20' AS Date), 0, CAST(N'2022-06-01T15:46:19.000' AS DateTime), CAST(N'2022-06-01T15:46:25.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[books] OFF
GO
SET IDENTITY_INSERT [dbo].[borrow_details] ON 

INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (17, NULL, 3, CAST(N'2022-05-01' AS Date), CAST(N'2022-05-10' AS Date), N'Lập trình web')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (18, 11, 4, CAST(N'2022-05-21' AS Date), CAST(N'2022-05-21' AS Date), N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (19, 12, 5, CAST(N'2022-05-21' AS Date), NULL, N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (20, 11, 3, CAST(N'2022-05-11' AS Date), CAST(N'2022-05-21' AS Date), N'Lập trình web')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (21, NULL, 6, CAST(N'2022-05-21' AS Date), NULL, N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (22, 11, 4, CAST(N'2022-05-21' AS Date), CAST(N'2022-05-21' AS Date), N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (23, 13, 9, CAST(N'2022-05-21' AS Date), CAST(N'2022-05-26' AS Date), N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (24, NULL, 4, CAST(N'2022-05-21' AS Date), NULL, N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (25, NULL, 8, CAST(N'2022-05-12' AS Date), NULL, N'L?p trình web')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (27, 13, 16, CAST(N'2022-05-17' AS Date), NULL, N'Lap trinh PHP')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (28, 13, 3, CAST(N'2022-05-29' AS Date), NULL, N'Lập trình web')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (32, 13, 9, CAST(N'2022-05-26' AS Date), CAST(N'2022-05-28' AS Date), N'Mắt Biếc')
INSERT [dbo].[borrow_details] ([id], [borrow_id], [book_id], [borrow_at], [return_at], [book_title]) VALUES (33, 13, 9, CAST(N'2022-05-29' AS Date), CAST(N'2022-06-01' AS Date), N'Mắt Biếc')
SET IDENTITY_INSERT [dbo].[borrow_details] OFF
GO
SET IDENTITY_INSERT [dbo].[borrows] ON 

INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (10, 1, N'Nguyễn Văn Mạnh', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-05-20T14:38:48.000' AS DateTime), CAST(N'2022-05-31T16:17:07.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (11, 1, N'Nguyễn Văn Mạnh', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-05-20T18:12:32.000' AS DateTime), CAST(N'2022-05-31T11:52:22.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (12, 1, N'Nguyễn Văn Mạnh', 6, N'Nguyễn Văn Mạnh', CAST(N'2022-05-20T18:12:38.000' AS DateTime), CAST(N'2022-05-20T18:12:38.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (13, 1, N'Nguyễn Văn Mạnh', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-05-21T22:56:31.000' AS DateTime), CAST(N'2022-05-21T22:56:31.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (15, 1, N'Nguyễn Văn Mạnh', 5, N'Nguyễn Văn Mạnh', CAST(N'2022-05-31T11:37:18.000' AS DateTime), CAST(N'2022-05-31T11:37:18.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (16, 1, N'Nguyễn Văn Mạnh', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-05-31T11:38:39.000' AS DateTime), CAST(N'2022-05-31T11:52:32.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (17, 1, N'Nguyễn Văn Mạnh', 6, N'Nguyễn Văn Mạnh', CAST(N'2022-05-31T11:45:04.000' AS DateTime), CAST(N'2022-05-31T11:45:04.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (18, 1, N'Nguyễn Văn Mạnh', 5, N'Nguyễn Văn Mạnh', CAST(N'2022-05-31T11:48:53.000' AS DateTime), CAST(N'2022-05-31T11:52:41.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (19, 16, N' Mạnh', 6, N'Nguyễn Văn Mạnh', CAST(N'2022-05-31T11:51:06.000' AS DateTime), CAST(N'2022-05-31T11:52:50.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (20, 16, N' Mạnh', 6, N'Nguyễn Văn Mạnh', CAST(N'2022-05-31T11:53:57.000' AS DateTime), CAST(N'2022-05-31T11:53:57.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (21, 19, N'Phạm Sĩ Chiến', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-05-31T12:06:45.000' AS DateTime), CAST(N'2022-05-31T12:18:40.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (22, 1, N'Nguyễn Văn Mạnh', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-05-31T12:21:08.000' AS DateTime), CAST(N'2022-05-31T12:21:08.000' AS DateTime))
INSERT [dbo].[borrows] ([id], [creator_id], [creator_name], [reader_id], [reader_name], [created_at], [updated_at]) VALUES (23, 1, N'Nguyễn Văn Mạnh', 7, N'Nguyễn Thị Mỹ An', CAST(N'2022-06-01T07:21:13.000' AS DateTime), CAST(N'2022-06-01T07:21:13.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[borrows] OFF
GO
SET IDENTITY_INSERT [dbo].[categorys] ON 

INSERT [dbo].[categorys] ([id], [name], [description], [created_at], [updated_at]) VALUES (2, N'Văn Học', N'sách về văn học', CAST(N'2022-05-20T14:37:55.000' AS DateTime), CAST(N'2022-06-02T07:07:52.000' AS DateTime))
INSERT [dbo].[categorys] ([id], [name], [description], [created_at], [updated_at]) VALUES (3, N'Lập trình', N'', CAST(N'2022-05-21T22:26:16.000' AS DateTime), CAST(N'2022-05-21T22:26:16.000' AS DateTime))
INSERT [dbo].[categorys] ([id], [name], [description], [created_at], [updated_at]) VALUES (4, N'Chính Trị', N'', CAST(N'2022-05-21T22:26:25.000' AS DateTime), CAST(N'2022-05-21T22:26:25.000' AS DateTime))
INSERT [dbo].[categorys] ([id], [name], [description], [created_at], [updated_at]) VALUES (5, N'Khoa Học', N'', CAST(N'2022-05-21T22:26:33.000' AS DateTime), CAST(N'2022-05-21T22:26:33.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[categorys] OFF
GO
SET IDENTITY_INSERT [dbo].[employees] ON 

INSERT [dbo].[employees] ([id], [username], [password], [role], [first_name], [last_name], [phone], [email], [address], [date_of_birth], [created_at], [updated_at]) VALUES (1, N'vanmanh123', N'KRZn43dflOxmyED3RjpeOjZaM4g=', N'admin', N'Mạnh', N'Nguyễn Văn', N'0971404372', N'nguyenvanmanh2001it1@gmail.com', N'Phú Vang - Thừa Thiên Huế - VN', CAST(N'2022-05-17' AS Date), CAST(N'2022-05-17T00:00:00.000' AS DateTime), CAST(N'2022-05-31T11:50:32.000' AS DateTime))
INSERT [dbo].[employees] ([id], [username], [password], [role], [first_name], [last_name], [phone], [email], [address], [date_of_birth], [created_at], [updated_at]) VALUES (15, N'vanmanh999', N'fdrUX7T8c94MERPe5KdFPh8eEPM=', N'user', N'Mạnh', N'Văn', N'0123456789', N'vanmanh@gmail.com', N'VN', CAST(N'2022-05-01' AS Date), CAST(N'2022-05-27T13:15:47.000' AS DateTime), CAST(N'2022-05-29T16:31:46.000' AS DateTime))
INSERT [dbo].[employees] ([id], [username], [password], [role], [first_name], [last_name], [phone], [email], [address], [date_of_birth], [created_at], [updated_at]) VALUES (16, N'vanmanh1234', N'+IZaqJ7hv/NdmLNY3wyWfeX0bLI=', N'user', N'Mạnh', N'', N'0123456789', N'vanmanh1234@gmail.com', N'Huế', CAST(N'2001-08-29' AS Date), CAST(N'2022-05-27T13:34:24.000' AS DateTime), CAST(N'2022-05-29T16:31:39.000' AS DateTime))
INSERT [dbo].[employees] ([id], [username], [password], [role], [first_name], [last_name], [phone], [email], [address], [date_of_birth], [created_at], [updated_at]) VALUES (19, N'sichien123', N'DFjYX6OEq2XeYTnzjlZ/T+7pDxA=', N'user', N'Sĩ Chiến', N'Phạm', N'0123432344', N'sichien123@gmail.com', N'Đà Nẵng', CAST(N'2022-05-01' AS Date), CAST(N'2022-05-31T12:05:42.000' AS DateTime), CAST(N'2022-05-31T12:06:33.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[employees] OFF
GO
SET IDENTITY_INSERT [dbo].[publishers] ON 

INSERT [dbo].[publishers] ([id], [name], [description], [address], [country], [created_at], [updated_at]) VALUES (3, N'Kim Đồng', N'nhà xuất bản kim đồng', N'Hà Nội', N'Việt Nam', CAST(N'2022-05-20T14:38:35.000' AS DateTime), CAST(N'2022-05-20T14:38:35.000' AS DateTime))
INSERT [dbo].[publishers] ([id], [name], [description], [address], [country], [created_at], [updated_at]) VALUES (4, N'Thế Giới', N'VN', N'Huế', N'VN', CAST(N'2022-05-21T22:25:03.000' AS DateTime), CAST(N'2022-06-02T07:44:46.000' AS DateTime))
INSERT [dbo].[publishers] ([id], [name], [description], [address], [country], [created_at], [updated_at]) VALUES (5, N'Khoa Học', N'', N'HCM', N'VN', CAST(N'2022-05-21T22:25:19.000' AS DateTime), CAST(N'2022-05-21T22:25:19.000' AS DateTime))
INSERT [dbo].[publishers] ([id], [name], [description], [address], [country], [created_at], [updated_at]) VALUES (6, N'Thiếu Nhi', N'', N'Nha Trang', N'VN', CAST(N'2022-05-21T22:25:41.000' AS DateTime), CAST(N'2022-05-21T22:26:02.000' AS DateTime))
INSERT [dbo].[publishers] ([id], [name], [description], [address], [country], [created_at], [updated_at]) VALUES (7, N'GDDT', N'Nguyễn Văn Mạnh', N'Huế', N'Việt Nam', CAST(N'2022-06-02T07:45:36.000' AS DateTime), CAST(N'2022-06-02T07:45:36.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[publishers] OFF
GO
SET IDENTITY_INSERT [dbo].[readers] ON 

INSERT [dbo].[readers] ([id], [first_name], [last_name], [gender], [date_of_birth], [email], [identity_card_number], [phone], [address], [created_at], [updated_at]) VALUES (5, N'Mạnh', N'Nguyễn Văn', 0, CAST(N'2001-08-29' AS Date), N'vanmanh@gmail.com', N'192078214', N'0971404372', N'Huế', CAST(N'2022-05-20T14:36:25.000' AS DateTime), CAST(N'2022-06-02T08:26:47.000' AS DateTime))
INSERT [dbo].[readers] ([id], [first_name], [last_name], [gender], [date_of_birth], [email], [identity_card_number], [phone], [address], [created_at], [updated_at]) VALUES (6, N'Mạnh', N'Nguyễn Văn', 1, CAST(N'2001-08-29' AS Date), N'vanmanh@gmail.com', N'192078214', N'0971404372', N'Huế', CAST(N'2022-05-20T15:51:20.000' AS DateTime), CAST(N'2022-05-20T15:51:20.000' AS DateTime))
INSERT [dbo].[readers] ([id], [first_name], [last_name], [gender], [date_of_birth], [email], [identity_card_number], [phone], [address], [created_at], [updated_at]) VALUES (7, N'Mỹ An', N'Nguyễn Thị', 0, CAST(N'2002-11-11' AS Date), N'myan@gmail.com', N'192078222', N'0123456789', N'Hồ Chí Minh', CAST(N'2022-05-21T22:30:19.000' AS DateTime), CAST(N'2022-05-21T22:30:19.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[readers] OFF
GO
ALTER TABLE [dbo].[book_titles]  WITH CHECK ADD  CONSTRAINT [FK_book_titles_authors] FOREIGN KEY([author_id])
REFERENCES [dbo].[authors] ([id])
GO
ALTER TABLE [dbo].[book_titles] CHECK CONSTRAINT [FK_book_titles_authors]
GO
ALTER TABLE [dbo].[book_titles]  WITH CHECK ADD  CONSTRAINT [FK_book_titles_categorys] FOREIGN KEY([category_id])
REFERENCES [dbo].[categorys] ([id])
GO
ALTER TABLE [dbo].[book_titles] CHECK CONSTRAINT [FK_book_titles_categorys]
GO
ALTER TABLE [dbo].[book_titles]  WITH CHECK ADD  CONSTRAINT [FK_book_titles_publishers] FOREIGN KEY([publisher_id])
REFERENCES [dbo].[publishers] ([id])
GO
ALTER TABLE [dbo].[book_titles] CHECK CONSTRAINT [FK_book_titles_publishers]
GO
ALTER TABLE [dbo].[books]  WITH CHECK ADD  CONSTRAINT [FK_books_book_titles] FOREIGN KEY([book_title_id])
REFERENCES [dbo].[book_titles] ([id])
GO
ALTER TABLE [dbo].[books] CHECK CONSTRAINT [FK_books_book_titles]
GO
ALTER TABLE [dbo].[borrow_details]  WITH CHECK ADD  CONSTRAINT [FK_borrow_details_books] FOREIGN KEY([book_id])
REFERENCES [dbo].[books] ([id])
GO
ALTER TABLE [dbo].[borrow_details] CHECK CONSTRAINT [FK_borrow_details_books]
GO
ALTER TABLE [dbo].[borrow_details]  WITH CHECK ADD  CONSTRAINT [FK_borrow_details_borrows] FOREIGN KEY([borrow_id])
REFERENCES [dbo].[borrows] ([id])
GO
ALTER TABLE [dbo].[borrow_details] CHECK CONSTRAINT [FK_borrow_details_borrows]
GO
ALTER TABLE [dbo].[borrows]  WITH CHECK ADD  CONSTRAINT [FK_borrows_employees] FOREIGN KEY([creator_id])
REFERENCES [dbo].[employees] ([id])
GO
ALTER TABLE [dbo].[borrows] CHECK CONSTRAINT [FK_borrows_employees]
GO
ALTER TABLE [dbo].[borrows]  WITH CHECK ADD  CONSTRAINT [FK_borrows_readers] FOREIGN KEY([reader_id])
REFERENCES [dbo].[readers] ([id])
GO
ALTER TABLE [dbo].[borrows] CHECK CONSTRAINT [FK_borrows_readers]
GO
USE [master]
GO
ALTER DATABASE [System_Library] SET  READ_WRITE 
GO
