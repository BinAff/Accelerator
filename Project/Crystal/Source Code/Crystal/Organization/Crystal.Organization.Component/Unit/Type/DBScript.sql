USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeDelete]    Script Date: 05/07/2015 13:51:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeDelete]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeInsert]    Script Date: 05/07/2015 13:51:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeInsert]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeRead]    Script Date: 05/07/2015 13:51:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeRead]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeReadAll]    Script Date: 05/07/2015 13:51:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeReadAll]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeUpdate]    Script Date: 05/07/2015 13:51:15 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitTypeUpdate]
GO
/****** Object:  Table [Organization].[UnitType]    Script Date: 05/07/2015 13:51:13 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitType]') AND type in (N'U'))
DROP TABLE [Organization].[UnitType]
GO
/****** Object:  Table [Organization].[UnitType]    Script Date: 05/07/2015 13:51:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitType]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[UnitType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BuildingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeUpdate]    Script Date: 05/07/2015 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE Organization.UnitType
		SET	
			Name = @Name
		WHERE Id = @Id
	   
	END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeReadAll]    Script Date: 05/07/2015 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Organization.UnitType WITH (NOLOCK)
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeRead]    Script Date: 05/07/2015 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Organization.UnitType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeInsert]    Script Date: 05/07/2015 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN
		
		INSERT INTO Organization.UnitType(Name)
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeDelete]    Script Date: 05/07/2015 13:51:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Organization].[UnitTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM Organization.UnitType
		WHERE Id = @Id      
	END
' 
END
GO
