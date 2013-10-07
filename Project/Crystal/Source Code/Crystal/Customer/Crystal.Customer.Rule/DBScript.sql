
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerRule]') AND type in (N'U'))
CREATE TABLE [dbo].[CustomerRule](
	[Id] Numeric(10,0) IDENTITY(1,1) NOT NULL,
	[IsPinNo] [bit] NULL,
	[IsAlternateContactNo] [bit] NULL,
	[IsEmail] [bit] NULL,
	[IsIdentityProof] [bit] NULL
) ON [PRIMARY]


/*************C*************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerRuleInsert]') AND type in (N'P', N'PC'))
BEGIN
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CustomerRuleInsert]
	(  
		@IsPinNumber Bit,
		@IsAlternateContactNumber Bit,
		@IsEmail Bit,
		@IsIdentityProof Bit,	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		INSERT INTO CustomerRule([IsPinNo],[IsAlternateContactNo],[IsEmail],[IsIdentityProof])
		VALUES(@IsPinNumber,@IsAlternateContactNumber, @IsEmail,@IsIdentityProof)		
	    
		SET @Id = 1
	END'
End

/*************R*************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerRuleRead]') AND type in (N'P', N'PC'))
Begin
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CustomerRuleRead]  
	(  
	   @Id Numeric(10,0)  
	)  
	AS  
	BEGIN  
	   
		Select 
		IsNull(IsPinNo,0) IsPinNo,
		IsNull(IsAlternateContactNo,0) IsAlternateContactNo,
		IsNull(IsEmail,0) IsEmail,
		IsNull(IsIdentityProof,0) IsIdentityProof 
		From CustomerRule
	 
	END'
End

/************U**************/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerRuleUpdate]') AND type in (N'P', N'PC'))
Begin
	EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[CustomerRuleUpdate]
	(  
		@Id Numeric(10,0),  
		@IsPinNumber Bit,
		@IsAlternateContactNumber Bit,
		@IsEmail Bit,
		@IsIdentityProof Bit		
	)
	AS
	BEGIN
		update CustomerRule
		Set [IsPinNo] = @IsPinNumber,		
			[IsAlternateContactNo] = @IsAlternateContactNumber,
			[IsEmail] = @IsEmail,
			[IsIdentityProof] = @IsIdentityProof		
	END'
End