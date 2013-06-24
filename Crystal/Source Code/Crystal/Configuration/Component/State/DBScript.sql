
/****** Object:  Table [dbo].[State]    Script Date: 05/02/2012 23:18:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[State](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[StateInsert]    Script Date: 05/02/2012 23:17:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO State([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END

GO

/****** Object:  StoredProcedure [dbo].[StateRead]    Script Date: 05/02/2012 23:17:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   Select 
		Id,
		[Name]
   From dbo.State
   Where Id = @Id   
   
END

GO

/****** Object:  StoredProcedure [dbo].[StateReadAll]    Script Date: 05/02/2012 23:18:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM dbo.State
   
END

GO

/****** Object:  StoredProcedure [dbo].[StateUpdate]    Script Date: 05/02/2012 23:18:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE State
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END

GO

/****** Object:  StoredProcedure [dbo].[StateDelete]    Script Date: 05/02/2012 23:18:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[StateDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM State
	WHERE Id = @Id   
   
END

GO

GO
/****** Object:  StoredProcedure [dbo].[StateReadDuplicate]    Script Date: 04/29/2013 14:58:05 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StateReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[StateReadDuplicate]
	(
		@Name VARCHAR(10)		
	)
	AS
	BEGIN
		SELECT Id	
		FROM State 
		WHERE Name = @Name				
	END'
End