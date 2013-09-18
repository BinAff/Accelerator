/****** Object:  Table [dbo].[Lodge]    Script Date: 03/27/2012 14:45:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Lodge](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Logo] [varbinary](max) NULL,
	[LicenceNumber] [varchar](50) NULL,
	[Tan] [varchar](50) NULL,
	[Address] [varchar](255) NULL,
	[City] [varchar](50) NULL,
	[StateId] [numeric](10, 0) NULL,
	[Pin] [int] NULL,
	[ContactName] [varchar](50) NULL,
 CONSTRAINT [PK_Lodge] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Lodge]  WITH CHECK ADD  CONSTRAINT [Lodge_FK_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO

ALTER TABLE [dbo].[Lodge] CHECK CONSTRAINT [Lodge_FK_StateId]
GO

/****** Object:  Table [dbo].[LodgeContactNumber]    Script Date: 03/27/2012 14:46:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LodgeContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[LodgeId] [numeric](10, 0) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LodgeContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LodgeContactNumber]  WITH CHECK ADD  CONSTRAINT [FK_LodgeContactNumber_Lodge] FOREIGN KEY([LodgeId])
REFERENCES [dbo].[Lodge] ([Id])
GO

ALTER TABLE [dbo].[LodgeContactNumber] CHECK CONSTRAINT [FK_LodgeContactNumber_Lodge]
GO


/****** Object:  Table [dbo].[LodgeEmail]    Script Date: 03/27/2012 14:46:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LodgeEmail](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[LodgeId] [numeric](10, 0) NOT NULL,
	[Email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LodgeEmail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LodgeEmail]  WITH CHECK ADD  CONSTRAINT [LodgeEmail_FK_LodgeId] FOREIGN KEY([LodgeId])
REFERENCES [dbo].[Lodge] ([Id])
GO

ALTER TABLE [dbo].[LodgeEmail] CHECK CONSTRAINT [LodgeEmail_FK_LodgeId]
GO


/****** Object:  Table [dbo].[LodgeFax]    Script Date: 03/27/2012 14:46:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LodgeFax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[LodgeId] [numeric](10, 0) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
 CONSTRAINT [PK_LodgeFax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[LodgeFax]  WITH CHECK ADD  CONSTRAINT [LodgeFax_FK_LodgeId] FOREIGN KEY([LodgeId])
REFERENCES [dbo].[Lodge] ([Id])
GO

ALTER TABLE [dbo].[LodgeFax] CHECK CONSTRAINT [LodgeFax_FK_LodgeId]
GO

/****** ******/
Create PROCEDURE [dbo].[LodgeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Lodge
	WHERE Id = @Id   
   
END

GO

Create PROCEDURE [dbo].[LodgeInsert]
(  
	@Name Varchar(50),
	@Logo Varbinary(max) = null,
	@LicenceNumber Varchar(50) = null,
	@Tan Varchar(50) = null,
	@Address Varchar(255) = null,
	@City Varchar(50) = null,
	@StateId Numeric(10,0) = null,
	@Pin Int = null,
	@ContactName Varchar(50) = null,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Lodge([Name],[Logo],[LicenceNumber],[Tan],[Address],[City],[StateId],[Pin],[ContactName])
	VALUES(@Name,@Logo,@LicenceNumber,@Tan,@Address,@City,@StateId,@Pin,@ContactName)
   
	SET @Id = @@IDENTITY
END

GO

CREATE PROCEDURE [dbo].[LodgeRead] 
(
	@Id Numeric(10,0) = null
)
AS
BEGIN
	
	if(ISNULL(@Id,0) = 0)
	Begin
		SELECT Top 1
				Id,
				[Name],
				[Logo],
				[LicenceNumber],
				[Tan],
				[Address],
				[City],
				[StateId],
				[Pin],
				[ContactName]
			FROM Lodge
	End
	Else
	Begin	
		SELECT 
			Id,
			[Name],
			[Logo],
			[LicenceNumber],
			[Tan],
			[Address],
			[City],
			[StateId],
			[Pin],
			[ContactName]
		FROM Lodge
		WHERE Id = @Id   
	End
	
END

GO

CREATE PROCEDURE [dbo].[LodgeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		Name,
		Logo,
		LicenceNumber,
		[Tan],
		[Address],
		City,
		StateId,
		Pin,
		ContactName
	FROM Lodge
   
END

GO
Create PROCEDURE [dbo].[LodgeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Logo Varbinary(max) = null,
	@LicenceNumber Varchar(50) = null,
	@Tan Varchar(50) = null,
	@Address Varchar(255) = null,
	@City Varchar(50) = null,
	@StateId Numeric(10,0) = null,
	@Pin Int = null,
	@ContactName Varchar(50) = null
)
AS
BEGIN
	
	UPDATE Lodge
	SET	
		[Name] = @Name,	
		[Logo] = @Logo,
		[LicenceNumber] = @LicenceNumber,
		[Tan] = @Tan,
		[Address] = @Address,
		[City] = @City,
		[StateId] = @StateId,
		[Pin] = @Pin,
		[ContactName] = @ContactName
	WHERE Id = @Id
   
END

/****** ******/

GO

CREATE PROCEDURE [dbo].[LodgeContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM LodgeContactNumber
	WHERE Id = @Id   
   
END


GO
CREATE PROCEDURE [dbo].[LodgeContactNumberUpdate]
(
	@Id Numeric(10,0),
	@LodgeId Numeric(10,0),
	@ContactNumber Int	
)
AS
BEGIN
	
	UPDATE LodgeContactNumber
	SET	
		[LodgeId] = @LodgeId,	
		[ContactNumber] = @ContactNumber
	WHERE Id = @Id
   
END


GO

CREATE PROCEDURE [dbo].[LodgeContactNumberRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[LodgeId],
		[ContactNumber]
	FROM LodgeContactNumber
	WHERE Id = @Id   
	
END


GO

CREATE PROCEDURE [dbo].[LodgeContactNumberInsert]
(  
	@LodgeId Numeric(10,0),
	@ContactNumber Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO LodgeContactNumber(LodgeId,ContactNumber)
	VALUES(@LodgeId,@ContactNumber)
   
	SET @Id = @@IDENTITY
END

/****** ******/
GO

CREATE PROCEDURE [dbo].[LodgeEmailDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM LodgeEmail
	WHERE Id = @Id   
   
END


GO

CREATE PROCEDURE [dbo].[LodgeEmailInsert]
(  
	@LodgeId Numeric(10,0),
	@Email Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO LodgeEmail([LodgeId],[Email])
	VALUES(@LodgeId,@Email)
   
	SET @Id = @@IDENTITY
END


GO

CREATE PROCEDURE [dbo].[LodgeEmailRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[LodgeId],
		[Email]
	FROM LodgeEmail
	WHERE Id = @Id   
	
END


GO
CREATE PROCEDURE [dbo].[LodgeEmailUpdate]
(
	@Id Numeric(10,0),
	@LodgeId Numeric(10,0),
	@Email Varchar(50)	
)
AS
BEGIN
	
	UPDATE LodgeEmail
	SET	
		[LodgeId] = @LodgeId,	
		[Email] = @Email
	WHERE Id = @Id
   
END

/****** ******/


GO

CREATE PROCEDURE [dbo].[LodgeFaxDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM LodgeFax
	WHERE Id = @Id   
   
END


GO

CREATE PROCEDURE [dbo].[LodgeFaxInsert]
(  
	@LodgeId Numeric(10,0),
	@Fax Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO LodgeFax([LodgeId],[Fax])
	VALUES(@LodgeId,@Fax)
   
	SET @Id = @@IDENTITY
END


GO

CREATE PROCEDURE [dbo].[LodgeFaxRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[LodgeId],
		[Fax]
	FROM LodgeFax
	WHERE Id = @Id   
	
END


GO
CREATE PROCEDURE [dbo].[LodgeFaxUpdate]
(
	@Id Numeric(10,0),
	@LodgeId Numeric(10,0),
	@Fax Int
)
AS
BEGIN
	
	UPDATE LodgeFax
	SET	
		[LodgeId] = @LodgeId,	
		[Fax] = @Fax
	WHERE Id = @Id
   
END


/****** ******/




