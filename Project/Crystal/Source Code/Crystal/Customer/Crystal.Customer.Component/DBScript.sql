
CREATE TABLE [dbo].[Customer](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InitialId] [numeric](10, 0) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](255) NOT NULL,
	[StateId] [numeric](10, 0) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Pin] [numeric](10, 0) NULL,
	[Email] [varchar](50) NULL,
	[IdentityProofId] [numeric](10, 0) NULL,
	[IdentityProofName] [varchar](50) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_IdentityProofId] FOREIGN KEY([IdentityProofId])
REFERENCES [dbo].[IdentityProofType] ([Id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [Customer_FK_IdentityProofId]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_InitialId] FOREIGN KEY([InitialId])
REFERENCES [dbo].[Initial] ([Id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [Customer_FK_InitialId]
GO

ALTER TABLE [dbo].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_StateId] FOREIGN KEY([StateId])
REFERENCES [dbo].[State] ([Id])
GO

ALTER TABLE [dbo].[Customer] CHECK CONSTRAINT [Customer_FK_StateId]
GO

/****** Object:  Table [dbo].[CustomerContactNumber]    Script Date: 04/19/2012 22:26:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CustomerContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CustomerContactNumber]  WITH CHECK ADD  CONSTRAINT [CustomerContactNumber_FK_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customer] ([Id])
GO

ALTER TABLE [dbo].[CustomerContactNumber] CHECK CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO

/*************************************************************/
CREATE PROCEDURE CustomerCheck
(
	@Email Varchar(50),
	@IdentityProofId Int,
	@IdentityProofName Varchar(50)
)
As
Begin

	Declare @Cnt Int
	
	Select @Cnt = COUNT(*) From Customer Where Email = @Email
	
	if @Cnt = 0 And @IdentityProofId > 0
	Begin
		Select @Cnt = COUNT(*) From Customer 
		Where IdentityProofId = @IdentityProofId	
		And IdentityProofName = @IdentityProofName		
	End
	
	if @Cnt > 0
	Begin
		Select @Cnt
	End
End
/************************************************/
CREATE PROCEDURE CustomerContactCheck
(
	@ContactNumber Varchar(50)
)
As
Begin

	Declare @Cnt Int
	
	Select @Cnt = COUNT(*) From CustomerContactNumber Where Number = @ContactNumber	
	
	if @Cnt > 0
	Begin
		Select @Cnt
	End
End
/************************************************/
CREATE PROCEDURE [dbo].[CustomerInsert]
(  
	@InitialId Numeric(10,0),
	@FirstName Varchar(50),
	@MiddleName Varchar(50),
	@LastName Varchar(50),
	@Address Varchar(255),
	@StateId Numeric(10,0),
	@City Varchar(50),
	@Pin Int,
	@Email Varchar(50),
	@IdentityProofId Numeric(10,0),
	@IdentityProofName Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	IF @InitialId = 0
	Begin
		Set @InitialId = null
	End

	IF @IdentityProofId = 0
	Begin
		Set @IdentityProofId = null
	End
	
	INSERT INTO Customer([InitialId],[FirstName],[MiddleName],[LastName],
		[Address],[StateId],[City],[Pin],[Email],[IdentityProofId],[IdentityProofName])
	VALUES(@InitialId,@FirstName,@MiddleName,@LastName,@Address,@StateId,@City,@Pin,@Email,@IdentityProofId,@IdentityProofName)
   
	SET @Id = @@IDENTITY
END
/************************************************/
CREATE PROCEDURE [dbo].[CustomerContactNumberInsert]
(  
	@CustomerId Numeric(10,0),
	@ContactNumber Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN		
	
	INSERT INTO CustomerContactNumber([Number],[CustomerId])
	VALUES(@ContactNumber,@CustomerId)
   
	SET @Id = @@IDENTITY
END
/************************************************/
CREATE PROCEDURE [dbo].[CustomerUpdate]
(  
	@Id  Numeric(10,0),
	@InitialId Numeric(10,0),
	@FirstName Varchar(50),
	@MiddleName Varchar(50),
	@LastName Varchar(50),
	@Address Varchar(255),
	@StateId Numeric(10,0),
	@City Varchar(50),
	@Pin Int,
	@Email Varchar(50),
	@IdentityProofId Numeric(10,0),
	@IdentityProofName Varchar(50)	
)
AS
BEGIN	
	IF @InitialId = 0
	Begin
		Set @InitialId = null
	End

	IF @IdentityProofId = 0
	Begin
		Set @IdentityProofId = null
	End
	
	UPDATE Customer
	Set [InitialId] = @InitialId,
		[FirstName] = @FirstName,
		[MiddleName] = @MiddleName,
		[LastName] = @LastName,
		[Address] = @Address,
		[StateId] = @StateId,
		[City] = @City,
		[Pin] = @Pin,
		[Email] = @Email,
		[IdentityProofId] = @IdentityProofId,
		[IdentityProofName] = @IdentityProofName
	Where Id = @Id
   
END
/************************************************/
CREATE PROCEDURE [dbo].[CustomerContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM CustomerContactNumber
	WHERE CustomerId = @Id   
   
END
/************************************************/
 CREATE PROCEDURE CustomerRead
 (
	@Id Numeric(10,0)
 )
 As
 Begin
	Select  Id,InitialId,FirstName,MiddleName,LastName,
			[Address],StateId,City,Pin,Email,IdentityProofId,
			IdentityProofName 
	From Customer
	Where Id = @Id

 End
/************************************************/
CREATE PROCEDURE CustomerReadAll
As
Begin
	Select Id,InitialId,FirstName,MiddleName,LastName,
		[Address],StateId,City,Pin,Email,IdentityProofId,
		IdentityProofName 
	From Customer
End
/************************************************/
CREATE PROCEDURE CustomerContactNumberRead
(
	@Id Numeric(10,0)
)
As
Begin
	Select Id,Number,CustomerId From CustomerContactNumber
	Where CustomerId = @Id
End
/************************************************/
CREATE PROCEDURE [dbo].[CustomerReadDuplicate]
(
	@ContactNumber VARCHAR(100),
	@Email VARCHAR(50),
	@IdentityProofId INT,
	@IdentityProofName VARCHAR(50)
)
AS
BEGIN
	
	SELECT Id	
	FROM Customer 
		WHERE (IdentityProofId = @IdentityProofId	
		AND IdentityProofName = @IdentityProofName)
		OR (Email = @Email AND @Email != '')
		OR ID IN (SELECT CustomerId FROM CustomerContactNumber 
			WHERE Number IN (SELECT SplitText FROM Split(@ContactNumber, ',')))
END
/************************************************/