USE [AutoTourism]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------Table---------
CREATE TABLE [License].[Module](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
	[IsForm] [bit] NULL,
	[IsReport] [bit] NULL,
	[IsCatalogue] [bit] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

----------Create----------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleInsert]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [License].[ModuleInsert]
GO
CREATE PROCEDURE [License].[ModuleInsert]
(
	@Name Varchar(50),
	@Description Varchar(50),
	@IsForm Bit,
	@IsReport Bit,
	@IsCatalogue Bit,
	@Id  Numeric(10,0) OUTPUT
)
As
Begin
	INSERT INTO License.Module(Name, [Description], IsForm, IsReport, IsCatalogue)
	VALUES(@Name, @Description, @IsForm, @IsReport, @IsCatalogue)
	
	SET @Id = @@IDENTITY
End
GO
----------Read---------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleRead]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [License].[ModuleRead]
GO
CREATE PROCEDURE [License].[ModuleRead]
(
	@Id  Numeric(10,0)
)
As
Begin
	SELECT Id, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Module
	WHERE Id = @Id
End
GO
----------ReadAll---------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleReadAll]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [License].[ModuleReadAll]
GO
CREATE PROCEDURE [License].[ModuleReadAll]
As
Begin
	SELECT Id, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Module
End
GO
----------Update---------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleUpdate]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [License].[ModuleUpdate]
GO
CREATE PROCEDURE [License].[ModuleUpdate]
(
	@Id  Numeric(10,0),
	@Name Varchar(50),
	@Description Varchar(50),
	@IsForm Bit,
	@IsReport Bit,
	@IsCatalogue Bit
)
As
Begin
	UPDATE License.Module
	SET Name = @Name,
		[Description] = @Description,
		IsForm = @IsForm,
		IsReport = @IsReport,
		IsCatalogue = @IsCatalogue
	WHERE Id = @Id
End
GO
----------Delete---------
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[License].[ModuleDelete]') AND type in (N'P', N'PC'))
	DROP PROCEDURE [License].[ModuleDelete]
GO
CREATE PROCEDURE [License].[ModuleDelete]
(
	@Id  Numeric(10,0)
)
As
Begin
	DELETE FROM License.Module
	WHERE Id = @Id
End
GO