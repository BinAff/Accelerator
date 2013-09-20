

/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 09/19/2013 17:49:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [Configuration].[IdentityProofType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_IdentityProofType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 09/19/2013 17:49:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[IdentityProofTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Configuration].IdentityProofType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END


GO

/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 09/19/2013 17:50:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE PROCEDURE [Configuration].[IdentityProofTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].IdentityProofType
	WHERE Id = @Id   
	
END


GO

/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 09/19/2013 17:50:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Configuration].[IdentityProofTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Configuration].IdentityProofType
   
END

GO

/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 09/19/2013 17:51:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Configuration].[IdentityProofTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Configuration].IdentityProofType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END

GO

/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 09/19/2013 17:51:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [Configuration].[IdentityProofTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Configuration].IdentityProofType
	WHERE Id = @Id   
   
END

GO

/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 09/19/2013 17:52:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Configuration].[IdentityProofTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN
	SELECT Id	
	FROM [Configuration].IdentityProofType 
	WHERE Name = @Name				
END
GO
