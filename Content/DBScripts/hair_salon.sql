USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 12/9/2016 2:28:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[hair_color] [varchar](255) NULL,
	[phone] [int] NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 12/9/2016 2:28:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[hours] [varchar](255) NULL,
	[phone] [int] NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [hair_color], [phone], [stylist_id]) VALUES (1, N'Max', N'Gray', 1234567, 1)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name], [hours], [phone]) VALUES (1, N'Sarah', N'1-6', 7654321)
INSERT [dbo].[stylists] ([id], [name], [hours], [phone]) VALUES (3, N'Kyle', N'12-5', 9876543)
SET IDENTITY_INSERT [dbo].[stylists] OFF
