USE [master]
GO
/****** Object:  Database [Team3CAS]    Script Date: 6/8/2018 10:21:27 AM ******/
CREATE DATABASE [Team3CAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Team3CAS', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Team3CAS.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Team3CAS_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Team3CAS_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Team3CAS] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Team3CAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Team3CAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Team3CAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Team3CAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Team3CAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Team3CAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [Team3CAS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Team3CAS] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Team3CAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Team3CAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Team3CAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Team3CAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Team3CAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Team3CAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Team3CAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Team3CAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Team3CAS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Team3CAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Team3CAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Team3CAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Team3CAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Team3CAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Team3CAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Team3CAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Team3CAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Team3CAS] SET  MULTI_USER 
GO
ALTER DATABASE [Team3CAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Team3CAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Team3CAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Team3CAS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Team3CAS]
GO
/****** Object:  Table [dbo].[Appointment]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Appointment](
	[AppointmentID] [int] IDENTITY(1,1) NOT NULL,
	[PatientUserID] [int] NOT NULL,
	[DoctorUserID] [int] NOT NULL,
	[Status] [nchar](50) NULL,
	[Date] [date] NOT NULL,
	[Time] [time](7) NOT NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[AppointmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Doctor]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doctor](
	[UserID] [int] NOT NULL,
	[Specialist] [nchar](50) NULL,
	[Schedule] [nchar](50) NOT NULL,
	[Qualification] [nchar](50) NULL,
 CONSTRAINT [PK_Doctor] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Drugs]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drugs](
	[DrugID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[Composition] [nchar](100) NULL,
	[Quantity] [int] NULL,
	[Description] [nchar](50) NOT NULL,
	[Price] [money] NULL,
 CONSTRAINT [PK_Drugs] PRIMARY KEY CLUSTERED 
(
	[DrugID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[MessageID] [int] IDENTITY(1,1) NOT NULL,
	[SenderID] [int] NOT NULL,
	[RecieverID] [int] NOT NULL,
	[Body] [nchar](1000) NOT NULL,
	[Date] [date] NOT NULL,
	[Time] [time](7) NOT NULL,
	[Status] [nchar](50) NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Order]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[OrderDate] [date] NULL,
	[Status] [nchar](50) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[OrderItems]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderItems](
	[OrderItemID] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[DrugID] [int] NOT NULL,
	[Quantity] [int] NULL,
 CONSTRAINT [PK_OrderItems] PRIMARY KEY CLUSTERED 
(
	[OrderItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Role]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](50) NOT NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 6/8/2018 10:21:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[MedicareID] [nchar](50) NOT NULL,
	[Password] [nchar](50) NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[RoleID] [int] NOT NULL,
	[Sex] [nchar](50) NULL,
	[Status] [nchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Appointment] ON 

INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (1, 10, 7, N'active                                            ', CAST(0xF43B0B00 AS Date), CAST(0x070010ACD1530000 AS Time))
INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (2, 10, 14, N'active                                            ', CAST(0xC43A0B00 AS Date), CAST(0x070008D6E8290000 AS Time))
INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (3, 10, 8, N'active                                            ', CAST(0x663D0B00 AS Date), CAST(0x0700A8E76F4B0000 AS Time))
INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (4, 21, 15, N'active                                            ', CAST(0xD83B0B00 AS Date), CAST(0x070040230E430000 AS Time))
INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (5, 21, 20, N'active                                            ', CAST(0x643D0B00 AS Date), CAST(0x0700709A4A320000 AS Time))
INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (6, 22, 20, N'active                                            ', CAST(0x4D3A0B00 AS Date), CAST(0x0700D85EAC3A0000 AS Time))
INSERT [dbo].[Appointment] ([AppointmentID], [PatientUserID], [DoctorUserID], [Status], [Date], [Time]) VALUES (7, 10, 9, N'inactive                                          ', CAST(0x523E0B00 AS Date), CAST(0x0700000000000000 AS Time))
SET IDENTITY_INSERT [dbo].[Appointment] OFF
INSERT [dbo].[Doctor] ([UserID], [Specialist], [Schedule], [Qualification]) VALUES (7, N'cardiologist                                      ', N'mon-tue 7:00 pm to 9:00 pm                        ', N'MBBS                                              ')
INSERT [dbo].[Doctor] ([UserID], [Specialist], [Schedule], [Qualification]) VALUES (8, N'dermatologist                                     ', N'wed-fri 5:00 pm to 9:00 pm                        ', N'MD                                                ')
INSERT [dbo].[Doctor] ([UserID], [Specialist], [Schedule], [Qualification]) VALUES (9, N'neurologist                                       ', N'tue-thu 4:00 pm to 8:00 pm                        ', N'MD                                                ')
INSERT [dbo].[Doctor] ([UserID], [Specialist], [Schedule], [Qualification]) VALUES (14, N'allergist                                         ', N'wed-fri 9:00 am to 12:00 pm                       ', N'MBBS                                              ')
INSERT [dbo].[Doctor] ([UserID], [Specialist], [Schedule], [Qualification]) VALUES (15, N'psychiatrsit                                      ', N'thu-sat 2:00 pm to 5:00 pm                        ', N'MD                                                ')
INSERT [dbo].[Doctor] ([UserID], [Specialist], [Schedule], [Qualification]) VALUES (20, N'immunologist                                      ', N'mon-thu 9:00 am to 12:00 pm                       ', N'MD                                                ')
SET IDENTITY_INSERT [dbo].[Drugs] ON 

INSERT [dbo].[Drugs] ([DrugID], [Name], [Composition], [Quantity], [Description], [Price]) VALUES (2, N'dolo                                              ', N'500mg                                                                                               ', 10, N'pain reliever                                     ', 120.0000)
INSERT [dbo].[Drugs] ([DrugID], [Name], [Composition], [Quantity], [Description], [Price]) VALUES (3, N'paracetemol                                       ', N'100mg                                                                                               ', 20, N'pain reliever                                     ', 47.0000)
INSERT [dbo].[Drugs] ([DrugID], [Name], [Composition], [Quantity], [Description], [Price]) VALUES (6, N'saridon                                           ', N'200mg                                                                                               ', 25, N'pain reliever                                     ', 42.0000)
INSERT [dbo].[Drugs] ([DrugID], [Name], [Composition], [Quantity], [Description], [Price]) VALUES (8, N'cyclopham                                         ', N'300mg                                                                                               ', 30, N'pain reliever                                     ', 30.0000)
INSERT [dbo].[Drugs] ([DrugID], [Name], [Composition], [Quantity], [Description], [Price]) VALUES (9, N'augmentine                                        ', N'150mg                                                                                               ', 10, N'antiseptic                                        ', 35.0000)
SET IDENTITY_INSERT [dbo].[Drugs] OFF
SET IDENTITY_INSERT [dbo].[Message] ON 

INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (2, 7, 10, N'take the medicines prescribed by me                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     ', CAST(0xB63D0B00 AS Date), CAST(0x070008D6E8290000 AS Time), N'unread                                            ')
INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (6, 10, 14, N'okay                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    ', CAST(0x693C0B00 AS Date), CAST(0x0700384D25190000 AS Time), N'unread                                            ')
INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (7, 8, 10, N'take dolo tablets 3 times a day.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        ', CAST(0xF63D0B00 AS Date), CAST(0x0700D088C3100000 AS Time), N'read                                              ')
INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (8, 10, 8, N'sure thank you                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                          ', CAST(0xF33D0B00 AS Date), CAST(0x0700384D25190000 AS Time), N'read                                              ')
INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (9, 15, 21, N'please visit to the hospital tomorrow                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   ', CAST(0xF43D0B00 AS Date), CAST(0x0700D4F3B7250000 AS Time), N'read                                              ')
INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (10, 20, 21, N'please visit to the hospital on monday afternoon.                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       ', CAST(0x323E0B00 AS Date), CAST(0x0700C83E612E0000 AS Time), N'read                                              ')
INSERT [dbo].[Message] ([MessageID], [SenderID], [RecieverID], [Body], [Date], [Time], [Status]) VALUES (11, 10, 8, N'need some clarification in prescription                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 ', CAST(0x00000000 AS Date), CAST(0x0700000000000000 AS Time), N'unread                                            ')
SET IDENTITY_INSERT [dbo].[Message] OFF
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (1, 7, CAST(0x323C0B00 AS Date), N'inactive                                          ')
INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (2, 14, CAST(0xEE3E0B00 AS Date), N'active                                            ')
INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (3, 15, CAST(0x53390B00 AS Date), N'active                                            ')
INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (4, 8, CAST(0x51370B00 AS Date), N'active                                            ')
INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (5, 20, CAST(0x9F380B00 AS Date), N'inactive                                          ')
INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (7, 7, CAST(0x513E0B00 AS Date), N'active                                            ')
INSERT [dbo].[Order] ([OrderID], [UserID], [OrderDate], [Status]) VALUES (8, 7, CAST(0x533E0B00 AS Date), N'active                                            ')
SET IDENTITY_INSERT [dbo].[Order] OFF
SET IDENTITY_INSERT [dbo].[OrderItems] ON 

INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (1, 1, 2, 10)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (2, 1, 3, 3)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (3, 2, 6, 1)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (4, 3, 8, 7)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (5, 4, 9, 6)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (7, 5, 9, 5)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (8, 7, 9, 2)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (9, 7, 8, 4)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (10, 7, 6, 6)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (11, 7, 3, 7)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (12, 7, 2, 14)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (13, 8, 9, 1)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (14, 8, 8, 2)
INSERT [dbo].[OrderItems] ([OrderItemID], [OrderID], [DrugID], [Quantity]) VALUES (15, 8, 2, 3)
SET IDENTITY_INSERT [dbo].[OrderItems] OFF
SET IDENTITY_INSERT [dbo].[Role] ON 

INSERT [dbo].[Role] ([RoleID], [Name]) VALUES (1, N'Doctor                                            ')
INSERT [dbo].[Role] ([RoleID], [Name]) VALUES (2, N'Patient                                           ')
INSERT [dbo].[Role] ([RoleID], [Name]) VALUES (3, N'Vendor                                            ')
INSERT [dbo].[Role] ([RoleID], [Name]) VALUES (4, N'Receptionist                                      ')
SET IDENTITY_INSERT [dbo].[Role] OFF
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (7, N'shivaranjini26                                    ', N'12345                                             ', N'shivaranjini                                      ', 1, N'f                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (8, N'ranjini                                           ', N'12345                                             ', N'ranjininalini                                     ', 1, N'f                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (9, N'murali23                                          ', N'12345                                             ', N'murali                                            ', 1, N'm                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (10, N'nalini1                                           ', N'12345                                             ', N'nalini                                            ', 2, N'f                                                 ', N'inactive                                          ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (13, N'kushi123                                          ', N'12345                                             ', N'kushi                                             ', 3, N'f                                                 ', N'inactive                                          ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (14, N'babu52                                            ', N'12345                                             ', N'babu                                              ', 1, N'm                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (15, N'sumathi42                                         ', N'12345                                             ', N'sumathi                                           ', 1, N'f                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (17, N'shivib11                                          ', N'12345                                             ', N'shivi b                                           ', 4, N'f                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (18, N'krishna12                                         ', N'12345                                             ', N'krishna                                           ', 3, N'm                                                 ', N'inactive                                          ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (19, N'ranju26                                           ', N'12345                                             ', N'ranjini                                           ', 4, N'f                                                 ', N'inactive                                          ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (20, N'abhishek12                                        ', N'12345                                             ', N'abhishek                                          ', 1, N'm                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (21, N'supriya                                           ', N'12345                                             ', N'supriya                                           ', 2, N'f                                                 ', N'active                                            ')
INSERT [dbo].[User] ([UserID], [MedicareID], [Password], [Name], [RoleID], [Sex], [Status]) VALUES (22, N'pushkar                                           ', N'12345                                             ', N'pushkar b                                         ', 2, N'm                                                 ', N'active                                            ')
SET IDENTITY_INSERT [dbo].[User] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User]    Script Date: 6/8/2018 10:21:27 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User] ON [dbo].[User]
(
	[MedicareID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_User] FOREIGN KEY([PatientUserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_User]
GO
ALTER TABLE [dbo].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_User1] FOREIGN KEY([DoctorUserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Appointment] CHECK CONSTRAINT [FK_Appointment_User1]
GO
ALTER TABLE [dbo].[Doctor]  WITH CHECK ADD  CONSTRAINT [FK_Doctor_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Doctor] CHECK CONSTRAINT [FK_Doctor_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User] FOREIGN KEY([SenderID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User1] FOREIGN KEY([RecieverID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User1]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Drugs] FOREIGN KEY([DrugID])
REFERENCES [dbo].[Drugs] ([DrugID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Drugs]
GO
ALTER TABLE [dbo].[OrderItems]  WITH CHECK ADD  CONSTRAINT [FK_OrderItems_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([OrderID])
GO
ALTER TABLE [dbo].[OrderItems] CHECK CONSTRAINT [FK_OrderItems_Order]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_Role] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Role] ([RoleID])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_Role]
GO
USE [master]
GO
ALTER DATABASE [Team3CAS] SET  READ_WRITE 
GO
