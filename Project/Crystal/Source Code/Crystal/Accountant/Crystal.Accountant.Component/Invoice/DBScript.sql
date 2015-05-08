
Create Schema Invoice


/****** Object:  Table [Invoice].[PaymentType]    Script Date: 05/27/2013 14:20:19 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentType]') AND type in (N'U'))
Begin
	CREATE TABLE [Invoice].[PaymentType](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[Name] [varchar](50) NOT NULL,
	 CONSTRAINT [PK_InvoicePaymentType] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
End


GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeInsert]    Script Date: 05/27/2013 14:55:06 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeInsert]
	(  
		@Name Varchar(50),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO  [Invoice].PaymentType([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END'
End

GO
/****** Object:  StoredProcedure [Invoice].[PaymentTypeRead]    Script Date: 05/27/2013 14:57:47 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Invoice].PaymentType
		WHERE Id = @Id   
		
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadAll]    Script Date: 05/27/2013 14:59:33 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[Name]
		FROM [Invoice].PaymentType
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentTypeUpdate]    Script Date: 05/27/2013 15:01:32 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeUpdate]
	(
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Invoice].PaymentType
		SET	
			[Name] = @Name	
		WHERE Id = @Id
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentTypeDelete]    Script Date: 05/27/2013 15:02:55 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].PaymentType
		WHERE Id = @Id   
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentTypeReadDuplicate]    Script Date: 05/27/2013 15:04:17 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentTypeReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentTypeReadDuplicate]
	(
		@Name VARCHAR(10)		
	)
	AS
	BEGIN
		SELECT Id	
		FROM [Invoice].PaymentType 
		WHERE Name = @Name				
	END'
End


/****** Object:  Table [Invoice].[Payment]    Script Date: 05/27/2013 16:32:42 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Payment]') AND type in (N'U'))
Begin
	CREATE TABLE [Invoice].[Payment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[CardNumber] [varchar](4) NULL,
	[Remark] [varchar](255) NULL,
	[PaymentTypeId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
	
	SET ANSI_PADDING OFF
	
	ALTER TABLE [Invoice].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_PaymentType] FOREIGN KEY([PaymentTypeId])
	REFERENCES [Invoice].[PaymentType] ([Id])
	
	ALTER TABLE [Invoice].[Payment] CHECK CONSTRAINT [FK_Payment_PaymentType]
	
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentInsert]    Script Date: 05/27/2013 19:44:08 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentInsert]
	(  	
		@CardNumber Varchar(4),
		@Remark Varchar(255),
		@PaymentTypeId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Invoice].[Payment]([CardNumber],[Remark],[PaymentTypeId],[Date])
		VALUES(@CardNumber,@Remark,@PaymentTypeId,GETDATE())
	   
		SET @Id = @@IDENTITY
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[IsPaymentTypeDeletable]    Script Date: 05/27/2013 20:23:00 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[IsPaymentTypeDeletable]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[IsPaymentTypeDeletable]
	(
		@PaymentTypeId NUMERIC(10,0)
	)
	AS
	BEGIN
		SELECT  Id,CardNumber,[Date],Remark
		FROM [Invoice].[Payment]
		WHERE PaymentTypeId = @paymentTypeId

	 END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentRead]    Script Date: 05/28/2013 12:10:14 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Date],
			[CardNumber],
			[Remark],
			[PaymentTypeId]
		FROM [Invoice].Payment
		WHERE Id = @Id   
		
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentReadAll]    Script Date: 05/28/2013 12:11:39 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[Date],
			[CardNumber],
			[Remark],
			[PaymentTypeId]
		FROM [Invoice].Payment
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentUpdate]    Script Date: 05/28/2013 12:14:34 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentUpdate]
	(
		@Id Numeric(10,0),
		@CardNumber Varchar(4),
		@Remark Varchar(255),
		@PaymentTypeId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Invoice].[Payment]
		SET			
			[CardNumber] = @CardNumber,
			[Remark] = @Remark,
			[PaymentTypeId] = @PaymentTypeId,
			[Date] = GETDATE()
		WHERE Id = @Id
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[PaymentDelete]    Script Date: 05/28/2013 12:16:04 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[PaymentDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[PaymentDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].[Payment]
		WHERE Id = @Id   
	   
	END'
End



Go
/****** Object:  Table [Invoice].[Taxation]    Script Date: 05/29/2013 19:20:15 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Taxation]') AND type in (N'U'))
Begin
	CREATE TABLE [Invoice].[Taxation](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[Name] [varchar](50) NOT NULL,
		[Amount] [money] NOT NULL,
		[IsPercentage] [bit] NOT NULL,
	 CONSTRAINT [PK_Taxation] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]
End


Go
/****** Object:  StoredProcedure [Invoice].[TaxationInsert]    Script Date: 05/29/2013 19:57:25 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationInsert]
	(  
		@Name Varchar(50),
		@Amount Money,
		@IsPercentage Bit,
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO  [Invoice].Taxation([Name],[Amount],[IsPercentage])
		VALUES(@Name,@Amount,@IsPercentage)
	   
		SET @Id = @@IDENTITY
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 05/29/2013 19:58:51 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,		
			[Name],
			[Amount],
			[IsPercentage]
		FROM [Invoice].Taxation
		WHERE Id = @Id   
		
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[TaxationReadAll]    Script Date: 05/29/2013 19:59:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,		
			[Name],
			[Amount],
			[IsPercentage]
		FROM [Invoice].Taxation
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[TaxationReadDuplicate]    Script Date: 05/29/2013 20:00:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationReadDuplicate]
	(
		@Name VARCHAR(50)		
	)
	AS
	BEGIN
		SELECT Id	
		FROM [Invoice].Taxation 
		WHERE Name = @Name				
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[TaxationDelete]    Script Date: 05/29/2013 20:02:06 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].Taxation
		WHERE Id = @Id   
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[TaxationUpdate]    Script Date: 05/29/2013 20:03:05 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[TaxationUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[TaxationUpdate]
	(
		@Id Numeric(10,0),
		@Name Varchar(50),
		@Amount Money,
		@IsPercentage Bit
	)
	AS
	BEGIN
		
		UPDATE [Invoice].Taxation
		SET	
			[Name] = @Name,	
			[Amount] = @Amount,
			[IsPercentage] = @IsPercentage
		WHERE Id = @Id
	   
	END'
End



Go
/****** Object:  StoredProcedure [Invoice].[Insert]    Script Date: 06/04/2013 20:05:57 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Insert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[Insert]
	(  
		@InvoiceNumber Varchar(50),
		@Advance Money,
		@Discount Money,
		
		@SellerName Varchar(50),
		@SellerAddress Varchar(250),
		@SellerContactNo Varchar(50),
		@SellerEmail Varchar(50),
		@SellerLicence Varchar(50),
		
		@BuyerName Varchar(50),
		@BuyerAddress Varchar(250),
		@BuyerContactNo Varchar(50),
		@BuyerEmail Varchar(50),	
		
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO  [Invoice].Invoice([Date],[InvoiceNumber],[Advance],[Discount],[SellerName],[SellerAddress],[SellerContactNo],[SellerEmail],[SellerLicence],[BuyerName],[BuyerAddress],[BuyerContactNo],[BuyerEmail])
		VALUES(GETDATE(),@InvoiceNumber,@Advance,@Discount,@SellerName,@SellerAddress,@SellerContactNo,@SellerEmail,@SellerLicence,@BuyerName,@BuyerAddress,@BuyerContactNo,@BuyerEmail)
	   
		SET @Id = @@IDENTITY
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[Read]    Script Date: 06/04/2013 20:07:24 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Read]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[Read]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		
		SELECT 
			Id,
			[Date],
			[InvoiceNumber],
			[Advance],
			[Discount],
			[SellerName],
			[SellerAddress],
			[SellerContactNo],
			[SellerEmail],
			[SellerLicence],
			[BuyerName],
			[BuyerAddress],
			[BuyerContactNo],
			[BuyerEmail]
			
		FROM [Invoice].Invoice
		WHERE Id = @Id   
		
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[ReadAll]    Script Date: 06/04/2013 20:08:46 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[ReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[Date],
			[InvoiceNumber],
			[Advance],
			[Discount],
			[SellerName],
			[SellerAddress],
			[SellerContactNo],
			[SellerEmail],
			[SellerLicence],
			[BuyerName],
			[BuyerAddress],
			[BuyerContactNo],
			[BuyerEmail]
		FROM [Invoice].Invoice
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[Update]    Script Date: 06/04/2013 20:09:56 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Update]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[Update]
	(
		@Id Numeric(10,0),
		@InvoiceNumber Varchar(50),
		@Advance Money,
		@Discount Money,
		
		@SellerName Varchar(50),
		@SellerAddress Varchar(250),
		@SellerContactNo Varchar(50),
		@SellerEmail Varchar(50),
		@SellerLicence Varchar(50),
		
		@BuyerName Varchar(50),
		@BuyerAddress Varchar(250),
		@BuyerContactNo Varchar(50),
		@BuyerEmail Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Invoice].Invoice
		SET	
			[Date] = GETDATE(),
			[InvoiceNumber] = @InvoiceNumber,
			[Advance] = @Advance,
			[Discount] = @Discount,
			[SellerName] = @SellerName,
			[SellerAddress] = @SellerAddress,
			[SellerContactNo] = @SellerContactNo,
			[SellerEmail] = @SellerEmail,
			[SellerLicence] = @SellerLicence,
			[BuyerName] = @BuyerName,
			[BuyerAddress] = @BuyerAddress,
			[BuyerContactNo] = @BuyerContactNo,
			[BuyerEmail] = @BuyerEmail
		WHERE Id = @Id
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[Delete]    Script Date: 06/04/2013 20:11:18 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Delete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[Delete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].Invoice
		WHERE Id = @Id   
	   
	END'
End

/****** Object:  StoredProcedure [Invoice].[ReadDuplicate]    Script Date: 06/05/2013 14:44:20 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[ReadDuplicate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[ReadDuplicate]
	(
		@InvoiceNumber VARCHAR(50)		
	)
	AS
	BEGIN
		SELECT Id	
		FROM [Invoice].Invoice
		WHERE InvoiceNumber = @InvoiceNumber		
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[LineItemRead]    Script Date: 06/05/2013 15:53:47 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemRead]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		SELECT 
			Id,
			[Start],
			[End],
			[Description],
			[UnitRate],
			[Count]
		FROM [Invoice].LineItem
		WHERE Id = @Id   
		
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[LineItemReadAll]    Script Date: 06/05/2013 15:54:54 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadAll]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemReadAll]
	AS
	BEGIN
		
		SELECT 
			Id,
			[Start],
			[End],
			[Description],
			[UnitRate],
			[Count]
		FROM [Invoice].LineItem
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[LineItemUpdate]    Script Date: 06/05/2013 15:55:59 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemUpdate]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemUpdate]
	(
		@Id Numeric(10,0),
		@Start DateTime,
		@End DateTime,
		@Description Varchar(250),
		@UnitRate Money,
		@Count Int
	)
	AS
	BEGIN
		
		UPDATE [Invoice].LineItem
		SET	
			[Start] = @Start,
			[End] = @End,
			[Description] = @Description,
			[UnitRate] = @UnitRate,
			[Count] = @Count
		WHERE Id = @Id
	   
	END'
End


Go
/****** Object:  StoredProcedure [Invoice].[LineItemDelete]    Script Date: 06/05/2013 15:57:04 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].LineItem
		WHERE Id = @Id   
	   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[LineItemReadForParent]    Script Date: 06/05/2013 17:30:59 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemReadForParent]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'Create PROCEDURE [Invoice].[LineItemReadForParent]
	(
		@ParentId Numeric(10,0)
	)
	AS
	BEGIN		
		SELECT 
			Id,
			[Start],
			[End],
			[Description],
			[UnitRate],
			[Count]
		FROM [Invoice].LineItem
		WHERE InvoiceId = @ParentId   
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[LineItemInsert]    Script Date: 06/05/2013 17:32:49 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItemInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[LineItemInsert]
	(  
		@Start DateTime,
		@End DateTime,
		@Description Varchar(250),
		@UnitRate Money,
		@Count Int,
		@InvoiceId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO  [Invoice].LineItem([Start],[End],[Description],[UnitRate],[Count],[InvoiceId])
		VALUES(@Start,@End,@Description,@UnitRate,@Count,@InvoiceId)
	   
		SET @Id = @@IDENTITY
	END'
End

/****** Object:  Table [Invoice].[Invoice]    Script Date: 06/05/2013 17:34:31 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[Invoice]') AND type in (N'U'))
Begin
	CREATE TABLE [Invoice].[Invoice](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[InvoiceNumber] [varchar](50) NOT NULL,
		[Date] [datetime] NOT NULL,
		[Advance] [money] NULL,
		[Discount] [money] NULL,
		[SellerName] [varchar](50) NOT NULL,
		[SellerAddress] [varchar](250) NULL,
		[SellerContactNo] [varchar](50) NULL,
		[SellerEmail] [varchar](50) NULL,
		[SellerLicence] [varchar](50) NULL,
		[BuyerName] [varchar](50) NOT NULL,
		[BuyerAddress] [varchar](250) NULL,
		[BuyerContactNo] [varchar](50) NULL,
		[BuyerEmail] [varchar](50) NULL,
	 CONSTRAINT [PK_Invoice] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

End

Go
/****** Object:  Table [Invoice].[LineItem]    Script Date: 06/05/2013 17:35:48 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[LineItem]') AND type in (N'U'))
Begin
	CREATE TABLE [Invoice].[LineItem](
		[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
		[InvoiceId] [numeric](10, 0) NOT NULL,
		[Start] [datetime] NULL,
		[End] [datetime] NULL,
		[Description] [varchar](250) NOT NULL,
		[UnitRate] [money] NOT NULL,
		[Count] [int] NOT NULL,
	 CONSTRAINT [PK_LineItem] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

	SET ANSI_PADDING OFF
	
	ALTER TABLE [Invoice].[LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Invoice] FOREIGN KEY([InvoiceId])
	REFERENCES [Invoice].[Invoice] ([Id])

	ALTER TABLE [Invoice].[LineItem] CHECK CONSTRAINT [FK_LineItem_Invoice]
	
End


Go
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 06/11/2013 14:05:24 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
	(  
		@InvoiceId Numeric(10,0),
		@TaxationId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO  [Invoice].InvoiceTaxationLink([InvoiceId],[TaxationId])
		VALUES(@InvoiceId,@TaxationId)
	   
		SET @Id = @@IDENTITY
	END'
End

Go
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 06/11/2013 15:15:59 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
	 (
		@InvoiceId Numeric(10,0)
	 )
	 As
	 Begin
		Select  [InvoiceId],[TaxationId]
		From [Invoice].InvoiceTaxationLink
		Where InvoiceId = @InvoiceId
	 End'
End

Go
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 06/11/2013 16:26:58 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoiceTaxationLinkDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].InvoiceTaxationLink
		WHERE InvoiceId = @Id   
	   
	END'
End

/****** Object:  Table [Invoice].[InvoicePaymentLink]    Script Date: 06/17/2013 18:35:02 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLink]') AND type in (N'U'))
Begin
	CREATE TABLE [Invoice].[InvoicePaymentLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InvoiceId] [numeric](10, 0) NOT NULL,
	[PaymentId] [numeric](10, 0) NOT NULL,
	 CONSTRAINT [PK_InvoicePaymentLink] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]


	ALTER TABLE [Invoice].[InvoicePaymentLink]  WITH CHECK ADD  CONSTRAINT [FK_InvoicePaymentLink_Invoice] FOREIGN KEY([InvoiceId])
	REFERENCES [Invoice].[Invoice] ([Id])	

	ALTER TABLE [Invoice].[InvoicePaymentLink] CHECK CONSTRAINT [FK_InvoicePaymentLink_Invoice]
	
	ALTER TABLE [Invoice].[InvoicePaymentLink]  WITH CHECK ADD  CONSTRAINT [FK_InvoicePaymentLink_Payment] FOREIGN KEY([PaymentId])
	REFERENCES [Invoice].[Payment] ([Id])
	
	ALTER TABLE [Invoice].[InvoicePaymentLink] CHECK CONSTRAINT [FK_InvoicePaymentLink_Payment]
		
End

/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 06/17/2013 18:43:24 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkInsert]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
	(  
		@InvoiceId Numeric(10,0),
		@PaymentId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO  [Invoice].InvoicePaymentLink([InvoiceId],[PaymentId])
		VALUES(@InvoiceId,@PaymentId)
	   
		SET @Id = @@IDENTITY
	END'
End


/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 06/17/2013 18:51:16 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkRead]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoicePaymentLinkRead]
	 (
		@InvoiceId Numeric(10,0)
	 )
	 As
	 Begin
		Select  [InvoiceId],[PaymentId]
		From [Invoice].InvoicePaymentLink
		Where InvoiceId = @InvoiceId
	 End'
End

/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 06/17/2013 18:56:02 ******/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Invoice].[InvoicePaymentLinkDelete]') AND type in (N'U'))
Begin
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Invoice].InvoicePaymentLink
		WHERE InvoiceId = @Id   
	   
	END'
End