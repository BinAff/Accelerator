USE [AutoTourism]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO

IF NOT EXISTS (SELECT * FROM sys.schemas WHERE name = 'Navigator')
	EXEC('CREATE SCHEMA Navigator AUTHORIZATION dbo');
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[Rule]') AND type in (N'U'))
CREATE TABLE [Navigator].[Rule](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ModuleSeperator] [char](1) NOT NULL,
	[PathSeperator] [char](1) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/*************C*************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleInsert]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[RuleInsert]
	(  
		@ModuleSeperator Char(1),
		@PathSeperator Char(1),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN
			INSERT INTO [Navigator].[Rule](Id, ModuleSeperator, PathSeperator)
			VALUES(1, @ModuleSeperator, @PathSeperator)
    
			SET @Id = 1
	END
	'
END
GO

/*************R*************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleRead]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[RuleRead]
	(  
	   @Id Numeric(10,0)  
	)  
	AS  
	BEGIN
		SELECT
			ModuleSeperator, PathSeperator
		FROM [Navigator].[Rule]
	END
	'
END
GO

/************U**************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Navigator].[RuleUpdate]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Navigator].[RuleUpdate]
	(  
		@ModuleSeperator Char(1),
		@PathSeperator Char(1)
	)
	AS
	BEGIN
		UPDATE [Navigator].[Rule]
		SET ModuleSeperator = @ModuleSeperator,
			PathSeperator = @PathSeperator
	END
	'
END
GO
