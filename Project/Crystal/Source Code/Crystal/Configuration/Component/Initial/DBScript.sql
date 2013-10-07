
/****** Object:  Table [Configuration].[Initial]    Script Date: 09/19/2013 17:53:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Configuration].[Initial](
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

/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 09/19/2013 17:53:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[InitialInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Configuration].Initial([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END

GO

/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 09/19/2013 17:53:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[InitialRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].Initial
	WHERE Id = @Id   
	
END

GO

/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 09/19/2013 17:54:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[InitialReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].Initial
   
END

GO

/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 09/19/2013 17:54:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[InitialUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Configuration].Initial
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END

GO

/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 09/19/2013 17:55:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[InitialDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Configuration].Initial
	WHERE Id = @Id   
   
END

GO

/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 09/19/2013 17:55:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Configuration].[InitialReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN
	SELECT Id	
	FROM [Configuration].Initial 
	WHERE Name = @Name				
END

GO
