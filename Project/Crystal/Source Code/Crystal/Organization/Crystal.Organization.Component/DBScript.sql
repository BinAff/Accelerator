
create schema Organization

GO

/****** Object:  Table [Organization].[Organization]    Script Date: 02/17/2013 16:58:18 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Organization]') AND type in (N'U'))
Begin

CREATE TABLE [Organization].[Organization](
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
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

End

/****** Object:  Table [Organization].[Email]    Script Date: 02/17/2013 16:58:18 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Email]') AND type in (N'U'))
Begin

CREATE TABLE [Organization].[Email](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

ALTER TABLE [Organization].[Email]  WITH CHECK ADD  CONSTRAINT [Organization_FK_Id] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])

ALTER TABLE [Organization].[Email] CHECK CONSTRAINT [Organization_FK_Id]

End

/****** Object:  Table [Organization].[Fax]    Script Date: 02/17/2013 17:03:03 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[Fax]') AND type in (N'U'))
Begin


CREATE TABLE [Organization].[Fax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Fax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF


ALTER TABLE [Organization].[Fax]  WITH CHECK ADD  CONSTRAINT [Organization_FK_FaxId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])


ALTER TABLE [Organization].[Fax] CHECK CONSTRAINT [Organization_FK_FaxId]

End

/****** Object:  Table [Organization].[ContactNumber]    Script Date: 02/17/2013 17:06:50 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumber]') AND type in (N'U'))
Begin

CREATE TABLE [Organization].[ContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_ContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


SET ANSI_PADDING OFF

ALTER TABLE [Organization].[ContactNumber]  WITH CHECK ADD  CONSTRAINT [Organization_FK_ContactNumberId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])


ALTER TABLE [Organization].[ContactNumber] CHECK CONSTRAINT [Organization_FK_ContactNumberId]

End

/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 02/17/2013 17:42:02 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[ContactNumberReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[OrganizationId],
			[ContactNumber]
		FROM [Organization].ContactNumber
		WHERE OrganizationId = @ParentId   
	END'
End

/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 02/18/2013 10:44:07 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[OrganizationId],
			[Email]
		FROM [Organization].Email
		WHERE OrganizationId = @ParentId   
	END'
End

/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 02/18/2013 10:54:34 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[FaxReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[OrganizationId],
			[Fax]
		FROM [Organization].Fax
		WHERE OrganizationId = @ParentId   
	END'
End

/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 02/18/2013 11:55:56 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[OrganizationInsert]
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
	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From [Organization].Organization
	
	if(@Cnt > 0)
	Begin	
		UPDATE [Organization].Organization
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
	End
	Else
	Begin
		INSERT INTO [Organization].Organization([Name],[Logo],[LicenceNumber],[Tan],[Address],[City],[StateId],[Pin],[ContactName])
		VALUES(@Name,@Logo,@LicenceNumber,@Tan,@Address,@City,@StateId,@Pin,@ContactName)
   
	End
    
	SET @Id = @@IDENTITY
END'
End

/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 02/18/2013 11:55:27 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailInsert]
(  
	@Email Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Organization].Email([Email],[OrganizationId])
	VALUES(@Email,@OrganizationId)
   
	SET @Id = @@IDENTITY
END'
End

/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 02/18/2013 12:34:55 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[OrganizationRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN	
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
	FROM Organization	
END'
End

/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 02/18/2013 16:53:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[OrganizationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].Organization
	WHERE Id = @Id   
   
END'
End

/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 02/18/2013 17:00:24 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN	
		SELECT 
			Id,
			[Email],			
			[OrganizationId]
		FROM [Organization].[Email]
		WHERE Id = @Id	
END'
End

/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 02/18/2013 17:06:33 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[EmailDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[EmailDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[Email]
	WHERE Id = @Id   
   
END'
End

/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 02/18/2013 17:26:19 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[OrganizationUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Organization].[OrganizationUpdate]
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
	
	UPDATE [Organization].Organization
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
   
END'
End

/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 02/19/2013 12:09:54 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[FaxInsert]
(  
	@Fax Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Organization].Fax(Fax,[OrganizationId])
	VALUES(@Fax,@OrganizationId)
   
	SET @Id = @@IDENTITY
END'
End

/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 02/19/2013 12:10:34 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberInsert]
(  
	@ContactNumber Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Organization].ContactNumber(ContactNumber,[OrganizationId])
	VALUES(@ContactNumber,@OrganizationId)
   
	SET @Id = @@IDENTITY
END'
End

/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 02/20/2013 11:09:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN	
		SELECT 
			Id,
			[ContactNumber],			
			[OrganizationId]
		FROM [Organization].[ContactNumber]
		WHERE Id = @Id	
END'
End

/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 02/20/2013 11:13:50 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[ContactNumberDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[ContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[ContactNumber]
	WHERE Id = @Id   
   
END'
End

/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 02/20/2013 11:43:28 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[FaxRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN	
		SELECT 
			Id,
			[Fax],			
			[OrganizationId]
		FROM [Organization].[Fax]
		WHERE Id = @Id	
END'
End

GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 02/20/2013 11:44:03 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[FaxDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[FaxDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[Fax]
	WHERE Id = @Id 
END'
End

GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 04/28/2013 16:07:01 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Organization].[IsStateIdDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Organization].[IsStateIdDeletable]
	(
		@StateId NUMERIC(10,0)
	)
	AS
	BEGIN
		SELECT  Name
		FROM [Organization].Organization
		WHERE StateId = @StateId

	 END'
End