USE [GayBanDou]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 2021/12/5 上午 02:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Group](
	[Sid] [int] IDENTITY(1,1) NOT NULL,
	[GroupImg] [nvarchar](50) NOT NULL,
	[GroupTital] [nvarchar](50) NOT NULL,
	[MemberID] [int] NOT NULL,
	[MemberName] [nvarchar](50) NOT NULL,
	[ShopID] [int] NOT NULL,
	[ShopName] [nvarchar](50) NOT NULL,
	[Status] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 2021/12/5 上午 02:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuID] [int] IDENTITY(1,1) NOT NULL,
	[ShopID] [int] NOT NULL,
	[ShopName] [nchar](10) NOT NULL,
	[MenuName] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 0) NOT NULL,
 CONSTRAINT [PK_Menu] PRIMARY KEY CLUSTERED 
(
	[MenuID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2021/12/5 上午 02:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[MenuID] [int] NOT NULL,
	[Qty] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Shop]    Script Date: 2021/12/5 上午 02:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Shop](
	[ShopID] [int] IDENTITY(3,1) NOT NULL,
	[ShopName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Shop] PRIMARY KEY CLUSTERED 
(
	[ShopID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 2021/12/5 上午 02:22:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Sid] [int] IDENTITY(2,1) NOT NULL,
	[Name] [nchar](10) NOT NULL,
	[Level] [int] NOT NULL,
	[Account] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[GroupMaster] [varchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (1, N'img/三色豆.jpg', N'系美邀逆?', 1, N'Fumi', 2, N'肯德基', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (2, N'img/辣菜補.jpg', N'出門PE戴KO罩', 1, N'Fumi      ', 2, N'肯德基', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (3, N'img/辣菜補.jpg', N'出門PE戴KO罩', 1, N'Fumi      ', 2, N'肯德基', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (4, N'img/豆枝、豆棗.jpg', N'魚肉好吃謀?', 1, N'Fumi      ', 1, N'麥當勞', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (5, N'img/紅燒茄子.jpg', N'AA都不AA', 1, N'Fumi      ', 1, N'麥當勞', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (6, N'img/洋蔥炒蛋.jpg', N'可不渴?', 1, N'Fumi      ', 1, N'麥當勞', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (7, N'img/油菜.jpg', N'可不渴?', 1, N'Fumi      ', 4, N'麥味登', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (8, N'img/豆枝、豆棗.jpg', N'朱', 1, N'Fumi      ', 5, N'夯伯魯味', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (9, N'img/三色豆.jpg', N'好魯喔', 1, N'Fumi      ', 6, N'西堤', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (10, N'img/豆枝、豆棗.jpg', N'可不渴?', 1, N'Fumi      ', 1, N'麥當勞', N'未結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (11, N'img/油菜.jpg', N'口渴', 1, N'Fumi      ', 4, N'麥味登', N'結團')
INSERT [dbo].[Group] ([Sid], [GroupImg], [GroupTital], [MemberID], [MemberName], [ShopID], [ShopName], [Status]) VALUES (12, N'img/洋蔥炒蛋.jpg', N'AAAA', 1, N'Fumi      ', 6, N'西堤', N'未結團')
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (1, 1, N'麥當勞       ', N'大麥克套餐', CAST(150 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (2, 1, N'麥當勞       ', N'蛋捲冰淇淋', CAST(35 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (3, 1, N'麥當勞       ', N'麥香魚套餐', CAST(99 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (4, 1, N'麥當勞       ', N'大薯', CAST(45 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (5, 1, N'麥當勞       ', N'快樂兒童餐', CAST(123 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (6, 2, N'肯德基       ', N'花生容顏堡', CAST(185 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (7, 2, N'肯德基       ', N'XXL套餐', CAST(210 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (8, 2, N'肯德基       ', N'6塊雞桶餐', CAST(145 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (9, 2, N'肯德基       ', N'全家餐', CAST(699 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (10, 2, N'肯德基       ', N'雲朵蛋塔', CAST(222 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (11, 3, N'丹丹漢堡      ', N'套餐1', CAST(78 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (12, 3, N'丹丹漢堡      ', N'套餐2', CAST(89 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (14, 3, N'丹丹漢堡      ', N'套餐3', CAST(95 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (15, 3, N'丹丹漢堡      ', N'套餐4', CAST(105 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (16, 4, N'麥味登       ', N'香雞堡', CAST(45 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (17, 4, N'麥味登       ', N'早餐紅茶', CAST(20 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (18, 4, N'麥味登       ', N'咖啡牛奶', CAST(25 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (19, 5, N'夯伯魯味      ', N'加料', CAST(100 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (20, 5, N'夯伯魯味      ', N'加加料', CAST(150 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (21, 5, N'夯伯魯味      ', N'加加加加加料', CAST(1000 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (22, 6, N'西堤        ', N'試しコース', CAST(599 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (23, 6, N'西堤        ', N'レデイコース', CAST(1111 AS Decimal(18, 0)))
INSERT [dbo].[Menu] ([MenuID], [ShopID], [ShopName], [MenuName], [Price]) VALUES (24, 6, N'西堤        ', N'晩餐コース', CAST(2999 AS Decimal(18, 0)))
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (24, 2, 11, 16, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (25, 1, 12, 22, 3)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (26, 1, 12, 22, 2)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (27, 1, 12, 22, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (28, 2, 12, 23, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (29, 2, 11, 16, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (30, 2, 12, 22, 2)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (31, 2, 12, 23, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (32, 2, 12, 24, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (33, 2, 12, 22, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (34, 2, 12, 22, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (35, 2, 12, 23, 1)
INSERT [dbo].[Order] ([OrderID], [MemberID], [GroupID], [MenuID], [Qty]) VALUES (36, 2, 12, 24, 1)
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
SET IDENTITY_INSERT [dbo].[Shop] ON 

INSERT [dbo].[Shop] ([ShopID], [ShopName]) VALUES (1, N'麥當勞')
INSERT [dbo].[Shop] ([ShopID], [ShopName]) VALUES (2, N'肯德基')
INSERT [dbo].[Shop] ([ShopID], [ShopName]) VALUES (3, N'丹丹漢堡')
INSERT [dbo].[Shop] ([ShopID], [ShopName]) VALUES (4, N'麥味登')
INSERT [dbo].[Shop] ([ShopID], [ShopName]) VALUES (5, N'夯伯魯味')
INSERT [dbo].[Shop] ([ShopID], [ShopName]) VALUES (6, N'西堤')
SET IDENTITY_INSERT [dbo].[Shop] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([Sid], [Name], [Level], [Account], [Password], [GroupMaster]) VALUES (1, N'Fumi      ', 1, N'admin', N'admin', NULL)
INSERT [dbo].[User] ([Sid], [Name], [Level], [Account], [Password], [GroupMaster]) VALUES (2, N'Eddie     ', 2, N'menber', N'menber', NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_Shop] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ShopID])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_Shop]
GO
ALTER TABLE [dbo].[Group]  WITH CHECK ADD  CONSTRAINT [FK_Group_User] FOREIGN KEY([MemberID])
REFERENCES [dbo].[User] ([Sid])
GO
ALTER TABLE [dbo].[Group] CHECK CONSTRAINT [FK_Group_User]
GO
ALTER TABLE [dbo].[Menu]  WITH CHECK ADD  CONSTRAINT [FK_Menu_Shop] FOREIGN KEY([ShopID])
REFERENCES [dbo].[Shop] ([ShopID])
GO
ALTER TABLE [dbo].[Menu] CHECK CONSTRAINT [FK_Menu_Shop]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Group] FOREIGN KEY([GroupID])
REFERENCES [dbo].[Group] ([Sid])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Group]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Menu] FOREIGN KEY([MenuID])
REFERENCES [dbo].[Menu] ([MenuID])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Menu]
GO
