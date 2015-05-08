USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusDelete]    Script Date: 05/07/2015 14:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusDelete]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusInsert]    Script Date: 05/07/2015 14:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusInsert]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusRead]    Script Date: 05/07/2015 14:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusRead]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusReadAll]    Script Date: 05/07/2015 14:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusReadAll]
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusUpdate]    Script Date: 05/07/2015 14:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Organization].[UnitStatusUpdate]
GO
/****** Object:  Table [Organization].[UnitStatus]    Script Date: 05/07/2015 14:05:39 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatus]') AND type in (N'U'))
DROP TABLE [Organization].[UnitStatus]
GO
/****** Object:  Table [Organization].[UnitStatus]    Script Date: 05/07/2015 14:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatus]') AND type in (N'U'))
BEGIN
CREATE TABLE [Organization].[UnitStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BuildingStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusUpdate]    Script Date: 05/07/2015 14:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusUpdate]
(	
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Organization.UnitStatus
	SET	
		Name = @Name
	WHERE Id = @Id
   
END' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusReadAll]    Script Date: 05/07/2015 14:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusReadAll]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Organization.UnitStatus WITH (NOLOCK)
	
End
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusRead]    Script Date: 05/07/2015 14:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusRead]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Organization.UnitStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusInsert]    Script Date: 05/07/2015 14:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[UnitStatusInsert]
(  
	@Name Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.UnitStatus(Name)
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
	
END
' 
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusDelete]    Script Date: 05/07/2015 14:05:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[UnitStatusDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE  [Organization].[UnitStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM Organization.UnitStatus
	WHERE Id = @Id
	
END
' 
END
GO
