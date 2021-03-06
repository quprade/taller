CREATE DATABASE [TallerChallenge]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customer](
	[PersonID] [bigint] NOT NULL,
	[FirstName] [varchar](250) NOT NULL,
	[LastName] [varchar](250) NOT NULL,
	[Age] [int] NOT NULL,
	[Occupation] [varchar](50) NOT NULL,
	[MartialStatus] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[PersonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [bigint] NOT NULL,
	[PersonID] [bigint] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[MethodofPurchase] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrdersDetails](
	[OrderDetailID] [bigint] NOT NULL,
	[OrderID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[ProductNumber] [bigint] NOT NULL,
	[ProductOrigin] [varchar](50) NOT NULL,
 CONSTRAINT [PK_OrdersDetails] PRIMARY KEY CLUSTERED 
(
	[OrderDetailID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Customer] ([PersonID], [FirstName], [LastName], [Age], [Occupation], [MartialStatus]) VALUES (12342, N'John', N'Wesley', 52, N'Singer', N'Married')
INSERT [dbo].[Customer] ([PersonID], [FirstName], [LastName], [Age], [Occupation], [MartialStatus]) VALUES (23412, N'John', N'Newton', 34, N'ship captain', N'Single')
GO
INSERT [dbo].[Orders] ([OrderID], [PersonID], [DateCreated], [MethodofPurchase]) VALUES (34243, 12342, CAST(N'2012-01-06T00:00:00.000' AS DateTime), N'Method')
INSERT [dbo].[Orders] ([OrderID], [PersonID], [DateCreated], [MethodofPurchase]) VALUES (74564, 23412, CAST(N'2014-06-09T00:00:00.000' AS DateTime), N'Nothing')
GO
INSERT [dbo].[OrdersDetails] ([OrderDetailID], [OrderID], [ProductID], [ProductNumber], [ProductOrigin]) VALUES (23123, 74564, 1112222333, 12545, N'Haiti')
INSERT [dbo].[OrdersDetails] ([OrderDetailID], [OrderID], [ProductID], [ProductNumber], [ProductOrigin]) VALUES (342432313, 34243, 564753432, 987645, N'Argentina')
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customer] FOREIGN KEY([PersonID])
REFERENCES [dbo].[Customer] ([PersonID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customer]
GO
ALTER TABLE [dbo].[OrdersDetails]  WITH CHECK ADD  CONSTRAINT [FK_OrdersDetails_Orders] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Orders] ([OrderID])
GO
ALTER TABLE [dbo].[OrdersDetails] CHECK CONSTRAINT [FK_OrdersDetails_Orders]
GO
