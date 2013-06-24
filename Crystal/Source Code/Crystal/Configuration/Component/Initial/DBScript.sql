
/****** Object:  Table [dbo].[Initial]    Script Date: 05/02/2012 23:08:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Initial](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Initial] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[InitialInsert]    Script Date: 05/02/2012 23:07:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InitialInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Initial([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END

GO

/****** Object:  StoredProcedure [dbo].[InitialRead]    Script Date: 05/02/2012 23:09:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InitialRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM Initial
	WHERE Id = @Id   
	
END

GO

/****** Object:  StoredProcedure [dbo].[InitialReadAll]    Script Date: 05/02/2012 23:10:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InitialReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM Initial
   
END

GO
/****** Object:  StoredProcedure [dbo].[InitialUpdate]    Script Date: 05/02/2012 23:10:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InitialUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Initial
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END

GO

/****** Object:  StoredProcedure [dbo].[InitialDelete]    Script Date: 05/02/2012 23:11:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InitialDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Initial
	WHERE Id = @Id   
   
END

GO

GO
/****** Object:  StoredProcedure [dbo].[InitialReadDuplicate]    Script Date: 04/29/2013 14:59:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InitialReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InitialReadDuplicate]
	(
		@Name VARCHAR(10)		
	)
	AS
	BEGIN
		SELECT Id	
		FROM Initial 
		WHERE Name = @Name				
	END'
End