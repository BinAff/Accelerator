USE [AutoTourism]
GO

/****** Object:  Table [Invoice].[Slab]    Script Date: 05/27/2014 11:35:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [Invoice].[Slab](
	[TaxId] [numeric](10, 0) NOT NULL,
	[Limit] [numeric](10, 0) NOT NULL,
	[Amount] [numeric](4, 2) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_TaxDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[Limit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Invoice].[Slab]  WITH CHECK ADD  CONSTRAINT [FK_TaxDetails_Taxation] FOREIGN KEY([Id])
REFERENCES [Invoice].[Taxation] ([Id])
GO

ALTER TABLE [Invoice].[Slab] CHECK CONSTRAINT [FK_TaxDetails_Taxation]
GO