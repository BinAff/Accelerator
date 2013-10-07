


create schema Customer

GO
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 04/02/2013 16:31:19 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatus]') AND type in (N'U'))
Begin
	CREATE TABLE [Customer].[ActionStatus](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End

GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 04/02/2013 16:32:31 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Customer].ActionStatus([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 04/02/2013 16:34:49 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Reservation].[StatusRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Customer].[ActionStatus]
		WHERE Id = @Id   
		
	END'
End

GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 04/02/2013 16:38:22 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusReadAll]	
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Customer].[ActionStatus]
		
	END'
End

GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 04/02/2013 16:45:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Customer].[ActionStatus]
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END'
End

GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 04/02/2013 16:50:01 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[ActionStatusDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Customer].[ActionStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Customer].[ActionStatus]
	WHERE Id = @Id   
   
END'
End


GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 04/28/2013 16:05:00 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsStateIdDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[IsStateIdDeletable]
	(
		@StateId NUMERIC(10,0)
	)
	AS
	BEGIN
		SELECT  FirstName, LastName, 
			(SELECT TOP 1 Number FROM CustomerContactNumber WHERE CustomerId = Customer.Id) ContactNumber
		FROM Customer
		WHERE StateId = @StateId

	 END'
End

GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 04/28/2013 16:25:03 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsInitialDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[IsInitialDeletable]
	(
		@InitialId NUMERIC(10,0)
	)
	AS
	BEGIN
		SELECT  FirstName, LastName, 
			(SELECT TOP 1 Number FROM CustomerContactNumber WHERE CustomerId = Customer.Id) ContactNumber
		FROM Customer
		WHERE InitialId = @InitialId

	 END' 
END

GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 04/28/2013 16:43:52 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer].[IsIdentityProofIdDeletable]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Customer].[IsIdentityProofIdDeletable]
	(
		@IdentityProofId NUMERIC(10,0)
	)
	AS
	BEGIN
		SELECT  FirstName, LastName, 
			(SELECT TOP 1 Number FROM CustomerContactNumber WHERE CustomerId = Customer.Id) ContactNumber
		FROM Customer
		WHERE IdentityProofId = @IdentityProofId

	 END' 
END