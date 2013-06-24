IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NavigatorRule]') AND type in (N'U'))
CREATE TABLE [dbo].[NavigatorRule](
	[Id] Numeric(10,0) NOT NULL,
	[ModuleSeperator] [varchar](1) NULL,
	[PathSeperator] [varchar](1) NULL,
	CONSTRAINT [PK_NavigatorRule] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON)
) ON [PRIMARY]
GO

/*************C*************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NavigatorRuleInsert]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NavigatorRuleInsert]
	(  
		@ModuleSeperator Varchar(1),
		@PathSeperator Varchar(1),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN
			INSERT INTO NavigatorRule(Id, ModuleSeperator, PathSeperator)
			VALUES(1, @ModuleSeperator, @PathSeperator)
    
			SET @Id = 1
	END
	'
END
GO

/*************R*************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NavigatorRuleRead]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NavigatorRuleRead]
	(  
	   @Id Numeric(10,0)  
	)  
	AS  
	BEGIN
		SELECT
			ModuleSeperator, PathSeperator
		FROM NavigatorRule
	END
	'
END
GO

/************U**************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NavigatorRuleUpdate]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NavigatorRuleUpdate]
	(  
		@ModuleSeperator Varchar(1),
		@PathSeperator Varchar(1)
	)
	AS
	BEGIN
		UPDATE NavigatorRule
		SET ModuleSeperator = @ModuleSeperator,
			PathSeperator = @PathSeperator
	END
	'
END
GO
