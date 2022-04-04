DROP TABLE [SoldItems]
DROP TABLE [Stores]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SoldItems](
    [SoldItemID] [int] IDENTITY(1,1) NOT NULL,
    [StoreID] [int] NOT NULL,
    [Number] [int] NOT NULL,
    [Description] [varchar](150) NOT NULL,
    [Price] [money] NOT NULL,
    [Quantity] [int] NOT NULL,
 CONSTRAINT [PK_SoldItems] PRIMARY KEY CLUSTERED 
(
    [SoldItemID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
 
 
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stores](
    [StoreID] [int] IDENTITY(1,1) NOT NULL,
    [Name] [varchar](50) NOT NULL,
    [Street] [varchar](50) NOT NULL,
    [StreetNumber] [varchar](10) NOT NULL,
    [City] [varchar](50) NOT NULL,
    [Country] [varchar](50) NOT NULL,
    [IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Stores] PRIMARY KEY CLUSTERED 
(
    [StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SoldItems] ON
 
INSERT [dbo].[SoldItems] ([SoldItemID], [StoreID], [Number], [Description], [Price], [Quantity]) VALUES (1, 1, 985649082, N'Shoes', 60.0000, 1)
INSERT [dbo].[SoldItems] ([SoldItemID], [StoreID], [Number], [Description], [Price], [Quantity]) VALUES (2, 2, 439849329, N'T-Shirt with logo', 70.0000, 2)
INSERT [dbo].[SoldItems] ([SoldItemID], [StoreID], [Number], [Description], [Price], [Quantity]) VALUES (3, 1, 328494300, N'Black Jeans', 100.0000, 1)
INSERT [dbo].[SoldItems] ([SoldItemID], [StoreID], [Number], [Description], [Price], [Quantity]) VALUES (4, 1, 432874373, N'Blue Jeans', 60.0000, 3)
SET IDENTITY_INSERT [dbo].[SoldItems] OFF
SET IDENTITY_INSERT [dbo].[Stores] ON
 
INSERT [dbo].[Stores] ([StoreID], [Name], [Street], [StreetNumber], [City], [Country], [IsActive]) VALUES (1, N'StoreOne', N'Test', N'12', N'Pie', N'United States', 1)
INSERT [dbo].[Stores] ([StoreID], [Name], [Street], [StreetNumber], [City], [Country], [IsActive]) VALUES (2, N'Monument', N'Gray', N'454', N'Super', N'Canada', 1)
SET IDENTITY_INSERT [dbo].[Stores] OFF
ALTER TABLE [dbo].[SoldItems]  WITH CHECK ADD  CONSTRAINT [FK_SoldItems_Stores] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Stores] ([StoreID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SoldItems] CHECK CONSTRAINT [FK_SoldItems_Stores]
GO
USE [master]
GO
ALTER DATABASE [Corporation] SET  READ_WRITE 
GO