USE [hair_salon_test]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 12/9/2016 2:29:02 PM ******/
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
/****** Object:  Table [dbo].[stylists]    Script Date: 12/9/2016 2:29:02 PM ******/
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
