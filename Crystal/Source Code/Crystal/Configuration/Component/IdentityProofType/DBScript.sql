
/****** Object:  Table [dbo].[IdentityProofType]    Script Date: 05/02/2012 23:12:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[IdentityProofType](
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

/****** Object:  StoredProcedure [dbo].[IdentityProofTypeInsert]    Script Date: 05/02/2012 23:12:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdentityProofTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO IdentityProofType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END

GO

/****** Object:  StoredProcedure [dbo].[IdentityProofTypeRead]    Script Date: 05/02/2012 23:14:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdentityProofTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM IdentityProofType
	WHERE Id = @Id   
	
END

GO

/****** Object:  StoredProcedure [dbo].[IdentityProofTypeReadAll]    Script Date: 05/02/2012 23:14:12 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdentityProofTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM IdentityProofType
   
END

GO

/****** Object:  StoredProcedure [dbo].[IdentityProofTypeUpdate]    Script Date: 05/02/2012 23:15:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdentityProofTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE IdentityProofType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END

GO

/****** Object:  StoredProcedure [dbo].[IdentityProofTypeDelete]    Script Date: 05/02/2012 23:15:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[IdentityProofTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM IdentityProofType
	WHERE Id = @Id   
   
END

GO

GO
/****** Object:  StoredProcedure [dbo].[IdentityProofTypeReadDuplicate]    Script Date: 04/29/2013 14:56:51 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[IdentityProofTypeReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[IdentityProofTypeReadDuplicate]
	(
		@Name VARCHAR(10)		
	)
	AS
	BEGIN
		SELECT Id	
		FROM IdentityProofType 
		WHERE Name = @Name				
	END'
End