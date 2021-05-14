USE [ECommerce]
GO

/****** Object:  Table [dbo].[BundleProducts]    Script Date: 2021/05/14 18:36:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BundleProducts](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[BundleID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BundleProducts]  WITH CHECK ADD FOREIGN KEY([BundleID])
REFERENCES [dbo].[Bundles] ([ID])
GO

ALTER TABLE [dbo].[BundleProducts]  WITH CHECK ADD FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
GO


