USE [master]
GO
/****** Object:  Database [AutoTourism]    Script Date: 05/09/2015 17:09:54 ******/
CREATE DATABASE [AutoTourism] ON  PRIMARY 
( NAME = N'AutoTourism', FILENAME = N'D:\Arpan\Personal\Splash\DB\AutoTourism.mdf' , SIZE = 12288KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'AutoTourism_log', FILENAME = N'D:\Arpan\Personal\Splash\DB\AutoTourism.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [AutoTourism] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [AutoTourism].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [AutoTourism] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [AutoTourism] SET ANSI_NULLS OFF
GO
ALTER DATABASE [AutoTourism] SET ANSI_PADDING OFF
GO
ALTER DATABASE [AutoTourism] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [AutoTourism] SET ARITHABORT OFF
GO
ALTER DATABASE [AutoTourism] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [AutoTourism] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [AutoTourism] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [AutoTourism] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [AutoTourism] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [AutoTourism] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [AutoTourism] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [AutoTourism] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [AutoTourism] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [AutoTourism] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [AutoTourism] SET  DISABLE_BROKER
GO
ALTER DATABASE [AutoTourism] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [AutoTourism] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [AutoTourism] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [AutoTourism] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [AutoTourism] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [AutoTourism] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [AutoTourism] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [AutoTourism] SET  READ_WRITE
GO
ALTER DATABASE [AutoTourism] SET RECOVERY SIMPLE
GO
ALTER DATABASE [AutoTourism] SET  MULTI_USER
GO
ALTER DATABASE [AutoTourism] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [AutoTourism] SET DB_CHAINING OFF
GO
USE [AutoTourism]
GO
/****** Object:  User [AppUser]    Script Date: 05/09/2015 17:09:54 ******/
CREATE USER [AppUser] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Schema [Utility]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Utility] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Reservation]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Reservation] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Report]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Report] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Organization]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Organization] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Navigator]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Navigator] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Lodge]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Lodge] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [License]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [License] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Invoice]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Invoice] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Guardian]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Guardian] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Customer]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Customer] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Configuration]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Configuration] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [BinAff]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [BinAff] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [AutoTourism]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [AutoTourism] AUTHORIZATION [dbo]
GO
/****** Object:  Schema [Accountant]    Script Date: 05/09/2015 17:09:54 ******/
CREATE SCHEMA [Accountant] AUTHORIZATION [dbo]
GO
/****** Object:  Table [Guardian].[UserRule]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[UserRule](
	[DefaultPassword] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Reservation].[StatusUpdate]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Reservation].[StatusUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Reservation].[Status]
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Reservation].[StatusReadAll]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Reservation].[StatusReadAll]	
AS
BEGIN
	
	SELECT Id, Name
	FROM Reservation.Status WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusRead]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Reservation].[StatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Reservation.Status WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Reservation].[StatusInsert]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Reservation].[StatusInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Reservation].Status([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Reservation].[StatusDelete]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Reservation].[StatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Reservation].[Status]
	WHERE Id = @Id   
   
END
GO
/****** Object:  Table [BinAff].[Stamp]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BinAff].[Stamp](
	[ProductId] [varchar](max) NOT NULL,
	[ProductName] [varchar](max) NOT NULL,
	[FingurePrint] [varchar](max) NOT NULL,
	[LicenseDate] [varchar](max) NOT NULL,
	[RegistrationDate] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Function [dbo].[Split](@Text Text, @Delimitor Char(1)) 
RETURNS
@Table TABLE
(
    [Index] int Identity(0,1),
    [SplitText] varchar(20)
)
AS

BEGIN
    DECLARE @Current varchar(20)
    DECLARE @EndIndex int
    DECLARE @TextLength int
    DECLARE @StartIndex int
       
    SET @StartIndex = 1
       
    IF(@Text IS NOT NULL)
    BEGIN
        SET @TextLength = DataLength(@Text)
              
        WHILE(1 = 1)
        BEGIN
            SET @EndIndex = CharIndex(@Delimitor, @Text, @StartIndex) 
            IF(@EndIndex != 0)
            BEGIN
                SET @Current = SubString(@Text, @StartIndex, @EndIndex - @StartIndex)
                INSERT INTO @table ([SplitText]) VALUES(@Current)
                SET @StartIndex = @EndIndex + 1   
            END
            ELSE
            BEGIN
                SET @Current = substring(@Text, @StartIndex, DataLength(@Text) - @StartIndex + 1)
                INSERT INTO @table ([SplitText]) VALUES(@Current)
                BREAK
            END
        END 
    END
       
    RETURN
END
GO
/****** Object:  Table [Guardian].[SecurityQuestion]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[SecurityQuestion](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Question] [varchar](155) NULL,
 CONSTRAINT [PK_SecurityQuestion] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Navigator].[Rule]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Navigator].[Rule](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ModuleSeperator] [char](1) NOT NULL,
	[PathSeperator] [char](1) NOT NULL,
 CONSTRAINT [PK_Rule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Customer].[Rule]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customer].[Rule](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[IsPinNo] [bit] NULL,
	[IsAlternateContactNo] [bit] NULL,
	[IsEmail] [bit] NULL,
	[IsIdentityProof] [bit] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Configuration].[Rule]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuration].[Rule](
	[DateFormat] [varchar](50) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomStatus]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[RoomStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Lodge].[TaxationReadAll]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[TaxationReadAll]
AS
BEGIN
	
	SELECT 
		Id,		
		[Name],
		[Amount],
		[IsPercentage]
	FROM [Invoice].Taxation WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Lodge].[TaxationRead]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[TaxationRead]
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
	FROM [Invoice].Taxation WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  Table [Accountant].[Tax]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[Tax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Amount] [money] NOT NULL,
	[IsPercentage] [bit] NOT NULL,
 CONSTRAINT [PK_Taxation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Organization].[UnitStatus]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organization].[UnitStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BuildingStatus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Organization].[UnitType]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organization].[UnitType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_BuildingType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuration].[IdentityProofType]    Script Date: 05/09/2015 17:09:56 ******/
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
/****** Object:  Table [Utility].[Importance]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Utility].[Importance](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Importance] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuration].[Initial]    Script Date: 05/09/2015 17:09:56 ******/
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
/****** Object:  Table [Accountant].[Invoice]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[Invoice](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[SerialNumber] [int] NOT NULL,
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
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [BinAff].[DateStamp]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [BinAff].[DateStamp](
	[Stamp] [varchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Configuration].[Country]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuration].[Country](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Country] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [License].[Credential]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [License].[Credential](
	[LicenseNo] [varchar](max) NOT NULL,
	[LicenseDate] [date] NOT NULL,
	[AuthToken] [varbinary](50) NOT NULL,
	[FingurePrint] [varchar](max) NOT NULL,
	[InstallationDate] [date] NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [License].[Component]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [License].[Component](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Code] [char](4) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsForm] [bit] NULL,
	[IsCatalogue] [bit] NULL,
	[IsReport] [bit] NULL,
 CONSTRAINT [PK_Module] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CleanUpSchema]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************
 COPYRIGHTS http://www.ranjithk.com
*********************************************************/  
CREATE PROCEDURE [dbo].[CleanUpSchema]
(
  @SchemaName varchar(100)
 ,@WorkTest char(1) = 'w'  -- use 'w' to work and 't' to print
)
AS
/*-----------------------------------------------------------------------------------------
  
  Author : Ranjith Kumar S
  Date:    31/01/10
  
  Description: It drop all the objects in a schema and then the schema itself
  
  Limitations:
   
    1. If a table has a PK with XML or a Spatial Index then it wont work 
       (workaround: drop that table manually and re run it)
    2. If the schema is referred by a XML Schema collection then it wont work

If it is helpful, Please send your comments ranjith_842@hotmail.com or visit http://www.ranjithk.com
 
-------------------------------------------------------------------------------------------*/
BEGIN    

declare @SQL varchar(4000)
declare @msg varchar(500)
 
IF OBJECT_ID('tempdb..#dropcode') IS NOT NULL DROP TABLE #dropcode
CREATE TABLE #dropcode
(
   ID int identity(1,1)
  ,SQLstatement varchar(1000) 
 )

-- removes all the foreign keys that reference a PK in the target schema
 SELECT @SQL = 
  'select 
       '' ALTER TABLE ''+SCHEMA_NAME(fk.schema_id)+''.''+OBJECT_NAME(fk.parent_object_id)+'' DROP CONSTRAINT ''+ fk.name
  FROM sys.foreign_keys fk
  join sys.tables t on t.object_id = fk.referenced_object_id
  where t.schema_id = schema_id(''' + @SchemaName+''')
    and fk.schema_id <> t.schema_id 
  order by fk.name desc'
 
 IF @WorkTest = 't' PRINT (@SQL )
 INSERT INTO #dropcode
 EXEC (@SQL)
   
 -- drop all default constraints, check constraints and Foreign Keys
 SELECT @SQL = 
 'SELECT 
       '' ALTER TABLE ''+schema_name(t.schema_id)+''.''+OBJECT_NAME(fk.parent_object_id)+'' DROP CONSTRAINT ''+ fk.[Name]
  FROM sys.objects fk
  join sys.tables t on t.object_id = fk.parent_object_id
  where t.schema_id = schema_id(''' + @SchemaName+''')
   and fk.type IN (''D'', ''C'', ''F'')'
   
 IF @WorkTest = 't' PRINT (@SQL )
 INSERT INTO #dropcode
 EXEC (@SQL)
  
 -- drop all other objects in order    
 SELECT @SQL =   
 'SELECT 
      CASE WHEN SO.type=''PK'' THEN '' ALTER TABLE ''+SCHEMA_NAME(SO.schema_id)+''.''+OBJECT_NAME(SO.parent_object_id)+'' DROP CONSTRAINT ''+ SO.name
           WHEN SO.type=''U'' THEN '' DROP TABLE ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
           WHEN SO.type=''V'' THEN '' DROP VIEW  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
           WHEN SO.type=''P'' THEN '' DROP PROCEDURE  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]          
           WHEN SO.type=''TR'' THEN ''  DROP TRIGGER  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
           WHEN SO.type  IN (''FN'', ''TF'',''IF'',''FS'',''FT'') THEN '' DROP FUNCTION  ''+SCHEMA_NAME(SO.schema_id)+''.''+ SO.[Name]
       END
FROM sys.objects SO
WHERE SO.schema_id = schema_id('''+ @SchemaName +''')
  AND SO.type IN (''PK'', ''FN'', ''TF'', ''TR'', ''V'', ''U'', ''P'')
ORDER BY CASE WHEN type = ''PK'' THEN 1 
              WHEN type in (''FN'', ''TF'', ''P'',''IF'',''FS'',''FT'') THEN 2
              WHEN type = ''TR'' THEN 3
              WHEN type = ''V'' THEN 4
              WHEN type = ''U'' THEN 5
            ELSE 6 
          END'

IF @WorkTest = 't' PRINT (@SQL )
INSERT INTO #dropcode
EXEC (@SQL)
  
DECLARE @ID int, @statement varchar(1000)
DECLARE statement_cursor CURSOR
FOR SELECT SQLstatement
      FROM #dropcode
  ORDER BY ID ASC
     
 OPEN statement_cursor
 FETCH statement_cursor INTO @statement 
 WHILE (@@FETCH_STATUS = 0)
 BEGIN
 
 IF @WorkTest = 't' PRINT (@statement)
 ELSE
  BEGIN
    PRINT (@statement)
    EXEC(@statement) 
  END
   
 FETCH statement_cursor INTO @statement     
END
  
CLOSE statement_cursor
DEALLOCATE statement_cursor
  
IF @WorkTest = 't' PRINT ('DROP SCHEMA '+@SchemaName)
ELSE
 BEGIN
   PRINT ('DROP SCHEMA '+@SchemaName)
   EXEC ('DROP SCHEMA '+@SchemaName)
 END  
 
PRINT '------- ALL - DONE -------'    
END
GO
/****** Object:  Table [Report].[Category]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Report].[Category](
	[Id] [numeric](10, 0) NOT NULL,
	[Extension] [varchar](15) NULL,
	[Name] [varchar](63) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Utility].[AppointmentType]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Utility].[AppointmentType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_AppointmentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Guardian].[Account]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[Account](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[LoginId] [varchar](63) NOT NULL,
	[Password] [varchar](31) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Customer].[ActionStatus]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Customer].[ActionStatus](
	[Id] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Status] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Navigator].[ArtifactAttachmentLink]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navigator].[ArtifactAttachmentLink](
	[Id] [numeric](10, 0) NOT NULL,
	[AttachmentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_ArtifactAttachment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC,
	[AttachmentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkRead]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkRead]
(
	@InvoiceId Numeric(10,0)
)
As
BEGIN

	SELECT [InvoiceId],[TaxationId]
	FROM [Invoice].InvoiceTaxationLink WITH (NOLOCK)
	WHERE InvoiceId = @InvoiceId
	
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkInsert]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkInsert]
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
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationLinkDelete]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoiceTaxationLinkDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].InvoiceTaxationLink
	WHERE InvoiceId = @Id   
   
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationRead]    Script Date: 05/09/2015 17:09:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoiceTaxationRead]
(
	@InvoiceId Numeric(10,0)
)
As
BEGIN

	SELECT  
		[TaxName],
		[TaxAmount],
		[IsPercentage],
		[InvoiceId]
	FROM [Invoice].InvoiceTaxation WITH (NOLOCK)
	WHERE InvoiceId = @InvoiceId
	
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoiceTaxationInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoiceTaxationInsert]
(  	
	@InvoiceId Numeric(10,0),
	@TaxName Varchar(50),	
	@TaxAmount money,	
	@IsPercentage Bit,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Invoice].[InvoiceTaxation]([TaxName],[TaxAmount],[IsPercentage],[InvoiceId])
	VALUES(@TaxName,@TaxAmount,@IsPercentage,@InvoiceId)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  Table [Organization].[Organization]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organization].[Organization](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Logo] [varbinary](max) NULL,
	[LicenceNumber] [varchar](50) NULL,
	[ServiceTaxNumber] [varchar](50) NULL,
	[LuxuaryTaxNumber] [varchar](50) NULL,
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
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoicePaymentLinkRead]
(
	@InvoiceId Numeric(10,0)
)
As
BEGIN

	SELECT  [InvoiceId],[PaymentId]
	FROM [Invoice].InvoicePaymentLink WITH (NOLOCK)
	WHERE InvoiceId = @InvoiceId

END
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoicePaymentLinkInsert]
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
END
GO
/****** Object:  StoredProcedure [Invoice].[InvoicePaymentLinkDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InvoicePaymentLinkDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Invoice].InvoicePaymentLink
	WHERE InvoiceId = @Id   
   
END
GO
/****** Object:  Table [Accountant].[InvoiceReport]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountant].[InvoiceReport](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ReportCategoryId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Report] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [License].[Module]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [License].[Module](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Code] [char](4) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NULL,
	[IsMandatory] [bit] NULL,
 CONSTRAINT [PK_Module_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[EmailReadForParent]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmailReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, Email
	FROM OrganizationEmail WITH (NOLOCK)
	WHERE OrganizationId = @ParentId   
	
END
GO
/****** Object:  StoredProcedure [dbo].[EmailRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EmailRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, Email
	FROM OrganizationEmail WITH (NOLOCK)
	WHERE OrganizationId = @Id   
	
END
GO
/****** Object:  StoredProcedure [dbo].[EmailInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[EmailInsert]
(  
	@Email Varchar(50),
	@OrganizationId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO OrganizationEmail([Email],[OrganizationId])
	VALUES(@Email,@OrganizationId)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  Table [Accountant].[PaymentType]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[PaymentType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_InvoicePaymentType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Invoice].[PaymentReadIdFromArtifact]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[PaymentReadIdFromArtifact]
( 
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	SELECT PaymentId
	FROM Invoice.PaymentArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId

END
GO
/****** Object:  Table [Customer].[Report]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customer].[Report](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NULL,
	[ReportCategoryId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Report_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Invoice].[InsertInvoiceReportForArtifact]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[InsertInvoiceReportForArtifact]
(
        @ReportId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO [Invoice].ReportArtifact([ReportId],[ArtifactId],[Category])
        VALUES(@ReportId, @ArtifactId, @Category)
 
END
GO
/****** Object:  Table [Guardian].[Role]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[Role](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](63) NULL,
	[Description] [varchar](255) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Invoice].[ReadArtifactForInvoiceNumber]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Invoice].[ReadArtifactForInvoiceNumber] 
(
	@InvoiceNumber Varchar(50)
)
AS
BEGIN

	SELECT ArtifactId
	FROM [Invoice].Artifact WITH (NOLOCK)
	WHERE InvoiceId = (SELECT ID 
		FROM Invoice.Invoice WITH (NOLOCK)
		WHERE InvoiceNumber = @InvoiceNumber)

END
GO
/****** Object:  Table [Lodge].[RoomCategory]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[RoomCategory](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_RoomCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomType]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[RoomType](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Accomodation] [smallint] NOT NULL,
	[ExtraAccomodation] [smallint] NOT NULL,
 CONSTRAINT [PK_RoomType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomReservation]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[RoomReservation](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[BookingFrom] [datetime] NOT NULL,
	[NoOfDays] [numeric](3, 0) NOT NULL,
	[NoOfMale] [tinyint] NULL,
	[NoOfFemale] [tinyint] NULL,
	[NoOfChild] [tinyint] NULL,
	[NoOfInfant] [tinyint] NOT NULL,
	[NoOfRooms] [tinyint] NOT NULL,
	[RoomCategoryId] [numeric](10, 0) NULL,
	[RoomTypeId] [numeric](10, 0) NULL,
	[AcRoomPreference] [int] NULL,
	[Remark] [varchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[IsCheckedIn] [bit] NOT NULL,
 CONSTRAINT [PK_RoomReservation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomTariff]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lodge].[RoomTariff](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CategoryId] [numeric](10, 0) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[IsAirConditioned] [bit] NOT NULL,
	[StartDate] [datetime] NOT NULL,
	[EndDate] [datetime] NOT NULL,
	[Rate] [money] NOT NULL,
 CONSTRAINT [PK_RoomTariff] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Lodge].RoomStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomStatusDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [Lodge].[RoomStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].RoomStatus
	WHERE Id = @Id      
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationStatusReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationStatusRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
		
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomCategoryUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].RoomCategory
		SET	
			[Name] = @Name
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomCategoryReadAll]
As
BEGIN

	SELECT Id,Name
	FROM [Lodge].RoomCategory WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomCategoryRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM [Lodge].RoomCategory WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Lodge].[RoomCategoryInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomCategory([Name])
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Lodge].[RoomCategoryDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [Lodge].[RoomCategoryDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomCategory
		WHERE Id = @Id      
	END
GO
/****** Object:  StoredProcedure [Guardian].[RoleReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[RoleReadAll]
AS
BEGIN

	SELECT Id, Name, Description
	FROM Guardian.Role WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[RoleRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT Id, Name, [Description]
	FROM  Guardian.[Role] WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Guardian].[RoleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[RoleInsert]
(
	@Name Varchar(63),
	@Description Varchar(255),
	@Id Numeric(10,0) OUT
)
AS
BEGIN
	INSERT INTO Guardian.[Role](Name, [Description])
	VALUES(@Name, @Description)
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Customer].[ReportInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Customer].[ReportInsert]
(  
	@Date DateTime,	
	@CategoryId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Customer].Report([Date],[ReportCategoryId])
	VALUES(@Date,@CategoryId)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceUpdate]
(
	@Id Numeric(10,0),
	@Date DateTime,
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
	
	UPDATE Accountant.Invoice
	SET	
		[Date] = @Date,
		Advance = @Advance,
		Discount = @Discount,
		SellerName = @SellerName,
		SellerAddress = @SellerAddress,
		SellerContactNo = @SellerContactNo,
		SellerEmail = @SellerEmail,
		SellerLicence = @SellerLicence,
		BuyerName = @BuyerName,
		BuyerAddress = @BuyerAddress,
		BuyerContactNo = @BuyerContactNo,
		BuyerEmail = @BuyerEmail
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[PaymentTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Accountant.PaymentType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[PaymentTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN

	SELECT Id	
	FROM Accountant.PaymentType WITH (NOLOCK)
	WHERE Name = @Name
				
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[PaymentTypeReadAll]
AS
BEGIN
	
	SELECT Id, [Name]
	FROM Accountant.PaymentType WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[PaymentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Name]
	FROM Accountant.PaymentType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[PaymentTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  Accountant.PaymentType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentTypeDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[PaymentTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.PaymentType
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Customer].[ReportReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ReportReadAll]
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId		
	FROM Customer.Report WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Customer].[ReportRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId
	FROM Customer.Report WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  Table [Guardian].[Profile]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[Profile](
	[UserId] [numeric](10, 0) NOT NULL,
	[Initial] [numeric](10, 0) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NOT NULL,
	[Dob] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Accountant].[Payment]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountant].[Payment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[SerialNumber] [smallint] NOT NULL,
	[Date] [datetime] NOT NULL,
	[InvoiceId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Payment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Organization].[OrganizationUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[OrganizationUpdate]
(
@Id Numeric(10,0),
@Name Varchar(50),
@Logo Varbinary(max) = null,
@LicenceNumber Varchar(50) = null,
@Tan Varchar(50) = null,
@ServiceTaxNumber Varchar(50) = null,
@LuxuaryTaxNumber Varchar(50) = null,
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
[ServiceTaxNumber] = @ServiceTaxNumber,
[LuxuaryTaxNumber] = @LuxuaryTaxNumber,
[Address] = @Address,
[City] = @City,
[StateId] = @StateId,
[Pin] = @Pin,
[ContactName] = @ContactName
WHERE Id = @Id

END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrganizationUpdate]
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
	
	UPDATE Organization.Organization
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
GO
/****** Object:  StoredProcedure [Organization].[OrganizationRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[OrganizationRead]
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
		[ServiceTaxNumber],
		[LuxuaryTaxNumber],
		[Address],
		[City],
		[StateId],
		[Pin],
		[ContactName]
	FROM [Organization].[Organization] WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE [dbo].[Organization](
--	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
--	[Name] [varchar](50) NOT NULL,
--	[Logo] [varbinary](max) NULL,
--	[LicenceNumber] [varchar](50) NULL,
--	[Tan] [varchar](50) NULL,
--	[Address] [varchar](255) NULL,
--	[City] [varchar](50) NULL,
--	[StateId] [numeric](10, 0) NULL,
--	[Pin] [int] NULL,
--	[ContactName] [varchar](50) NULL,
-- )

CREATE PROCEDURE [dbo].[OrganizationRead] 
(
	@Id Numeric(10,0) = null
)
AS
BEGIN
	
	if(ISNULL(@Id,0) = 0)
		BEGIN
			SELECT TOP 1 Id, Name, Logo, LicenceNumber, Tan, Address,
				City, StateId, Pin, ContactName
			FROM Organization.Organization WITH (NOLOCK)
		END
	Else
		BEGIN	
			SELECT TOP 1 Id, Name, Logo, LicenceNumber, Tan, Address,
				City, StateId, Pin, ContactName
			FROM Organization.Organization WITH (NOLOCK)
			WHERE Id = @Id   
		END
	
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[OrganizationInsert]
(
@Name Varchar(50),
@Logo Varbinary(max) = null,
@LicenceNumber Varchar(50) = null,
@Tan Varchar(50) = null,
@ServiceTaxNumber Varchar(50) = null,
@LuxuaryTaxNumber Varchar(50) = null,
@Address Varchar(255) = null,
@City Varchar(50) = null,
@StateId Numeric(10,0) = null,
@Pin Int = null,
@ContactName Varchar(50) = null,
@Id Numeric(10,0) OUTPUT
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
[ServiceTaxNumber] = @ServiceTaxNumber,
[LuxuaryTaxNumber] = @LuxuaryTaxNumber,
[Address] = @Address,
[City] = @City,
[StateId] = @StateId,
[Pin] = @Pin,
[ContactName] = @ContactName
End
Else
Begin
INSERT INTO [Organization].Organization([Name],[Logo],[LicenceNumber],[Tan],[ServiceTaxNumber],[LuxuaryTaxNumber],[Address],[City],[StateId],[Pin],[ContactName])
VALUES(@Name,@Logo,@LicenceNumber,@Tan,@ServiceTaxNumber,@LuxuaryTaxNumber,@Address,@City,@StateId,@Pin,@ContactName)

End

SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[OrganizationInsert]
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
	
	INSERT INTO Organization.Organization([Name],[Logo],[LicenceNumber],[Tan],[Address],[City],[StateId],[Pin],[ContactName])
	VALUES(@Name,@Logo,@LicenceNumber,@Tan,@Address,@City,@StateId,@Pin,@ContactName)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Organization].[OrganizationDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Organization].[OrganizationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].Organization
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadForSerialNumber]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReadForSerialNumber]
(
	@SerialNumber Int,
	@Date Date
)
AS
BEGIN
	
	SELECT Id
	FROM Accountant.Invoice WITH (NOLOCK)
	WHERE SerialNumber = @SerialNumber
		AND Date = @Date
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReadDuplicate]
(
	@SerialNumber int		
)
AS
BEGIN

	SELECT Id
	FROM Accountant.Invoice WITH (NOLOCK)
	WHERE SerialNumber = @SerialNumber
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReadAll]
AS
BEGIN
	
	SELECT 
		Id, [Date], SerialNumber, Advance, Discount,
		SellerName, SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail
	FROM Accountant.Invoice WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN	
	
	SELECT 
		Id, [Date], SerialNumber, Advance, Discount,
		SellerName, SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail		
	FROM Accountant.Invoice WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [License].[ModuleUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ModuleUpdate]
(
	@Id  Numeric(10,0),
	@Code Varchar(50),
	@Name Varchar(50),
	@Description Varchar(50),
	@IsMandatory Bit
)
As
Begin
	UPDATE License.Module
	SET Code = @Code,
		Name = @Name,
		[Description] = @Description,
		IsMandatory = @IsMandatory
	WHERE Id = @Id
End
GO
/****** Object:  StoredProcedure [License].[ModuleReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ModuleReadAll]
As
BEGIN

	SELECT Id, Code, Name, [Description], IsMandatory
	FROM License.Module WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [License].[ModuleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ModuleRead]
(
	@Id  Numeric(10,0)
)
As
BEGIN

	SELECT Id, Code, Name, [Description], IsMandatory
	FROM License.Module WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [License].[ModuleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ModuleInsert]
(
	@Name Varchar(50),
	@Code Varchar(50),
	@Description Varchar(50),
	@IsMandatory Bit,
	@Id  Numeric(10,0) OUTPUT
)
As
Begin
	INSERT INTO License.Module(Code, Name, [Description], IsMandatory)
	VALUES(@Code, @Name, @Description, @IsMandatory)
	
	SET @Id = @@IDENTITY
End
GO
/****** Object:  StoredProcedure [License].[ModuleDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
/****** Object:  Table [Accountant].[InvoiceTax]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[InvoiceTax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](50) NULL,
	[TaxAmount] [money] NULL,
	[IsPercentage] [bit] NULL,
	[InvoiceId] [numeric](10, 0) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReportReadAll]
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId	
	FROM Accountant.InvoiceReport WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReportRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Date], ReportCategoryId
	FROM Accountant.InvoiceReport WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReportInsert]
(  
	@Date DateTime,	
	@CategoryId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Accountant.InvoiceReport([Date], ReportCategoryId)
	VALUES(@Date, @CategoryId)
   
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  Table [Guardian].[LoginHistory]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guardian].[LoginHistory](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[AccountId] [numeric](10, 0) NOT NULL,
	[LoginStamp] [datetime] NULL,
	[LogoutStamp] [datetime] NULL,
 CONSTRAINT [PK_LoginLogoutHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Organization].[IsStateIdDeletable]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[IsStateIdDeletable]
(
	@StateId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  Name
	FROM [Organization].Organization
	WHERE StateId = @StateId

 END
GO
/****** Object:  Table [Navigator].[Artifact]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Navigator].[Artifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[FileName] [varchar](50) NOT NULL,
	[Extension] [varchar](5) NULL,
	[Path] [varchar](max) NULL,
	[Style] [numeric](2, 0) NOT NULL,
	[Version] [numeric](4, 0) NOT NULL,
	[ParentId] [numeric](10, 0) NULL,
	[CreatedByUserId] [numeric](10, 0) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[ModifiedByUserId] [numeric](10, 0) NULL,
	[ModifiedAt] [datetime] NULL,
 CONSTRAINT [PK_Artifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 - Directory, 2 - File' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'TABLE',@level1name=N'Artifact', @level2type=N'COLUMN',@level2name=N'Style'
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactAttachmentLinkRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, AttachmentId
	FROM Navigator.ArtifactAttachmentLink WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactAttachmentLinkInsert]
(
	@Id Numeric(10,0),
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	INSERT INTO Navigator.ArtifactAttachmentLink(Id,AttachmentId)
	VALUES(@Id, @AttachmentId)
 
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactAttachmentLinkDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactAttachmentLinkDelete]
(
	@Id Numeric(10,0),
	@AttachmentId Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Navigator.ArtifactAttachmentLink
	WHERE AttachmentId = @AttachmentId
		AND Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Utility.AppointmentType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Utility].[AppointmentTypeReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN
	SELECT Id	
	FROM Utility.AppointmentType
	WHERE Name = @Name				
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentTypeReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.AppointmentType WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.AppointmentType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Utility].[AppointmentTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Utility.AppointmentType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Utility].[AppointmentTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.AppointmentType
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountInsert]
(  
   @LoginId Varchar(15),   
   @Password Varchar(127),
   --@RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
   INSERT INTO Guardian.Account(LoginId, [Password])
   VALUES (@LoginId, @Password)   
   SET @Id = @@IDENTITY   
   --INSERT INTO User_Role (UserId, RoleId)
   --VALUES(@Id, @RoleId)
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountDelete]
(
   @Id Numeric(10,0)
)
AS
BEGIN
   DELETE FROM Guardian.Account
   WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdatePassword]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountUpdatePassword]
(
	@Id Numeric(10,0),
	@Password Varchar(50)
)
AS
BEGIN
	
	UPDATE Guardian.Account
	SET	
		[Password] = @Password	
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdateLoginId]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountUpdateLoginId]
(
   @Id Numeric(10,0),
   @LoginId Varchar(15)
)
AS
BEGIN	
	UPDATE Guardian.Account
	SET	
		LoginId = @LoginId
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountUpdate]
(
   @Id Numeric(10,0),
   @LoginId Varchar(15),
   @Password Varchar(127)
   --@RoleId Numeric(10,0)
)
AS
BEGIN	
	UPDATE Guardian.Account
	SET	
		LoginId = @LoginId,
		[Password] = @Password	
	WHERE Id = @Id
	--UPDATE User_Role
	--SET
	--	RoleId	= @RoleId
	--WHERE UserId = @Id   
END
GO
/****** Object:  Table [Utility].[Appointment]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Utility].[Appointment](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ActorId] [numeric](10, 0) NOT NULL,
	[Title] [varchar](50) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[Start] [datetime] NOT NULL,
	[End] [datetime] NOT NULL,
	[Location] [varchar](50) NOT NULL,
	[Description] [varchar](250) NOT NULL,
	[ImportanceId] [numeric](10, 0) NULL,
	[Reminder] [datetime] NULL,
 CONSTRAINT [PK_Appointment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ActionStatusUpdate]
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
   
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ActionStatusReadAll]	
AS
BEGIN
	
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ActionStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Customer.ActionStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ActionStatusInsert]
(  
	@Name Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Customer].ActionStatus([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Customer].[ActionStatusDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ActionStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM [Customer].[ActionStatus]
	WHERE Id = @Id   
   
END
GO
/****** Object:  Table [Lodge].[Building]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[Building](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Building] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Configuration].[CountryReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[CountryReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.Country WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Configuration].[CountryRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[CountryRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, Name
   FROM Configuration.Country WITH (NOLOCK)
   WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Report].[CategoryReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Report].[CategoryReadAll]
AS
BEGIN
	
	SELECT Id, Extension, Name
	FROM Report.Category WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Report].[CategoryRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Report].[CategoryRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id
		,Extension
		,Name
	FROM Report.Category WITH (NOLOCK)
	WHERE Id = @Id
   
END
GO
/****** Object:  Table [Organization].[ContactNumber]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organization].[ContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_ContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [License].[ComponentUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ComponentUpdate]
(
	@Id  Numeric(10,0),
	@Code Varchar(50),
	@Name Varchar(50),
	@Description Varchar(50),
	@IsForm Bit,
	@IsReport Bit,
	@IsCatalogue Bit
)
As
Begin
	UPDATE License.Component
	SET Code = @Code,
		Name = @Name,
		[Description] = @Description,
		IsForm = @IsForm,
		IsReport = @IsReport,
		IsCatalogue = @IsCatalogue
	WHERE Id = @Id
End
GO
/****** Object:  StoredProcedure [License].[ComponentReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ComponentReadAll]
As
BEGIN

	SELECT Id, Code, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Component WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [License].[ComponentRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ComponentRead]
(
	@Id  Numeric(10,0)
)
As
BEGIN

	SELECT Id, Code, Name, [Description], IsForm, IsReport, IsCatalogue
	FROM License.Component WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [License].[ComponentInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ComponentInsert]
(
	@Name Varchar(50),
	@Code Varchar(50),
	@Description Varchar(50),
	@IsForm Bit,
	@IsReport Bit,
	@IsCatalogue Bit,
	@Id  Numeric(10,0) OUTPUT
)
As
Begin
	INSERT INTO License.Component(Code, Name, [Description], IsForm, IsReport, IsCatalogue)
	VALUES(@Code, @Name, @Description, @IsForm, @IsReport, @IsCatalogue)
	
	SET @Id = @@IDENTITY
End
GO
/****** Object:  StoredProcedure [License].[ComponentDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [License].[ComponentDelete]
(
	@Id  Numeric(10,0)
)
As
Begin
	DELETE FROM License.Component
	WHERE Id = @Id
End
GO
/****** Object:  StoredProcedure [Configuration].[InitialUpdate]    Script Date: 05/09/2015 17:09:57 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
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
	FROM Configuration.Initial WITH (NOLOCK)
	WHERE Name = @Name
					
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[InitialReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.Initial WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialRead]    Script Date: 05/09/2015 17:09:57 ******/
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
	
	SELECT Id, Name
	FROM Configuration.Initial WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Configuration].[InitialInsert]    Script Date: 05/09/2015 17:09:57 ******/
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
/****** Object:  StoredProcedure [Configuration].[InitialDelete]    Script Date: 05/09/2015 17:09:57 ******/
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
/****** Object:  StoredProcedure [Utility].[ImportanceUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[ImportanceUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Utility.Importance
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[ImportanceReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN
	SELECT Id	
	FROM Utility.Importance
	WHERE Name = @Name				
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[ImportanceReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.Importance WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[ImportanceRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Utility.Importance WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[ImportanceInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Utility.Importance([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[ImportanceDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.Importance
	WHERE Id = @Id   
   
END
GO
/****** Object:  Table [Accountant].[InvoiceLineItem]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[InvoiceLineItem](
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
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceInsert]
(  
	@Date DateTime,
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
	
	BEGIN TRANSACTION
	
	DECLARE @Max Int
	SELECT @Max = MAX(SerialNumber) + 1 FROM Invoice.Invoice WHERE Date = @Date
	IF @Max IS Null SET @Max = 1
	INSERT INTO Accountant.Invoice([Date], SerialNumber, Advance, Discount,
		SellerName,  SellerAddress, SellerContactNo, SellerEmail, SellerLicence,
		BuyerName, BuyerAddress, BuyerContactNo, BuyerEmail)
	VALUES(@Date, @Max, @Advance, @Discount,
		@SellerName, @SellerAddress, @SellerContactNo, @SellerEmail, @SellerLicence,
		@BuyerName, @BuyerAddress, @BuyerContactNo, @BuyerEmail)
    
    COMMIT TRANSACTION
    
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.Invoice
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeUpdate]    Script Date: 05/09/2015 17:09:57 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
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
	FROM Configuration.IdentityProofType WITH (NOLOCK)
	WHERE Name = @Name
				
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[IdentityProofTypeReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.IdentityProofType WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeRead]    Script Date: 05/09/2015 17:09:57 ******/
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
	
	SELECT Id, Name
	FROM Configuration.IdentityProofType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeInsert]    Script Date: 05/09/2015 17:09:57 ******/
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
/****** Object:  StoredProcedure [Configuration].[IdentityProofTypeDelete]    Script Date: 05/09/2015 17:09:57 ******/
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
	
	DELETE FROM [Configuration].IdentityProofType
	WHERE Id = @Id   
   
END
GO
/****** Object:  Table [Organization].[Email]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [Organization].[Email](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Organization].[Fax]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organization].[Fax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Fax] [varchar](50) NOT NULL,
	[OrganizationId] [numeric](10, 0) NULL,
 CONSTRAINT [PK_Fax] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitStatusUpdate]
(	
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Organization.UnitStatus
	SET	
		Name = @Name
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitStatusReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Organization.UnitStatus WITH (NOLOCK)
	
End
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitStatusRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Organization.UnitStatus WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitStatusInsert]
(  
	@Name Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.UnitStatus(Name)
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitStatusDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [Organization].[UnitStatusDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM Organization.UnitStatus
	WHERE Id = @Id
	
END
GO
/****** Object:  Table [Guardian].[UserRole]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Guardian].[UserRole](
	[UserId] [numeric](10, 0) NOT NULL,
	[RoleId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_UserRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitTypeUpdate]
	(	
		@Id Numeric(10,0),
		@Name Varchar(50)
	)
	AS
	BEGIN
		
		UPDATE Organization.UnitType
		SET	
			Name = @Name
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitTypeReadAll]
As
BEGIN

	SELECT Id,Name
	FROM Organization.UnitType WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name
	FROM Organization.UnitType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitTypeInsert]
	(  
		@Name Varchar(50),	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN
		
		INSERT INTO Organization.UnitType(Name)
		VALUES(@Name)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Organization].[UnitTypeDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [Organization].[UnitTypeDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM Organization.UnitType
		WHERE Id = @Id      
	END
GO
/****** Object:  Table [Accountant].[TaxSlab]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountant].[TaxSlab](
	[TaxId] [numeric](10, 0) NOT NULL,
	[Limit] [numeric](10, 0) NOT NULL,
	[Amount] [numeric](4, 2) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
 CONSTRAINT [PK_TaxDetails] PRIMARY KEY CLUSTERED 
(
	[TaxId] ASC,
	[Limit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Accountant].[TaxReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[TaxReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM Accountant.Tax WITH (NOLOCK)
	WHERE Name = @Name
				
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[TaxReadAll]
AS
BEGIN
	
	SELECT Id, Name, Amount, IsPercentage
	FROM Accountant.Tax WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[TaxRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name, Amount, IsPercentage
	FROM Accountant.Tax WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[TaxInsert]
(  
	@Name Varchar(50),
	@Amount Money,
	@IsPercentage Bit,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO  Accountant.Tax([Name],[Amount],[IsPercentage])
	VALUES(@Name,@Amount,@IsPercentage)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[TaxDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.Tax
	WHERE Id = @Id   
   
END
GO
/****** Object:  Table [Guardian].[SecurityAnswer]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[SecurityAnswer](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[UserId] [numeric](10, 0) NOT NULL,
	[QuestionId] [numeric](10, 0) NOT NULL,
	[Answer] [varchar](50) NOT NULL,
 CONSTRAINT [PK__Security__3214EC07529933DA] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Accountant].[TaxUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[TaxUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Amount Money,
	@IsPercentage Bit
)
AS
BEGIN
	
	UPDATE Accountant.Tax
	SET	
		Name = @Name,	
		Amount = @Amount,
		IsPercentage = @IsPercentage
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTypeUpdate]
(	
	@Id Numeric(10,0),
	@Name Varchar(50),
	@Accomodation SmallInt,
	@ExtraAccomodation SmallInt
)
AS
BEGIN
	
	UPDATE Lodge.RoomType
	SET	
		Name = @Name,
		Accomodation = @Accomodation,
		ExtraAccomodation = @ExtraAccomodation
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTypeReadAll]
AS
BEGIN

	SELECT Id, Name, Accomodation, ExtraAccomodation
	FROM Lodge.RoomType WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Name, Accomodation, ExtraAccomodation
	FROM Lodge.RoomType WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTypeInsert]
(  
	@Name Varchar(50),
	@Accomodation SmallInt,
	@ExtraAccomodation SmallInt,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
	
	INSERT INTO Lodge.RoomType(Name, Accomodation, ExtraAccomodation)
	VALUES(@Name, @Accomodation, @ExtraAccomodation)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTypeDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [Lodge].[RoomTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Lodge.RoomType
	WHERE Id = @Id      
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[RuleUpdate]
(  
	@ModuleSeperator Char(1),
	@PathSeperator Char(1)
)
AS
BEGIN
	UPDATE Navigator.[Rule]
	SET ModuleSeperator = @ModuleSeperator,
		PathSeperator = @PathSeperator
	
END
GO
/****** Object:  StoredProcedure [Customer].[RuleUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[RuleUpdate]
	(  
		@Id Numeric(10,0),  
		@IsPinNumber Bit,
		@IsAlternateContactNumber Bit,
		@IsEmail Bit,
		@IsIdentityProof Bit		
	)
	AS
	BEGIN
		update Customer.[Rule]
		Set [IsPinNo] = @IsPinNumber,		
			[IsAlternateContactNo] = @IsAlternateContactNumber,
			[IsEmail] = @IsEmail,
			[IsIdentityProof] = @IsIdentityProof		
	END
GO
/****** Object:  StoredProcedure [Navigator].[RuleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[RuleRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		ModuleSeperator,
		PathSeperator
	FROM Navigator.[Rule] WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Customer].[RuleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[RuleRead]  
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	SELECT 
		IsNull(IsPinNo,0) IsPinNo,
		IsNull(IsAlternateContactNo,0) IsAlternateContactNo,
		IsNull(IsEmail,0) IsEmail,
		IsNull(IsIdentityProof,0) IsIdentityProof 
	FROM Customer.[Rule] WITH (NOLOCK)
 
END
GO
/****** Object:  StoredProcedure [Configuration].[RuleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[RuleRead]
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select DateFormat	
	From Configuration.[Rule] WITH (NOLOCK)
 
END
GO
/****** Object:  StoredProcedure [Navigator].[RuleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[RuleInsert]
(  
	@ModuleSeperator Char(1),
	@PathSeperator Char(1),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Navigator.[Rule](ModuleSeperator, PathSeperator)
	VALUES(@ModuleSeperator, @PathSeperator)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Customer].[RuleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Customer].[RuleInsert]
	(  
		@IsPinNumber Bit,
		@IsAlternateContactNumber Bit,
		@IsEmail Bit,
		@IsIdentityProof Bit,	
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		Declare @Cnt Int
		Select @Cnt = COUNT(*) From Customer.[Rule]
		
		if(@Cnt > 0)
		Begin	
			update Customer.CustomerRule
			set [IsPinNo] = @IsPinNumber,		
				[IsAlternateContactNo] = @IsAlternateContactNumber,
				[IsEmail] = @IsEmail,
				[IsIdentityProof] = @IsIdentityProof		
		End
		Else
		Begin
			INSERT INTO CustomerRule([IsPinNo],[IsAlternateContactNo],[IsEmail],[IsIdentityProof])
			VALUES(@IsPinNumber,@IsAlternateContactNumber, @IsEmail,@IsIdentityProof)
		End
	    
		SET @Id = 1
	END
GO
/****** Object:  StoredProcedure [Configuration].[RuleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[RuleInsert]
(  
	@DateFormat Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From [Configuration].[Rule]
	
	if(@Cnt > 0)
	Begin	
		update [Configuration].[Rule]
		set [DateFormat] = @DateFormat
	End
	Else
	Begin
		INSERT INTO [Configuration].[Rule]([DateFormat])
		VALUES(@DateFormat)
    End
    
	SET @Id = 1
END
GO
/****** Object:  Table [Configuration].[State]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Configuration].[State](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_State] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityQuestionUpdate]
(
	@Id Numeric(10,0),  
	@Question Varchar(127)
)
AS
BEGIN
	
	UPDATE SecurityQuestion
	SET	
		Question = @Question		
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadDuplicate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityQuestionReadDuplicate]
(
	@Name VARCHAR(250)		
)
AS
BEGIN

	SELECT Id,Question	
	FROM [Guardian].securityQuestion WITH (NOLOCK)
	WHERE Question = @Name
			
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityQuestionReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		Question	
	FROM SecurityQuestion WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityQuestionRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Question		
	FROM SecurityQuestion WITH (NOLOCK)
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityQuestionInsert]
(  
	@Question Varchar(155),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO SecurityQuestion(Question)
	VALUES(@Question)
   
	SET @Id = @@IDENTITY

END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityQuestionDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityQuestionDelete]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   DELETE 		
   FROM SecurityQuestion
   WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRuleRead] 
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	SELECT DefaultPassword	
	FROM UserRule WITH (NOLOCK)
 
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRuleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRuleInsert]
(  
	@DefaultUserPwd Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From UserRule
	
	if(@Cnt > 0)
	Begin	
		update UserRule
		set [DefaultPassword] = @DefaultUserPwd	
	End
	Else
	Begin
		INSERT INTO UserRule([DefaultPassword])
		VALUES(@DefaultUserPwd)
    End
    
	SET @Id = 1
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTariffInsert]
	(  
		@CategoryId Numeric(10,0),
		@TypeId Numeric(10,0),
		@IsAC Bit,
		@StartDate DateTime,
		@EndDate DateTime,
		@Rate Money,
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		INSERT INTO [Lodge].RoomTariff(CategoryId,TypeId,IsAirConditioned,StartDate,EndDate,Rate)
		VALUES(
			@CategoryId, 
			@TypeId, 
			@IsAC, 
			Convert(varchar(11), @StartDate,101), -- Removing Time
			Convert(varchar(11), @EndDate,101),	-- Removing Time	
			@Rate)	
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTariffDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].RoomTariff
		WHERE Id = @Id      
	END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleUpdate]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRoleUpdate]
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0)
)
AS
BEGIN
	UPDATE Guardian.UserRole
	SET RoleId = @RoleId  
	WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleReadAll]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRoleReadAll]
AS
BEGIN

	SELECT UserId, RoleId		
	FROM Guardian.UserRole WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleRead]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRoleRead]
(
	@UserId Numeric(10,0)
)
AS
BEGIN

	SELECT UserId, RoleId		
	FROM Guardian.UserRole WITH (NOLOCK)
	WHERE UserId = @UserId
	
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleInsert]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRoleInsert]
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
   INSERT INTO Guardian.UserRole (UserId, RoleId)
   VALUES(@UserId, @RoleId)
   SET @Id = 0
   --SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Guardian].[UserRoleDelete]    Script Date: 05/09/2015 17:09:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[UserRoleDelete]
(
	@UserId Numeric(10,0)
)
AS
BEGIN	
	DELETE 		
	FROM Guardian.UserRole
	WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [Configuration].[StateUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[StateUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE [Configuration].State
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Configuration].[StateReadDuplicate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[StateReadDuplicate]
(
	@Name VARCHAR(50)		
)
AS
BEGIN

	SELECT Id	
	FROM Configuration.State WITH (NOLOCK)
	WHERE Name = @Name	
				
END
GO
/****** Object:  StoredProcedure [Configuration].[StateReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[StateReadAll]
AS
BEGIN
	
	SELECT Id, Name
	FROM Configuration.State WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Configuration].[StateRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[StateRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, Name
   FROM Configuration.State WITH (NOLOCK)
   WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Configuration].[StateInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[StateInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Configuration].State([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Configuration].[StateDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Configuration].[StateDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Configuration].State
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityAnswerUpdate]
(
	@UserId Numeric(10,0),
	@QuestionId Numeric(10,0),
	@Answer Varchar(50),
	@Id  Numeric(10,0) 
)
AS
BEGIN
	Declare @cnt Int
	Select @cnt=COUNT(*) from Guardian.SecurityAnswer where UserId = @UserId
	
	if @cnt>0
	Begin	
		UPDATE Guardian.SecurityAnswer
		SET	
			--UserId = @UserId,
			QuestionId = @QuestionId,
			Answer = @Answer
		WHERE UserId = @UserId
   End
   Else
   Begin
		Insert Into Guardian.SecurityAnswer(UserId,QuestionId,Answer)
		values(@UserId,@QuestionId,@Answer)
   End
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityAnswerReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		UserId,
		QuestionId,
		Answer
	FROM Guardian.SecurityAnswer WITH (NOLOCK)
	WHERE UserId = @ParentId
	   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityAnswerRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, UserId, QuestionId, Answer 		
	FROM Guardian.SecurityAnswer WITH (NOLOCK)
	WHERE UserId = @Id   
   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityAnswerInsert]
(
	@UserId Numeric(10,0),
	@QuestionId Numeric(10,0),
	@Answer Varchar(50),
	@Id Numeric(10,0) OUT
)
AS
BEGIN

	INSERT INTO Guardian.SecurityAnswer (UserId, QuestionId, Answer)
	VALUES(@UserId, @QuestionId, @Answer)   
	SET @Id = @@IDENTITY
   
END
GO
/****** Object:  StoredProcedure [Guardian].[SecurityAnswerDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SecurityAnswerDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Guardian.SecurityAnswer
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdateStatus]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationUpdateStatus]
(	
	@ProductId Numeric(10,0),
	@StatusId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.RoomReservation
	SET	StatusId = @StatusId
	WHERE Id = @ProductId 
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationUpdate]
	(	
		@Id Numeric(10,0),
		@ActivityDate DateTime,
		@StatusId Numeric(10,0),
		@NoOfDays Numeric(3,0),	
		@NoOfRooms	TinyInt,
		@RoomCategoryId Numeric(10,0) = Null,
		@RoomTypeId Numeric(10,0) = Null,
		@ACPreference Int,		
		@NoOfMale TinyInt,
		@NoOfFemale	TinyInt,
		@NoOfChild TinyInt,
		@NoOfInfant	TinyInt,
		@Remark Varchar(MAX)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].[RoomReservation]
		SET				
			[BookingFrom] = @ActivityDate,
			[StatusId] = @StatusId,
			[NoOfDays] = @NoOfDays,		
			[NoOfRooms] = @NoOfRooms,		
			[RoomCategoryId] = @RoomCategoryId,
			[RoomTypeId] = @RoomTypeId,
			[AcRoomPreference] = @ACPreference,
			[NoOfMale] = @NoOfMale,
			[NoOfFemale] = @NoOfFemale,
			[NoOfChild] = @NoOfChild,
			[NoOfInfant] = @NoOfInfant,
			[Remark] = @Remark
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[TaxSlabReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId Id, Limit, Amount, StartDate, EndDate
	FROM Accountant.TaxSlab WITH (NOLOCK)
	WHERE TaxId = @ParentId	
	
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[TaxSlabReadAll]
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Accountant.TaxSlab WITH (NOLOCK)	
	
END
GO
/****** Object:  StoredProcedure [Accountant].[TaxSlabRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Accountant].[TaxSlabRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Accountant.TaxSlab WITH (NOLOCK)
	WHERE TaxId = @Id	
	
END
GO
/****** Object:  StoredProcedure [Guardian].[SearchUserByLoginId]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[SearchUserByLoginId]
(
	@LoginId Varchar(15)
)
AS
BEGIN
	
	SELECT 
		Id, LoginId, [Password]
	FROM Guardian.Account
	WHERE LoginId = @LoginId
	
	SELECT UserId, RoleId
	FROM Guardian.UserRole
	WHERE UserId = (SELECT Id
		FROM Guardian.Account
		WHERE LoginId = @LoginId)
   
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadDuplicate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--		[Lodge].[TariffReadDuplicate] 4,'03-12-2013', '03-24-2013'

CREATE PROCEDURE [Lodge].[TariffReadDuplicate]
(
	@RoomId Numeric(10,0),
	@StartDate DateTime,
	@EndDate DateTime
)
AS
BEGIN

	SELECT 
		RT.Id,
		RT.Rate,
		RT.StartDate,
		RT.EndDate,
		RT.Id
	FROM [Lodge].RoomTariff RT WITH (NOLOCK)
	WHERE Id = @RoomId
		AND (
			cast(convert(char(11), @StartDate, 113) as datetime) BETWEEN cast(convert(char(11), StartDate, 113) as datetime) AND cast(convert(char(11), EndDate, 113) as datetime)
			OR cast(convert(char(11), @EndDate, 113) as datetime) BETWEEN cast(convert(char(11), StartDate, 113) as datetime) AND cast(convert(char(11), EndDate, 113) as datetime)
			OR cast(convert(char(11), StartDate, 113) as datetime) BETWEEN cast(convert(char(11), @StartDate, 113) as datetime) AND cast(convert(char(11), @EndDate, 113) as datetime)
			OR cast(convert(char(11), EndDate, 113) as datetime) BETWEEN cast(convert(char(11), @StartDate, 113) as datetime) AND cast(convert(char(11), @EndDate, 113) as datetime)
		)
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllFuture]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[TariffReadAllFuture]
AS
BEGIN
	
	SELECT 
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM RoomTariff WITH (NOLOCK)
	WHERE CAST(FLOOR(CAST(EndDate AS float)) AS datetime) > CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime)
   
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffReadAllCurrent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[TariffReadAllCurrent]
AS
BEGIN
	
	SELECT 
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM [Lodge].RoomTariff WITH (NOLOCK)
	WHERE CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) >= CAST(FLOOR(CAST(StartDate AS float)) AS datetime)
		AND CAST(FLOOR(CAST(GETDATE() AS float)) AS datetime) <= CAST(FLOOR(CAST(EndDate AS float)) AS datetime)
   
END
GO
/****** Object:  StoredProcedure [Lodge].[TariffIsExist]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[TariffIsExist]
(  
	@CategoryId Numeric(10,0),
	@TypeId Numeric(10,0),
	@IsAC Bit,
	@StartDate DateTime,
	@EndDate DateTime
)
AS
BEGIN	
	
	-- removing time from date
	Set @StartDate = cast(convert(char(11), @StartDate, 113) as datetime) 
	Set @EndDate = cast(convert(char(11), @EndDate, 113) as datetime) 
	
	Select 
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate 
	From RoomTariff
	Where CategoryId = @CategoryId
	And TypeId = @TypeId
	And IsAirConditioned = @IsAC
	And 
	(
		(
			(CAST(FLOOR(CAST(StartDate AS float)) AS datetime) >= @StartDate)
			And
			(CAST(FLOOR(CAST(StartDate AS float)) AS datetime) <= @EndDate)
		)
	Or
		(
			(CAST(FLOOR(CAST(EndDate AS float)) AS datetime) >= @StartDate)
			And
			(CAST(FLOOR(CAST(EndDate AS float)) AS datetime) <= @EndDate)
		)
	Or
		(
			(@StartDate >= CAST(FLOOR(CAST(StartDate AS float)) AS datetime))
			And
			(@EndDate <=CAST(FLOOR(CAST(StartDate AS float)) AS datetime))
		)
	Or
		(
			(@StartDate >= CAST(FLOOR(CAST(EndDate AS float)) AS datetime))
			And
			(@EndDate <= CAST(FLOOR(CAST(EndDate AS float)) AS datetime))
		)
	)
	
END
GO
/****** Object:  Table [Organization].[UnitClosureReason]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Organization].[UnitClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Reason] [varchar](50) NOT NULL,
	[UnitId] [numeric](10, 0) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_BuildingClosureReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Lodge].[UpdateReservationStatusToCheckIn]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [Lodge].[UpdateReservationStatusToCheckIn]
(
	@ReservationId Numeric(10,0)
)
As
BEGIN

	UPDATE Lodge.RoomReservation
	SET StatusId = 10004 --Check in status
	WHERE Lodge.RoomReservation.Id = @ReservationId
	
END
GO
/****** Object:  StoredProcedure [Organization].[FaxReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Organization].[FaxReadForParent]
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
	END
GO
/****** Object:  StoredProcedure [Organization].[FaxRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[FaxRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT Id, Fax,	OrganizationId
	FROM Organization.Fax WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Organization].[FaxInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[FaxInsert]
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
END
GO
/****** Object:  StoredProcedure [Organization].[FaxDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[FaxDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[Fax]
	WHERE Id = @Id 
END
GO
/****** Object:  StoredProcedure [Organization].[EmailReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[EmailReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id, OrganizationId, Email
	FROM Organization.Email
	WHERE OrganizationId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Organization].[EmailInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Organization].[EmailInsert]
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
END
GO
/****** Object:  StoredProcedure [Organization].[EmailDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Organization].[EmailDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[Email]
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[ContactNumberReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, ContactNumber
	FROM Organization.ContactNumber WITH (NOLOCK)
	WHERE OrganizationId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[ContactNumberRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT  Id, ContactNumber, OrganizationId
	FROM Organization.ContactNumber WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[ContactNumberInsert]
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
END
GO
/****** Object:  StoredProcedure [Organization].[ContactNumberDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[ContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Organization].[ContactNumber]
	WHERE Id = @Id   
   
END
GO
/****** Object:  Table [Customer].[Customer]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Customer].[Customer](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InitialId] [numeric](10, 0) NULL,
	[FirstName] [varchar](50) NOT NULL,
	[MiddleName] [varchar](50) NULL,
	[LastName] [varchar](50) NULL,
	[Address] [varchar](255) NOT NULL,
	[CountryId] [numeric](10, 0) NULL,
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
/****** Object:  Table [Lodge].[BuildingFloor]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[BuildingFloor](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Floor] [varchar](50) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_BuildingFloor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Lodge].[BuildingDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE  [Lodge].[BuildingDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].Building
		WHERE Id = @Id      
	END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadForPath]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactReadForPath]
(  
	@Path Varchar(1024)
)
AS
BEGIN	
	SELECT Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact
	WHERE [Path] + '.' +  Extension = @Path --OR ParentId = @Id
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactReadAll]
AS
BEGIN

	SELECT Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactRead]
(  
	@Id  Numeric(10,0)
)
AS
BEGIN

	SELECT Id, [FileName], [Path], Extension, Style, [Version], ParentId,
		CreatedByUserId, CreatedAt, ModifiedByUserId, ModifiedAt
	FROM Navigator.Artifact WITH (NOLOCK)
	WHERE Id = @Id --OR ParentId = @Id
	
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactInsert]
(  
	@FileName Varchar(50),
	@Path Varchar(MAX),
	@Extension Varchar(5),
	@Style Numeric(2,0),
	@ParentId Numeric(10, 0),
	@CreatedByUserId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Navigator.Artifact([FileName], [Path], Extension, Style, [Version], ParentId, CreatedByUserId, CreatedAt)
	VALUES(@FileName, @Path, @Extension, @Style, 1, @ParentId, @CreatedByUserId, GETDATE())
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  Table [Navigator].[CatalogueModuleLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navigator].[CatalogueModuleLink](
	[Id] [numeric](10, 0) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ModuleId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CatalogueModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[BuildingUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[BuildingUpdate]
(  
	@Id Numeric(10,0),
	@Name Varchar(50),	
	@TypeId Numeric(10,0),
	@StatusId Numeric(10,0)
)
AS
BEGIN	
	UPDATE Lodge.Building
	SET	
		Name = @Name,
		TypeId = @TypeId
	WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[BuildingReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name],
		[TypeId],
		[StatusId],
		[OrganizationId]
	FROM [Lodge].Building WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[BuildingRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name],
		[TypeId],
		[StatusId],
		[OrganizationId]
	FROM [Lodge].Building WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingModifyStatus]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Lodge].[BuildingModifyStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Building
		SET	
			[StatusId] = @StatusId			
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[BuildingInsert]
	(  
		@Name Varchar(50),	
		@TypeId Numeric(10,0),
		@StatusId Numeric(10,0),		
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		INSERT INTO [Lodge].Building([Name],[TypeId],[StatusId])
		VALUES(@Name,@TypeId,@StatusId)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactUpdate]
(  
	@Id  Numeric(10,0),
	@FileName Varchar(50),
	@Path Varchar(MAX),
	@ParentId Numeric(10, 0),
	@ModifiedByUserId  Numeric(10,0)
)
AS
BEGIN	
	
	UPDATE Navigator.Artifact
	SET [FileName] = @FileName,
		[Path] = @Path,
		[Version] = [Version] + 1,
		ParentId = @ParentId,
		ModifiedByUserId = @ModifiedByUserId,
		ModifiedAt = GETDATE()
	WHERE Id = @Id
END
GO
/****** Object:  Table [Lodge].[CheckIn]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[CheckIn](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CheckInDate] [datetime] NOT NULL,
	[Purpose] [varchar](max) NULL,
	[ArrivedFrom] [varchar](max) NULL,
	[Remark] [varchar](max) NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ReservationId] [numeric](10, 0) NULL,
	[StatusId] [numeric](10, 0) NULL,
	[InvoiceId] [numeric](10, 0) NULL,
	[InvoiceNumber] [varchar](50) NULL,
 CONSTRAINT [PK_CheckIn] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentSearchWithImportance]
( 
	@Start Datetime,
	@End Datetime,
	@Importance Numeric(1,0)
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE [Start] >= @Start AND [Start] <= @End AND [End] <= @End AND ImportanceId = @Importance
   
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentSearch]
( 
	@Start Datetime,
	@End Datetime
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE [Start] >= @Start AND [Start] <= @End AND [End] <= @End
   
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentReadAll]
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
		,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
		,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentInsert]
(  
	@ActorId Numeric(10, 0),
	@Title Varchar(50),
	@TypeId Numeric(10,0),
	@Start Datetime,
	@End Datetime,
	@Location Varchar(50),
	@Description Varchar(250),
	@ImportanceId Numeric(10,0) = null,
	@Reminder Datetime = null,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	INSERT INTO [AutoTourism].[Utility].[Appointment]
		(ActorId, Title, TypeId, Start, [End], Location, [Description], ImportanceId, Reminder)
    VALUES
		(@ActorId, @Title, @TypeId, @Start, @End, @Location, @Description, @ImportanceId, @Reminder)
		
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Utility].[AppointmentDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Utility].[AppointmentDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.Appointment
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountReadAll]
AS
BEGIN

	SELECT 
		Id,
		LoginId,
		[Password]
	FROM Guardian.Account WITH (NOLOCK)
	WHERE LoginId != 'support'   
	SELECT 
		UserId, 
		RoleId
	FROM Guardian.UserRole WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Guardian].[AccountRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[AccountRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN
	SELECT 
		Id,
		LoginId,
		[Password]
	FROM Guardian.Account WITH (NOLOCK)
	WHERE Id = @Id
	
	SELECT RoleId 
	FROM Guardian.UserRole WITH (NOLOCK)
	WHERE UserId = @Id
	
END
--Guardian.AccountRead 1
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Utility].[AppointmentUpdate]
(
	@Id Numeric(10,0),
	@ActorId Numeric(10,0),
	@Title Varchar(50),
	@TypeId Numeric(10,0),
	@Start Datetime,
	@End Datetime,
	@Location Varchar(50),
	@Description Varchar(250),
	@ImportanceId Numeric(10,0) = null,
	@Reminder Datetime = null
)
AS
BEGIN
	UPDATE [Utility].[Appointment]
	SET ActorId = @ActorId
		,[Title] = @Title
		,[TypeId] = @TypeId
		,[Start] = @Start
		,[End] = @End
		,[Location] = @Location
		,[Description] = @Description
		,[ImportanceId] = @ImportanceId
		,[Reminder] = @Reminder
	WHERE Id = @Id   
END
GO
/****** Object:  Table [Navigator].[ArtifactComponentLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navigator].[ArtifactComponentLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ComponentId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_FormModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Form = 1, Catalogue = 2, Report = 3' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'TABLE',@level1name=N'ArtifactComponentLink', @level2type=N'COLUMN',@level2name=N'Category'
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingTypeDeletable]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [Lodge].[IsBuildingTypeDeletable] 
(
	@TypeId NUMERIC(10,0)
)
As
BEGIN

	SELECT Name 
	FROM Lodge.Building WITH (NOLOCK)
	WHERE TypeId = @TypeId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingStatusDeletable]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [Lodge].[IsBuildingStatusDeletable]
(
	@StatusId NUMERIC(10,0)
)
As
BEGIN

	SELECT Name,StatusId 
	FROM [Lodge].Building WITH (NOLOCK)
	WHERE StatusId = @StatusId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[IsBuildingDeletable]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [Lodge].[IsBuildingDeletable]
(
	@OrganizationId NUMERIC(10,0)
)
As
BEGIN

	SELECT Name,StatusId
	FROM [Lodge].Building WITH (NOLOCK)
	WHERE OrganizationId = @OrganizationId
	
END
GO
/****** Object:  StoredProcedure [Guardian].[IsInitialDeletable]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[IsInitialDeletable]
(
	@InitialId NUMERIC(10,0)
)
AS
BEGIN
	SELECT (SELECT LoginId 
		FROM Guardian.Account WITH (NOLOCK)
		WHERE Id = UserId) LoginId, FirstName, LastName
	FROM Guardian.[Profile] WITH (NOLOCK)
	WHERE Initial = @InitialId

 END
GO
/****** Object:  Table [Accountant].[InvoiceReportArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountant].[InvoiceReportArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ReportId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_ReportArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ReportArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Organization].[EmailRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[EmailRead]
(
	@Id Numeric(10,0) = null
)
AS
BEGIN

	SELECT Id, Email, OrganizationId
	FROM Organization.Email WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  Table [Accountant].[InvoiceArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountant].[InvoiceArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[InvoiceId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [Accountant].[InvoiceLineItemTax]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[InvoiceLineItemTax](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[TaxName] [varchar](50) NULL,
	[TaxAmount] [money] NULL,
	[IsPercentage] [bit] NULL,
	[LineItemId] [numeric](10, 0) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Start, [End],
		[Description], UnitRate, [Count]
	FROM Accountant.InvoiceLineItem WITH (NOLOCK)
	WHERE InvoiceId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemReadAll]
AS
BEGIN
	
	SELECT Id, Start, [End],
		[Description], UnitRate, [Count]
	FROM Accountant.InvoiceLineItem WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Start, [End],
		[Description], UnitRate, [Count],
		InvoiceId
	FROM Accountant.InvoiceLineItem WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemInsert]
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
	
	INSERT INTO Accountant.InvoiceLineItem(Start, [End], [Description], UnitRate,[Count], InvoiceId)
	VALUES(@Start,@End,@Description,@UnitRate,@Count,@InvoiceId)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Accountant.InvoiceLineItem
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemUpdate]
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
	
	UPDATE Accountant.InvoiceLineItem
	SET	
		[Start] = @Start,
		[End] = @End,
		[Description] = @Description,
		[UnitRate] = @UnitRate,
		[Count] = @Count
	WHERE Id = @Id
   
END
GO
/****** Object:  Table [Accountant].[PaymentArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Accountant].[PaymentArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[PaymentId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_PaymentArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_PaymentArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[LoginHistoryUpdate]
(
   @Id Numeric(10,0)
)
AS
BEGIN
   UPDATE Guardian.LoginHistory 
   SET LogoutStamp = GETDATE()
   WHERE Id = @Id
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[LoginHistoryReadForParent]
(
   @ParentId Numeric(10,0)
)
AS
BEGIN

   SELECT Id, LoginStamp, LogoutStamp
   FROM Guardian.LoginHistory WITH (NOLOCK)
   WHERE AccountId = @ParentId
   
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[LoginHistoryRead]
(
   @Id Numeric(10,0)
)
AS
BEGIN

   SELECT Id, AccountId, LoginStamp, LogoutStamp
   FROM Guardian.LoginHistory WITH (NOLOCK)
   WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Guardian].[LoginHistoryInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[LoginHistoryInsert]
(  
   @AccountId Numeric(10,0),
   @Id Numeric(10,0) OUT
)
AS
BEGIN
   INSERT INTO Guardian.LoginHistory (AccountId, LoginStamp, LogoutStamp)
   VALUES(@AccountId, GETDATE(), null)
   SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[OrganizationEmailRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--CREATE TABLE [dbo].[Organization](
--	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
--	[Name] [varchar](50) NOT NULL,
--	[Logo] [varbinary](max) NULL,
--	[LicenceNumber] [varchar](50) NULL,
--	[Tan] [varchar](50) NULL,
--	[Address] [varchar](255) NULL,
--	[City] [varchar](50) NULL,
--	[StateId] [numeric](10, 0) NULL,
--	[Pin] [int] NULL,
--	[ContactName] [varchar](50) NULL,
-- )


--CREATE PROCEDURE [dbo].[OrganizationRead] 
--(
--	@Id Numeric(10,0) = null
--)
--AS
--BEGIN
	
--	if(ISNULL(@Id,0) = 0)
--	Begin
--		SELECT Top 1
--				Id,
--				[Name],
--				[Logo],
--				[LicenceNumber],
--				[Tan],
--				[Address],
--				[City],
--				[StateId],
--				[Pin],
--				[ContactName]
--			FROM Organization
--	End
--	Else
--	Begin	
--		SELECT 
--			Id,
--			[Name],
--			[Logo],
--			[LicenceNumber],
--			[Tan],
--			[Address],
--			[City],
--			[StateId],
--			[Pin],
--			[ContactName]
--		FROM Organization
--		WHERE Id = @Id   
--	End
	
--END

--CREATE TABLE [dbo].[OrganizationEmail](
--	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
--	[LodgeId] [numeric](10, 0) NOT NULL,
--	[Email] [varchar](50) NOT NULL,
-- )

CREATE PROCEDURE [dbo].[OrganizationEmailRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, OrganizationId, Email
	FROM Organization.Email WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Accountant.Payment WITH (NOLOCK)
	WHERE InvoiceId = @ParentId
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentReadAll]
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Accountant.Payment WITH (NOLOCK)
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Accountant.Payment WITH (NOLOCK)
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentUpdate]
(
	@Id Numeric(10,0),
	@Date DateTime,
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Accountant.Payment
	SET
		InvoiceId = @InvoiceId,
		[Date] = @Date
	WHERE Id = @Id
   
END
GO
/****** Object:  Table [Accountant].[PaymentLineItem]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Accountant].[PaymentLineItem](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Reference] [varchar](16) NOT NULL,
	[Amount] [numeric](10, 2) NOT NULL,
	[PaymentTypeId] [numeric](10, 0) NOT NULL,
	[Remark] [varchar](255) NULL,
	[PaymentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_PaymentLineItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Accountant].[PaymentInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentInsert]
(  	
	@InvoiceId Numeric(10,0) = null,
	@Date DateTime,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	BEGIN TRANSACTION
	
	DECLARE @Max Int
	SELECT @Max = MAX(SerialNumber) + 1 FROM Invoice.Payment WHERE Date = @Date
	IF @Max IS Null SET @Max = 1
	INSERT INTO Accountant.Payment(SerialNumber, [Date], InvoiceId)
	VALUES(@Max, @Date, @InvoiceId)
    
    COMMIT TRANSACTION
    
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM Accountant.Payment
	WHERE Id = @Id   
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentAttachInvoice]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentAttachInvoice]
(
	@Id Numeric(10,0),
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Accountant.Payment
	SET
		InvoiceId = @InvoiceId
	WHERE Id = @Id
   
END
GO
/****** Object:  Table [Navigator].[ReportModuleLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Navigator].[ReportModuleLink](
	[Id] [numeric](10, 0) NOT NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[ModuleId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_ReportModuleLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Customer].[ReportArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customer].[ReportArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ReportId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_ReportArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_ReportArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Guardian].[ProfileContactNumber]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Guardian].[ProfileContactNumber](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[UserId] [numeric](10, 0) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ProfileContactNumber] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Guardian].[ProfileUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[ProfileUpdate]
(
	@Initial Numeric(10,0),
	@FirstName Varchar(50),
	@MiddleName Varchar(50) = Null,
	@LastName Varchar(50),
	@Dob DateTime,
	@Id Numeric(10,0)
)
AS
BEGIN

	Declare @Cnt Int
	Select @Cnt = COUNT(*) From [Profile] Where UserId = @Id
	If @Cnt > 0
	Begin	
		UPDATE Guardian.[Profile]
		SET	
			Initial = @Initial,
			FirstName = @FirstName,
			MiddleName = @MiddleName,
			LastName = @LastName,
			Dob = @Dob
		WHERE UserId = @Id
	End
	Else
	Begin
		Insert into [Profile](UserId,Initial,FirstName,MiddleName,LastName,Dob)
		values(@Id,@Initial,@FirstName,ISNULL(@MiddleName,''),@LastName,@Dob)
	End
   
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[ProfileRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT UserId, Initial, FirstName, MiddleName, LastName, Dob
	FROM Guardian.[Profile] WITH (NOLOCK)
	WHERE UserId = @Id
   
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[ProfileDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 
	FROM Guardian.[Profile]
	WHERE UserId = @Id
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--select * from [Lodge].[RoomReservation]

CREATE PROCEDURE [Lodge].[RoomReservationReadAll]
AS
BEGIN
	
	SELECT 
		Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate,
		IsCheckedIn, RoomCategoryId, RoomTypeId, AcRoomPreference,
		NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
		Remark
	FROM Lodge.RoomReservation WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
		
	SELECT
		Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate,
		IsCheckedIn, RoomCategoryId, RoomTypeId, AcRoomPreference,
		NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
		Remark	
	FROM Lodge.RoomReservation WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  Table [Lodge].[RoomReservationPayment]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lodge].[RoomReservationPayment](
	[RoomReservationId] [numeric](10, 0) NOT NULL,
	[PaymentId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationPayment] PRIMARY KEY CLUSTERED 
(
	[RoomReservationId] ASC,
	[PaymentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationInsert]
	(  
		@ActivityDate DateTime,
		@StatusId Numeric(10,0),
		@NoOfDays numeric(3, 0),		
		@NoOfRooms	tinyint,
		@RoomCategoryId Numeric(10,0) = Null,
		@RoomTypeId Numeric(10,0) = Null,
		@ACPreference Int,		
		@NoOfMale tinyint,
		@NoOfFemale	tinyint,
		@NoOfChild tinyint,
		@NoOfInfant	tinyint,
		@Remark varchar(MAX),		
		@Id  Numeric(10,0) OUTPUT	
	)
	AS
	BEGIN	
		
		INSERT INTO Lodge.RoomReservation(BookingFrom, StatusId, NoOfDays, NoOfRooms,
			RoomCategoryId, RoomTypeId, AcRoomPreference,
			NoOfMale, NoOfFemale, NoOfChild, NoOfInfant,
			Remark, CreatedDate)
		VALUES(@ActivityDate, @StatusId, @NoOfDays, @NoOfRooms,
			@RoomCategoryId, @RoomTypeId, @ACPreference,
			@NoOfMale, @NoOfFemale, @NoOfChild, @NoOfInfant,
			@Remark, GETDATE())
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTariffUpdate]
(
	@Id Numeric(10,0),
	@CategoryId Numeric(10,0),
	@TypeId Numeric(10,0),
	@IsAC Bit,
	@StartDate DateTime,
	@EndDate DateTime,
	@Rate Money	
)
AS
BEGIN
	
	UPDATE [Lodge].RoomTariff
	SET	
		CategoryId = @CategoryId,	
		TypeId = TypeId,
		IsAirConditioned = @IsAC,
		StartDate = Convert(varchar(11), @StartDate,101), -- Removing Time,
		EndDate = Convert(varchar(11), @EndDate,101),	-- Removing Time,
		Rate = @Rate
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTariffReadAll]
As
BEGIN

	SELECT   
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM [Lodge].RoomTariff WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTariffRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT   
		Id,
		CategoryId,
		TypeId,
		IsAirConditioned,
		StartDate,
		EndDate,
		Rate
	FROM [Lodge].RoomTariff WITH (NOLOCK)
	WHERE Id = @Id     
	
END
GO
/****** Object:  Table [Lodge].[RoomReservationArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lodge].[RoomReservationArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomReservationId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_RoomReservationArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Lodge].[RoomReservationDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].RoomReservation
	WHERE Id = @Id 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactUpdateLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)        
)
AS
BEGIN
 
	UPDATE Lodge.RoomReservationArtifact
	SET [RoomReservationId] = @ComponentId
	WHERE [ArtifactId] = @ArtifactId
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT RoomReservationId ComponentId
	FROM Lodge.RoomReservationArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactReadForComponent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationArtifactReadForComponent]
(
	@ComponentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT ArtifactId
	FROM Lodge.RoomReservationArtifact WITH (NOLOCK)
	WHERE RoomReservationId = @ComponentId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactInsertLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Lodge.RoomReservationArtifact([RoomReservationId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationArtifactDeleteLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM [Lodge].RoomReservationArtifact
	WHERE ArtifactId = @Id   
   
END
GO
/****** Object:  Table [Lodge].[Room]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[Room](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[Number] [varchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](50) NOT NULL,
	[CategoryId] [numeric](10, 0) NOT NULL,
	[TypeId] [numeric](10, 0) NOT NULL,
	[BuildingId] [numeric](10, 0) NOT NULL,
	[FloorId] [numeric](10, 0) NOT NULL,
	[IsAirConditioned] [bit] NOT NULL,
	[StatusId] [numeric](10, 0) NOT NULL,
	[Accomodation] [smallint] NOT NULL,
	[ExtraAccomodation] [smallint] NOT NULL,
 CONSTRAINT [PK_Room] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Customer].[ReadCustomerReportForArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[ReadCustomerReportForArtifact]
(
	@ArtifactId Numeric(10,0)--,
	--@Category Numeric(1)
)
AS
BEGIN
	
	SELECT  Id, ReportId
	FROM Customer.ReportArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
		--AND Category =  @Category
	
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[ProfileContactNumberReadForParent] 
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		UserId,		
		ContactNumber
	FROM Guardian.ProfileContactNumber
	WHERE UserId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[ProfileContactNumberRead] 
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		UserId,		
		ContactNumber
	FROM Guardian.ProfileContactNumber WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Guardian].[ProfileContactNumberInsert]
(  
   @UserId Numeric(10,0),
   @ContactNumber Varchar(50),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN   
   INSERT INTO Guardian.ProfileContactNumber(UserId, ContactNumber)
   VALUES(@UserId, @ContactNumber)   
   SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Guardian].[ProfileContactNumberDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Guardian].[ProfileContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN	
	DELETE 		
	FROM ProfileContactNumber
	WHERE Id = @Id   
END
GO
/****** Object:  StoredProcedure [Lodge].[IsReservationDeletable]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[IsReservationDeletable] 
(	
	@ReservationId Numeric(10,0)
)
AS
BEGIN
	
	SELECT C.CheckInDate, R.NoOfDays 
	FROM Lodge.CheckIn C WITH (NOLOCK)
	Inner Join Lodge.RoomReservation R WITH (NOLOCK) On C.ReservationId = R.Id
	WHERE C.ReservationId = @ReservationId
   
END
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomReservationId]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[ReadRoomReservationId]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	SELECT RoomReservationId
	FROM Lodge.RoomReservationArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId

END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactUpdateLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentArtifactUpdateLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0)
)
AS
BEGIN

	UPDATE Accountant.PaymentArtifact
	SET PaymentId = @ComponentId
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactReadLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT PaymentId ComponentId
	FROM Accountant.PaymentArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactInsertLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentArtifactInsertLink]
(
        @ComponentId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN

	INSERT INTO Accountant.PaymentArtifact(PaymentId, ArtifactId, Category)
    VALUES(@ComponentId, @ArtifactId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentArtifactDeleteLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Accountant.[PaymentArtifact]
	WHERE ArtifactId = @Id   
 
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentLineItemUpdate]
(
	@Id Numeric(10,0),
	@Reference Varchar(16),
	@Amount Numeric(10,2),
	@PaymentTypeId Numeric(10,0),
	@Remark Varchar(255),
	@PaymentId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Accountant.PaymentLineItem
	SET			
		Reference = @Reference,
		Amount = @Amount,
		PaymentTypeId = @PaymentTypeId,
		Remark = @Remark,
		PaymentId = @PaymentId
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentLineItemReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reference, Amount, PaymentTypeId,
		Remark, PaymentId
	FROM Accountant.PaymentLineItem WITH (NOLOCK)
	WHERE PaymentId = @ParentId	
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentLineItemReadAll]
AS
BEGIN
	
	SELECT Id, Reference, Amount,
		PaymentTypeId, Remark, PaymentId
	FROM Accountant.PaymentLineItem WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentLineItemRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reference, Amount,
		PaymentTypeId, Remark, PaymentId
	FROM Accountant.PaymentLineItem WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentLineItemInsert]
(  	
	@Reference Varchar(16),
	@Remark Varchar(255),
	@Amount money,
	@PaymentTypeId Numeric(10,0),
	@PaymentId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
	
	INSERT INTO Accountant.PaymentLineItem(PaymentTypeId, Reference, Remark, Amount, PaymentId)
	VALUES(@PaymentTypeId, @Reference, @Remark, @Amount, @PaymentId)
    
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Accountant].[PaymentLineItemDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[PaymentLineItemDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE
	FROM Accountant.PaymentLineItem
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemTaxRead]
( 
	@LineItemId Numeric(10,0)
)
AS
BEGIN 

	SELECT Id, TaxName, TaxAmount, IsPercentage, LineItemId
	FROM Accountant.InvoiceLineItemTax WITH (NOLOCK)
	WHERE LineItemId = @LineItemId

END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemTaxInsert]
( 
	@LineItemId Numeric(10,0),
	@TaxName Varchar(50), 
	@TaxAmount money, 
	@IsPercentage Bit,
	@Id Numeric(10,0) OUTPUT
)
AS
BEGIN 

	INSERT INTO Accountant.InvoiceLineItemTax(TaxName, TaxAmount, IsPercentage, LineItemId)
	VALUES(@TaxName, @TaxAmount, @IsPercentage, @LineItemId)

	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceLineItemTaxDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceLineItemTaxDelete]
( 
	@Id Numeric(10,0)
)
AS
BEGIN 

	DELETE FROM Accountant.InvoiceLineItemTax
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceReportArtifactReadForArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceReportArtifactReadForArtifact]
(
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
	
	SELECT Id, ReportId
	FROM Accountant.InvoiceReportArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
		AND Category =  @Category
	
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactComponentLinkReadForArtifact]
(
	@ArtifactId Numeric(10, 0)
)
AS
BEGIN

	SELECT ComponentId, Category
	FROM Navigator.ArtifactComponentLink WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkInsertForComponent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactComponentLinkInsertForComponent]
(
	@ArtifactId  Numeric(10,0),
    @ComponentId  Numeric(10,0),
    @Category Numeric(1,0)
)
AS
BEGIN
	
	INSERT INTO Navigator.ArtifactComponentLink(ArtifactId,ComponentId, Category)
    VALUES(@ArtifactId, @ComponentId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckinUpdateStatus]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckinUpdateStatus]
(	
	@ProductId Numeric(10,0),
	@StatusId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.CheckIn
	SET	StatusId = @StatusId
	WHERE Id = @ProductId 
   
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInUpdate]
(	
	@Id Numeric(10,0),
	--@Advance Money,
	@ReservationId Numeric(10,0),
	@ActivityDate DateTime,
	@StatusId Numeric(10,0),
	@Purpose Varchar(Max),
	@ArrivedFrom Varchar(Max),
	@Remark Varchar(Max),
	@InvoiceId Numeric(10,0) = null
)
AS
BEGIN
	
	UPDATE [Lodge].CheckIn
	SET				
		CheckInDate = @ActivityDate,
		ReservationId = @ReservationId,
		StatusId = @StatusId,
		Purpose = @Purpose,
		ArrivedFrom = @ArrivedFrom,
		Remark = @Remark,
		InvoiceId = @InvoiceId
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN		
	SELECT Id, CheckInDate,
		--[Advance],
		CreatedDate, ReservationId, StatusId,
		Purpose, ArrivedFrom, Remark,
		InvoiceId, InvoiceNumber
	FROM Lodge.CheckIn WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInLinkInvoice]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInLinkInvoice]
(	
	@Id Numeric(10,0),
	@StatusId Numeric(10,0),
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.CheckIn
	SET
		StatusId = @StatusId,
		InvoiceId = @InvoiceId
	WHERE Id = @Id
   
END
GO
/****** Object:  Table [Lodge].[CheckInArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lodge].[CheckInArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CheckInId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_CheckInArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_CheckInArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[CheckInInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--"[Lodge].[CheckInInsert]"
CREATE PROCEDURE [Lodge].[CheckInInsert]
	(  
		--@Advance Money,
		@ReservationId Numeric(10,0),		
		@ActivityDate DateTime,		
		@StatusId Numeric(10,0),
		@Purpose Varchar(Max),
		@ArrivedFrom Varchar(Max),
		@Remark Varchar(Max),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].CheckIn([CheckInDate],
		--[Advance],
		[CreatedDate],[ReservationId],[StatusId],[Purpose],[ArrivedFrom],[Remark])
		VALUES(@ActivityDate,
		--@Advance,
		GETDATE(),@ReservationId,@StatusId,@Purpose,@ArrivedFrom,@Remark)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Lodge.CheckIn
	WHERE Id = @Id      
END
GO
/****** Object:  View [Navigator].[ArtifactSummary]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [Navigator].[ArtifactSummary]
AS
SELECT     Artf.Id, AML.Category, Artf.FileName, Artf.Path, Artf.Extension, Artf.Style, Artf.Version, Artf.ParentId, Artf.CreatedByUserId, CP.FirstName AS CreatedByFirstName, 
                      CP.MiddleName AS CreatedByMiddleName, CP.LastName AS CreatedByLastName, Artf.CreatedAt, Artf.ModifiedByUserId, MP.FirstName AS ModifiedByFirstName, 
                      MP.MiddleName AS ModifiedByMiddleName, MP.LastName AS ModifiedByLastName, Artf.ModifiedAt, Comp.Id AS ComponentId, Comp.Code AS ComponentCode, 
                      Comp.Name AS ComponentName, COUNT(ArtfAtt.Id) AS AttachmentCount
FROM         Navigator.ArtifactComponentLink AS AML WITH (NOLOCK) INNER JOIN
                      Navigator.Artifact AS Artf WITH (NOLOCK) ON AML.ArtifactId = Artf.Id INNER JOIN
                      Guardian.Profile AS CP WITH (NOLOCK) ON CP.UserId = Artf.CreatedByUserId LEFT OUTER JOIN
                      Guardian.Profile AS MP WITH (NOLOCK) ON MP.UserId = Artf.ModifiedByUserId INNER JOIN
                      License.Component AS Comp WITH (NOLOCK) ON AML.ComponentId = Comp.Id LEFT OUTER JOIN
                      Navigator.ArtifactAttachmentLink AS ArtfAtt WITH (NOLOCK) ON ArtfAtt.Id = Artf.Id
GROUP BY Artf.Id, AML.Category, Artf.FileName, Artf.Path, Artf.Extension, Artf.Style, Artf.Version, Artf.ParentId, Artf.CreatedByUserId, CP.FirstName, CP.MiddleName, 
                      CP.LastName, Artf.CreatedAt, Artf.ModifiedByUserId, MP.FirstName, MP.MiddleName, MP.LastName, Artf.ModifiedAt, Comp.Id, Comp.Code, Comp.Name
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[20] 2[25] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "AML"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Artf"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 409
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "CP"
            Begin Extent = 
               Top = 6
               Left = 447
               Bottom = 125
               Right = 607
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "MP"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "Comp"
            Begin Extent = 
               Top = 126
               Left = 236
               Bottom = 245
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ArtfAtt"
            Begin Extent = 
               Top = 6
               Left = 645
               Bottom = 95
               Right = 805
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 12
         Column = 1440
         Alias = 1410
         Table =' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'VIEW',@level1name=N'ArtifactSummary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N' 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'VIEW',@level1name=N'ArtifactSummary'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'Navigator', @level1type=N'VIEW',@level1name=N'ArtifactSummary'
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactSearchByName]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactSearchByName]
(  
	@FileName Varchar(50)
)
AS
BEGIN	
	SELECT A.Id, [FileName], [Path], Extension, Style, [Version], ParentId, 
		CreatedAt, CreatedByUserId,
		P1.FirstName AS CreatedByFirstName, P1.MiddleName AS CreatedByMiddleName, P1.LastName AS CreatedByLastName, 
		ModifiedAt, ModifiedByUserId,
		P2.FirstName AS ModifiedByFirstName, P2.MiddleName AS ModifiedByMiddleName, P2.LastName AS ModifiedByLastName,
		M.Id ModuleId, M.Code ModuleCode, M.Name ModuleName, Category
	FROM (SELECT * FROM Navigator.Artifact WHERE [FileName] LIKE '%' + @FileName + '%') As A
	LEFT OUTER JOIN Guardian.[Profile] AS P1 ON A.CreatedByUserId = P1.UserId
	LEFT OUTER JOIN Guardian.[Profile] AS P2 ON A.ModifiedByUserId = P2.UserId
	INNER JOIN Navigator.ArtifactComponentLink AS AML ON ArtifactId = A.Id
	INNER JOIN License.Component AS M ON M.Id = AML.ComponentId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[BuildingFloorReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[BuildingId],
		[FLOOR]
	FROM [Lodge].BuildingFloor WITH (NOLOCK)
	WHERE BuildingId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[BuildingFloorRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[FLOOR],			
		[BuildingId]
	FROM [Lodge].BuildingFloor WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Lodge].[BuildingFloorInsert]
	(  
		@Name Varchar(50),	
		@BuildingId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].BuildingFloor([Floor],[BuildingId])
		VALUES(@Name,@BuildingId)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Lodge].[BuildingFloorDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE  [Lodge].[BuildingFloorDelete]
	(
		@Id Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].BuildingFloor
		WHERE Id = @Id      
	END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactDelete]
(  
	@Id Numeric(10,0)
)
AS
BEGIN 
 
	DELETE FROM [Navigator].ArtifactComponentLink
	WHERE ArtifactId = @Id
 
	DELETE FROM [Navigator].Artifact
	WHERE ID = @Id
	   
END
GO
/****** Object:  Table [Customer].[CustomerArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Customer].[CustomerArtifact](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](10, 0) NULL,
	[ArtifactId] [numeric](10, 0) NOT NULL,
	[Category] [numeric](1, 0) NOT NULL,
 CONSTRAINT [PK_CustomerArtifact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_CustomerArtifact] UNIQUE NONCLUSTERED 
(
	[ArtifactId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1 = Form, 2 = Catalogue, 3 = Report' , @level0type=N'SCHEMA',@level0name=N'Customer', @level1type=N'TABLE',@level1name=N'CustomerArtifact', @level2type=N'COLUMN',@level2name=N'Category'
GO
/****** Object:  Table [Customer].[CustomerContactNumber]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING OFF
GO
CREATE TABLE [Customer].[CustomerContactNumber](
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
/****** Object:  Table [AutoTourism].[CustomerInvoiceLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AutoTourism].[CustomerInvoiceLink](
	[Id] [numeric](10, 0) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
	[InvoiceId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerInvoiceLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_CustomerInvoiceLink] ON [AutoTourism].[CustomerInvoiceLink] 
(
	[CustomerId] ASC,
	[InvoiceId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Customer].[CustomerInsert]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerInsert]
	(  
		--@InitialId Numeric(10,0),
		@FirstName Varchar(50),
		@MiddleName Varchar(50),
		@LastName Varchar(50),
		@Address Varchar(255),
		@CountryId Numeric(10,0),
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
		--IF @InitialId = 0
		--Begin
		--	Set @InitialId = null
		--End

		IF @IdentityProofId = 0
		Begin
			Set @IdentityProofId = null
		End
	
		INSERT INTO Customer.Customer(--[InitialId],
		[FirstName],[MiddleName],[LastName],
			[Address],[CountryId],[StateId],[City],[Pin],[Email],[IdentityProofId],[IdentityProofName])
		VALUES(--@InitialId,
		@FirstName,@MiddleName,@LastName,@Address,@CountryId,@StateId,@City,@Pin,@Email,@IdentityProofId,@IdentityProofName)
   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Customer].[CustomerDelete]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerDelete]
 (
	@Id Numeric(10,0)
 )
 As
 Begin
	Delete From Customer.Customer
	Where Id = @Id
 End
GO
/****** Object:  Table [AutoTourism].[CustomerRoomCheckInLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AutoTourism].[CustomerRoomCheckInLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
	[RoomCheckInId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerRoomCheckInLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Customer].[CustomerReportArtifactInsertLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerReportArtifactInsertLink]
(
	@ReportId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO [Customer].ReportArtifact([ReportId],[ArtifactId],[Category])
	VALUES(@ReportId, @ArtifactId, @Category)
 
END
GO
/****** Object:  Table [AutoTourism].[CustomerRoomReservationLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [AutoTourism].[CustomerRoomReservationLink](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[CustomerId] [numeric](10, 0) NOT NULL,
	[RoomReservationId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_CustomerRoomReservationLink] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Customer].[CustomerUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerUpdate]
	(  
		@Id  Numeric(10,0),
		--@InitialId Numeric(10,0),
		@FirstName Varchar(50),
		@MiddleName Varchar(50),
		@LastName Varchar(50),
		@Address Varchar(255),
		@CountryId Numeric(10,0),
		@StateId Numeric(10,0),
		@City Varchar(50),
		@Pin Int,
		@Email Varchar(50),
		@IdentityProofId Numeric(10,0),
		@IdentityProofName Varchar(50)	
	)
	AS
	BEGIN	
		--IF @InitialId = 0
		--Begin
		--	Set @InitialId = null
		--End

		IF @IdentityProofId = 0
		Begin
			Set @IdentityProofId = null
		End
	
		UPDATE Customer.Customer
		Set --[InitialId] = @InitialId,
			[FirstName] = @FirstName,
			[MiddleName] = @MiddleName,
			[LastName] = @LastName,
			[Address] = @Address,
			[CountryId] = @CountryId,
			[StateId] = @StateId,
			[City] = @City,
			[Pin] = @Pin,
			[Email] = @Email,
			[IdentityProofId] = @IdentityProofId,
			[IdentityProofName] = @IdentityProofName
		Where Id = @Id
   
	END
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerReadAll]
As
BEGIN

	SELECT Id,
		--InitialId,
		FirstName,MiddleName,LastName,
		Address,CountryId,StateId,City,Pin,Email,
		IdentityProofId, IdentityProofName 
	FROM Customer.Customer WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerRead]
(
	@Id Numeric(10,0)
)
As
BEGIN

	SELECT  Id,
		--InitialId,
		FirstName, MiddleName, LastName,
		Address, CountryId, StateId, City, Pin, Email,
		IdentityProofId, IdentityProofName 
	FROM Customer.Customer WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactUpdateLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0)
)
AS
BEGIN

	UPDATE Accountant.InvoiceArtifact
	SET InvoiceId = @ComponentId
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactReadLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT InvoiceId ComponentId
	FROM Accountant.InvoiceArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactReadForComponent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceArtifactReadForComponent]
(
	@ComponentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT *, ArtifactId
	FROM Accountant.InvoiceArtifact WITH (NOLOCK)
	WHERE InvoiceId = @ComponentId
	
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactInsertLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Accountant.InvoiceArtifact(InvoiceId, ArtifactId, Category)
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Accountant].[InvoiceArtifactDeleteLink]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Accountant].[InvoiceArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Accountant.InvoiceArtifact
	WHERE ArtifactId = @Id   
   
END
GO
/****** Object:  StoredProcedure [Customer].[DeleteCustomerReportForArtifact]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Customer].[DeleteCustomerReportForArtifact]
(
        @ReportId Numeric(10,0),
        @ArtifactId Numeric(10,0),
        @Category Numeric(1)
)
AS
BEGIN
 
        INSERT INTO [Customer].ReportArtifact([ReportId],[ArtifactId],[Category])
        VALUES(@ReportId, @ArtifactId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Lodge].[UpdateCheckInStatus]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Lodge].[UpdateCheckInStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].CheckIn
		SET	
			[StatusId] = @StatusId
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonUpdate]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitClosureReasonUpdate]
(
	@Id Numeric(10,0),
	@Reason Varchar(50),
	@UnitId Numeric(10,0),
	@ClosedDate DateTime
)
AS
BEGIN
	
	UPDATE Organization.UnitClosureReason
	SET
		UnitId = @UnitId,
		Reason = @Reason,
		ClosedDate = @ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE Id = @Id
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadForParent]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitClosureReasonReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, UnitId, Reason, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE UnitId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonReadAll]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitClosureReasonReadAll]
AS
BEGIN
	
	SELECT Id, Reason, UnitId, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonRead]    Script Date: 05/09/2015 17:09:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitClosureReasonRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reason, UnitId, ClosedDate
	FROM Organization.UnitClosureReason WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Organization].[UnitClosureReasonInsert]
(  
	@Reason Varchar(50),
	@UnitId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Organization.UnitClosureReason(Reason, UnitId, ClosedDate)
	VALUES(@Reason, @UnitId, GETDATE())
   
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Organization].[UnitClosureReasonDelete]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE  [Organization].[UnitClosureReasonDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Organization.UnitClosureReason
	WHERE Id = @Id      
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomUpdate]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomUpdate]
(	
	@Id Numeric(10,0),
	@Number Varchar(50),	
	@Name Varchar(50),
	@Description Varchar(50),
	@CategoryId Numeric(10,0),		
	@TypeId Numeric(10,0),
	@BuildingId Numeric(10,0),
	@FloorId Numeric(10,0),
	@IsAirConditioned Bit,
	@Accomodation Smallint,
	@ExtraAccomodation Smallint,		
	@StatusId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Lodge.Room
	SET	
		Number = @Number,
		Name = @Name,
		Description = @Description,
		CategoryId = @CategoryId,
		TypeId = @TypeId,
		BuildingId = @BuildingId,
		FloorId = @FloorId,
		IsAirConditioned = @IsAirConditioned,
		Accomodation = @Accomodation,
		ExtraAccomodation = @ExtraAccomodation
	WHERE Id = @Id
   
END
GO
/****** Object:  StoredProcedure [AutoTourism].[GetCustomerIdForReservation]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[GetCustomerIdForReservation]
(  
	@ReservationId  Numeric(10,0)
)
AS
BEGIN	
	
	SELECT CustomerId
	FROM AutoTourism.CustomerRoomReservationLink WITH (NOLOCK)
	WHERE RoomReservationId = @ReservationId
	
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerInvoiceLinkRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[CustomerInvoiceLinkRead]
(
	@CustomerId Numeric(10,0)
)
As
BEGIN

	SELECT  CustomerId, InvoiceId as ActionId
	FROM AutoTourism.CustomerInvoiceLink WITH (NOLOCK)
	WHERE CustomerId = @CustomerId
	
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkRead]
(
	@CustomerId Numeric(10,0)
)
AS
BEGIN

	SELECT CustomerId, RoomReservationId
	FROM AutoTourism.CustomerRoomReservationLink WITH (NOLOCK)
	WHERE CustomerId = @CustomerId
	
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkInsert]
(  
	@CustomerId  Numeric(10,0),
	@RoomReservationId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [AutoTourism].[CustomerRoomReservationLink]([CustomerId],[RoomReservationId])
	VALUES(@CustomerId,@RoomReservationId)
   
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomReservationLinkDelete]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[CustomerRoomReservationLinkDelete]
(  		
	@RoomReservationId  Numeric(10,0)
)
AS
BEGIN
	
	DELETE AutoTourism.CustomerRoomReservationLink
	WHERE RoomReservationId = @RoomReservationId
	
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkRead]
(
	@CustomerId Numeric(10,0)
)
As
BEGIN

	SELECT  CustomerId, RoomCheckInId
	FROM AutoTourism.CustomerRoomCheckInLink WITH (NOLOCK)
	WHERE CustomerId = @CustomerId
	
END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkInsert]
	(  
		@CustomerId  Numeric(10,0),
		@RoomCheckInId  Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [AutoTourism].[CustomerRoomCheckInLink]([CustomerId],[RoomCheckInId])
		VALUES(@CustomerId,@RoomCheckInId)
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [AutoTourism].[CustomerRoomCheckInLinkDelete]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [AutoTourism].[CustomerRoomCheckInLinkDelete]
(  		
	@RoomCheckInId  Numeric(10,0)
)
AS
BEGIN
	
	DELETE AutoTourism.CustomerRoomCheckInLink
	WHERE RoomCheckInId = @RoomCheckInId
	
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerReadDuplicate]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerReadDuplicate]
(
	@ContactNumber VARCHAR(100),
	@Email VARCHAR(50),
	@IdentityProofId INT,
	@IdentityProofName VARCHAR(50)
)
AS
BEGIN

	SELECT Id
	FROM Customer.Customer WITH (NOLOCK)
		WHERE (IdentityProofId = @IdentityProofId	
		AND IdentityProofName = @IdentityProofName)
		OR (Email = @Email AND @Email != '')
		OR ID IN (SELECT CustomerId FROM CustomerContactNumber WITH (NOLOCK)
			WHERE Number IN (SELECT SplitText FROM Split(@ContactNumber, ',')))
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerContactNumberRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT Id, Number, CustomerId
	FROM Customer.CustomerContactNumber WITH (NOLOCK)
	WHERE CustomerId = @Id
	
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerContactNumberInsert]
(  
	@CustomerId Numeric(10,0),
	@ContactNumber Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN		

	INSERT INTO Customer.CustomerContactNumber([Number],[CustomerId])
	VALUES(@ContactNumber,@CustomerId)

	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerContactNumberDelete]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerContactNumberDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	DELETE FROM Customer.CustomerContactNumber
	WHERE CustomerId = @Id
	  
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactUpdateLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerArtifactUpdateLink]
(
	@ComponentId Numeric(10,0),
    @ArtifactId Numeric(10,0)        
)
AS
BEGIN
 
	UPDATE Customer.CustomerArtifact
    SET [CustomerId] = @ComponentId
    WHERE [ArtifactId] = @ArtifactId
    
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactReadLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT CustomerId ComponentId
	FROM Customer.CustomerArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactInsertLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Customer.CustomerArtifact([CustomerId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Customer].[CustomerArtifactDeleteLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[CustomerArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Customer.CustomerArtifact
	WHERE ArtifactId = @Id   
   
END
GO
/****** Object:  StoredProcedure [Navigator].[ArtifactComponentLinkReadForComponent]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Navigator].[ArtifactComponentLinkReadForComponent]
(  
	@ComponentId  Numeric(10,0),
	@Category Numeric(1,0)
)
AS
BEGIN

	SELECT Id, FileName, Path, Extension, Style, Version, ParentId, CreatedByUserId, 
		CreatedByFirstName, CreatedByMiddleName, CreatedByLastName, CreatedAt, ModifiedByUserId, 
		ModifiedByFirstName, ModifiedByMiddleName, ModifiedByLastName, ModifiedAt, 
		ComponentId, ComponentCode, ComponentName, AttachmentCount
	FROM Navigator.ArtifactSummary
	WHERE ComponentId = @ComponentId
		AND Category = @Category
		--AND A.ParentId IS NULL
		
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactUpdateLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInArtifactUpdateLink]
(
    @ComponentId Numeric(10,0),
    @ArtifactId Numeric(10,0)
)
AS
BEGIN
 
	UPDATE Lodge.CheckInArtifact
	SET [CheckInId] = @ComponentId
	WHERE [ArtifactId] = @ArtifactId
 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactReadLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInArtifactReadLink]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT CheckInId ComponentId
	FROM Lodge.CheckInArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactInsertLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInArtifactInsertLink]
(
	@ComponentId Numeric(10,0),
	@ArtifactId Numeric(10,0),
	@Category Numeric(1)
)
AS
BEGIN
 
	INSERT INTO Lodge.CheckInArtifact([CheckInId],[ArtifactId], [Category])
	VALUES(@ComponentId, @ArtifactId, @Category)
 
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInArtifactDeleteLink]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInArtifactDeleteLink]
(
	@Id Numeric(10,0)
)
AS
BEGIN
 
	DELETE FROM Lodge.CheckInArtifact
	WHERE ArtifactId = @Id   
   
END
GO
/****** Object:  StoredProcedure [Customer].[IsStateIdDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[IsStateIdDeletable]
(
	@StateId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WITH (NOLOCK) WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer WITH (NOLOCK)
	WHERE StateId = @StateId

 END
GO
/****** Object:  StoredProcedure [Customer].[IsInitialDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[IsInitialDeletable]
(
	@InitialId NUMERIC(10,0)
)
AS
BEGIN

	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WITH (NOLOCK) WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer WITH (NOLOCK)
	WHERE InitialId = @InitialId

 END
GO
/****** Object:  StoredProcedure [Customer].[IsIdentityProofIdDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Customer].[IsIdentityProofIdDeletable]
(
	@IdentityProofId NUMERIC(10,0)
)
AS
BEGIN
	SELECT  FirstName, LastName, 
		(SELECT TOP 1 Number FROM Customer.CustomerContactNumber WITH (NOLOCK) WHERE CustomerId = Customer.Id) ContactNumber
	FROM Customer.Customer WITH (NOLOCK)
	WHERE IdentityProofId = @IdentityProofId

 END
GO
/****** Object:  StoredProcedure [Lodge].[ReadRoomCheckInId]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[ReadRoomCheckInId]
(
	@ArtifactId Numeric(10,0)
)
AS
BEGIN
	
	SELECT CheckInId
	FROM Lodge.CheckInArtifact WITH (NOLOCK)
	WHERE ArtifactId = @ArtifactId
	
END
GO
/****** Object:  Table [Lodge].[RoomClosureReason]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[RoomClosureReason](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[ClosedDate] [datetime] NOT NULL,
	[Reason] [varchar](256) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomClosureReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [Lodge].[RoomImage]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [Lodge].[RoomImage](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Image] [image] NOT NULL,
 CONSTRAINT [PK_RoomImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [Lodge].[RoomDelete]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM [Lodge].Room
	WHERE Id = @Id 
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadOpenRoom]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReadOpenRoom] 
(
	@BuildingId numeric(10,0)
)
As
BEGIN

	SELECT id,Number,Name,StatusId 
	FROM Lodge.Room  WITH (NOLOCK)
	WHERE BuildingId = @BuildingId
		AND StatusId != 10002 -- Closed Room
		
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadClosedRoom]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReadClosedRoom]
(
	@BuildingId numeric(10,0)
)
As
BEGIN	
	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room 
	WHERE BuildingId = @BuildingId
		AND StatusId = 10002 -- Closed Room
		
End
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadCheckedInRoom]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Lodge].[RoomReadCheckedInRoom]
(
	@BuildingId numeric(10,0)
)
As
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK) 
	WHERE BuildingId = @BuildingId
		AND StatusId = 10003 -- Occupied Room
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadAll]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReadAll]
As
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomModifyStatus]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomModifyStatus]
	(	
		@Id Numeric(10,0),
		@StatusId Numeric(10,0)
	)
	AS
	BEGIN
		
		UPDATE [Lodge].Room
		SET	
			[StatusId] = @StatusId			
		WHERE Id = @Id
	   
	END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomTypeDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [Lodge].[RoomIsRoomTypeDeletable]
(
	@TypeId NUMERIC(10,0)
)
As
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE TypeId = @TypeId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomStatusDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Lodge].[RoomIsRoomStatusDeletable]
(
	@RoomStatusId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE StatusId = @RoomStatusId

END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsRoomCategoryDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Lodge].[RoomIsRoomCategoryDeletable]
(
	@RoomCategoryId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE CategoryId = @RoomCategoryId

END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingFloorDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [Lodge].[RoomIsBuildingFloorDeletable] 
(
	@FloorId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE FloorId = @FloorId

 END
GO
/****** Object:  StoredProcedure [Lodge].[RoomIsBuildingDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomIsBuildingDeletable]
(
	@BuildingId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
	WHERE BuildingId = @BuildingId

END
GO
/****** Object:  StoredProcedure [Lodge].[RoomInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomInsert]
(  
	@Number Varchar(50),	
	@Name Varchar(50),
	@Description Varchar(50),
	@CategoryId Numeric(10,0),		
	@TypeId Numeric(10,0),
	@BuildingId Numeric(10,0),
	@FloorId Numeric(10,0),
	@IsAirConditioned Bit,
	@Accomodation Smallint,
	@ExtraAccomodation Smallint,
	@StatusId Numeric(10,0),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Lodge.Room(Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned, Accomodation, ExtraAccomodation,
		StatusId)
	VALUES(@Number,@Name,@Description,@BuildingId,@FloorId,
		@CategoryId,@TypeId,@IsAirConditioned,@Accomodation, @ExtraAccomodation,
		@StatusId)
	
	SET @Id = @@IDENTITY
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomTariffModifyRate]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomTariffModifyRate]
	(	
		@CategoryId Numeric(10,0),
		@TypeId Numeric(10,0),
		@Rate Money
	)
	AS
	BEGIN
		
		Update [Lodge].[RoomTariff]
		Set Rate = @Rate
		Where id in (
		Select id From [Lodge].[Room]
		Where CategoryId = @CategoryId
		And TypeId = @TypeId
		)
	   
	END
GO
/****** Object:  Table [Lodge].[RoomReservationDetails]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Lodge].[RoomReservationDetails](
	[Id] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[RoomId] [numeric](10, 0) NOT NULL,
	[ReservationId] [numeric](10, 0) NOT NULL,
 CONSTRAINT [PK_RoomReservationDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationSearch]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [Lodge].[RoomReservationSearch] 
	(
		@StartDate DateTime,
		@EndDate DateTime,
		@StatusId Numeric(10,0)
	)
	As
	Begin
		SELECT 
			R.Id, BookingFrom, StatusId, NoOfDays, NoOfRooms, CreatedDate, IsCheckedIn,
			R.RoomCategoryId, R.RoomTypeId, R.AcRoomPreference,
			RRD.RoomId AS ProductId,
			R.[NoOfMale], R.[NoOfFemale], R.[NoOfChild], R.[NoOfInfant],
			R.[Remark]
		FROM [Lodge].RoomReservation R WITH (NOLOCK)
		LEFT OUTER JOIN Lodge.RoomReservationDetails RRD WITH (NOLOCK) ON R.Id = RRD.ReservationId
		Where R.statusId = @StatusId
		And cast(convert(Char(11), R.BookingFrom, 113) AS DateTime) 
		Between cast(convert(Char(11), @StartDate, 113) AS DateTime) 		 
		And cast(convert(Char(11), @EndDate, 113) AS DateTime)		
		--And R.IsCheckedIn = 0
		order by R.Id, RRD.ReservationId
	End
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationRoomLinkRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReservationRoomLinkRead]
(
   @ReservationId Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, RoomId, ReservationId
   FROM Lodge.RoomReservationDetails WITH (NOLOCK)
   WHERE ReservationId = @ReservationId   
   
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [Lodge].[RoomReservationDetailsInsert]
(  
	@RoomId  Numeric(10,0),
	@ReservationId  Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO [Lodge].[RoomReservationDetails]([RoomId],[ReservationId])
	VALUES(@RoomId,@ReservationId)
   
	SET @Id = @@IDENTITY
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsDelete]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE  [Lodge].[RoomReservationDetailsDelete]
	(
		@ReservationId  Numeric(10,0)
	)
	AS
	BEGIN
		
		DELETE 		
		FROM [Lodge].[RoomReservationDetails]
		WHERE ReservationId = @ReservationId      
	END
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageReadForParent]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomImageReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		[RoomId],
		[Name],
		[Image]
	FROM [Lodge].RoomImage WITH (NOLOCK)
	WHERE RoomId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomImageRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomImageRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		[RoomId],
		[Name],
		[Image]
	FROM [Lodge].RoomImage WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomReadBookedRoom]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomReadBookedRoom]
(
      @BuildingId Numeric(10,0),
      @RoomCategoryId Numeric(10,0),
      @RoomTypeId Numeric(10,0),
      @IsAc Bit
)
AS
BEGIN

	DECLARE @CurrentDate Date = GETDATE();
	SELECT Id, Number, Name, Description, BuildingId, FloorId,
		CategoryId, TypeId, IsAirConditioned,
		Accomodation, ExtraAccomodation,
		StatusId
	FROM Lodge.Room WITH (NOLOCK)
    WHERE BuildingId = @BuildingId
		AND StatusId != 10002 --Closed Room
        AND Id IN (
			SELECT RRD.RoomId  
            FROM Lodge.RoomReservationDetails RRD WITH (NOLOCK)
				INNER JOIN (SELECT * 
					FROM Lodge.RoomReservation WITH (NOLOCK)
					WHERE RoomCategoryId = ISNULL(@RoomCategoryId,RoomCategoryId)
						AND RoomTypeId = IsNull(@RoomTypeId,RoomTypeId)
						AND AcRoomPreference = @IsAc) RR 
					ON  RR.Id = RRD.ReservationId
                INNER JOIN  AutoTourism.CustomerRoomReservationLink CRRL WITH (NOLOCK) ON CRRL.RoomReservationId = RR.Id
            WHERE RR.StatusId = 10001 --Open room 
				AND(DATEADD(DAY, -1, RR.BookingFrom) > @CurrentDate
				OR DATEADD(DAY, RR.NoOfDays, RR.BookingFrom) > @CurrentDate))     

END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonReadForParent]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomClosureReasonReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN

	SELECT 
		Id,
		[ClosedDate],
		[Reason],			
		[RoomId]
	FROM [Lodge].RoomClosureReason WITH (NOLOCK)
	WHERE RoomId = @ParentId
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonRead]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomClosureReasonRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Reason],			
		[RoomId],
		[ClosedDate]
	FROM [Lodge].RoomClosureReason WITH (NOLOCK)
	WHERE Id = @Id   
	
END
GO
/****** Object:  StoredProcedure [Lodge].[RoomClosureReasonInsert]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[RoomClosureReasonInsert]
	(  
		@Reason Varchar(50),	
		@RoomId Numeric(10,0),
		@Id  Numeric(10,0) OUTPUT
	)
	AS
	BEGIN	
		
		INSERT INTO [Lodge].RoomClosureReason([Reason],[RoomId],ClosedDate)
		VALUES(@Reason,@RoomId,GETDATE())
	   
		SET @Id = @@IDENTITY
	END
GO
/****** Object:  StoredProcedure [Lodge].[ReadAllCheckInRooms]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [Lodge].[ReadAllCheckInRooms]
(
	@ReservationId Numeric(10,0)
)
As
BEGIN

	SELECT distinct(RoomId)
	FROM Lodge.RoomReservationDetails WITH (NOLOCK)
	WHERE ReservationId In
		(SELECT DISTINCT(C.ReservationId)
		FROM Lodge.CheckIn C WITH (NOLOCK)
		INNER JOIN Lodge.RoomReservation R WITH (NOLOCK)ON C.ReservationId = R.Id
		WHERE C.StatusId = 10001
			And R.IsCheckedIn = 1)
		AND ReservationId <> @ReservationId
		
END
GO
/****** Object:  StoredProcedure [Lodge].[CheckInIsRoomDeletable]    Script Date: 05/09/2015 17:09:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [Lodge].[CheckInIsRoomDeletable]
(
	@RoomId NUMERIC(10,0)
)
AS
BEGIN

	SELECT Id, CheckInDate, Purpose, ArrivedFrom, Remark, CreatedDate, ReservationId,
		StatusId, InvoiceNumber
	FROM Lodge.CheckIn WITH (NOLOCK)
	WHERE ReservationId IN (SELECT Id
		FROM Lodge.RoomReservationDetails WITH (NOLOCK)
		WHERE ReservationId = @RoomId)

END
GO
/****** Object:  Default [DF_RoomReservation_IsCheckedIn]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[RoomReservation] ADD  CONSTRAINT [DF_RoomReservation_IsCheckedIn]  DEFAULT ((0)) FOR [IsCheckedIn]
GO
/****** Object:  Default [DF_CustomerArtifact_Category]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[CustomerArtifact] ADD  CONSTRAINT [DF_CustomerArtifact_Category]  DEFAULT ((1)) FOR [Category]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomCategory]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomCategory] FOREIGN KEY([RoomCategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomReservation_RoomType]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_RoomType] FOREIGN KEY([RoomTypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_RoomType]
GO
/****** Object:  ForeignKey [FK_RoomReservation_Status]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[RoomReservation]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservation_Status] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservation] CHECK CONSTRAINT [FK_RoomReservation_Status]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomCategory]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomCategory]
GO
/****** Object:  ForeignKey [FK_RoomTariff_RoomType]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[RoomTariff]  WITH CHECK ADD  CONSTRAINT [FK_RoomTariff_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
ALTER TABLE [Lodge].[RoomTariff] CHECK CONSTRAINT [FK_RoomTariff_RoomType]
GO
/****** Object:  ForeignKey [FK_Profile_Account]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Account]
GO
/****** Object:  ForeignKey [FK_Profile_Initial]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[Profile]  WITH CHECK ADD  CONSTRAINT [FK_Profile_Initial] FOREIGN KEY([Initial])
REFERENCES [Configuration].[Initial] ([Id])
GO
ALTER TABLE [Guardian].[Profile] CHECK CONSTRAINT [FK_Profile_Initial]
GO
/****** Object:  ForeignKey [FK_Payment_Invoice]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Accountant].[Payment]  WITH CHECK ADD  CONSTRAINT [FK_Payment_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Accountant].[Invoice] ([Id])
GO
ALTER TABLE [Accountant].[Payment] CHECK CONSTRAINT [FK_Payment_Invoice]
GO
/****** Object:  ForeignKey [FK_InvoiceTaxation_Invoice]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Accountant].[InvoiceTax]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceTaxation_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Accountant].[Invoice] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceTax] CHECK CONSTRAINT [FK_InvoiceTaxation_Invoice]
GO
/****** Object:  ForeignKey [FK_LoginLogoutHistory_Account]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[LoginHistory]  WITH CHECK ADD  CONSTRAINT [FK_LoginLogoutHistory_Account] FOREIGN KEY([AccountId])
REFERENCES [Guardian].[Account] ([Id])
GO
ALTER TABLE [Guardian].[LoginHistory] CHECK CONSTRAINT [FK_LoginLogoutHistory_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account] FOREIGN KEY([CreatedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account]
GO
/****** Object:  ForeignKey [FK_Artifact_Account1]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Account1] FOREIGN KEY([ModifiedByUserId])
REFERENCES [Guardian].[Account] ([Id])
GO
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Account1]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Navigator].[Artifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact] FOREIGN KEY([ParentId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Navigator].[Artifact] CHECK CONSTRAINT [FK_Artifact_Artifact]
GO
/****** Object:  ForeignKey [FK_Appointment_AppointmentType]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_AppointmentType] FOREIGN KEY([TypeId])
REFERENCES [Utility].[AppointmentType] ([Id])
GO
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_AppointmentType]
GO
/****** Object:  ForeignKey [FK_Appointment_Importance]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Utility].[Appointment]  WITH CHECK ADD  CONSTRAINT [FK_Appointment_Importance] FOREIGN KEY([ImportanceId])
REFERENCES [Utility].[Importance] ([Id])
GO
ALTER TABLE [Utility].[Appointment] CHECK CONSTRAINT [FK_Appointment_Importance]
GO
/****** Object:  ForeignKey [FK_Building_Organization]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Lodge].[Building]  WITH CHECK ADD  CONSTRAINT [FK_Building_Organization] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
ALTER TABLE [Lodge].[Building] CHECK CONSTRAINT [FK_Building_Organization]
GO
/****** Object:  ForeignKey [Organization_FK_ContactNumberId]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Organization].[ContactNumber]  WITH CHECK ADD  CONSTRAINT [Organization_FK_ContactNumberId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
ALTER TABLE [Organization].[ContactNumber] CHECK CONSTRAINT [Organization_FK_ContactNumberId]
GO
/****** Object:  ForeignKey [FK_LineItem_Invoice]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Accountant].[InvoiceLineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Accountant].[Invoice] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceLineItem] CHECK CONSTRAINT [FK_LineItem_Invoice]
GO
/****** Object:  ForeignKey [Organization_FK_Id]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Organization].[Email]  WITH CHECK ADD  CONSTRAINT [Organization_FK_Id] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
ALTER TABLE [Organization].[Email] CHECK CONSTRAINT [Organization_FK_Id]
GO
/****** Object:  ForeignKey [Organization_FK_FaxId]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Organization].[Fax]  WITH CHECK ADD  CONSTRAINT [Organization_FK_FaxId] FOREIGN KEY([OrganizationId])
REFERENCES [Organization].[Organization] ([Id])
GO
ALTER TABLE [Organization].[Fax] CHECK CONSTRAINT [Organization_FK_FaxId]
GO
/****** Object:  ForeignKey [FK_UserRole_Account]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Account]
GO
/****** Object:  ForeignKey [FK_UserRole_Role]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[UserRole]  WITH CHECK ADD  CONSTRAINT [FK_UserRole_Role] FOREIGN KEY([RoleId])
REFERENCES [Guardian].[Role] ([Id])
GO
ALTER TABLE [Guardian].[UserRole] CHECK CONSTRAINT [FK_UserRole_Role]
GO
/****** Object:  ForeignKey [FK_TaxDetails_Taxation]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Accountant].[TaxSlab]  WITH CHECK ADD  CONSTRAINT [FK_TaxDetails_Taxation] FOREIGN KEY([TaxId])
REFERENCES [Accountant].[Tax] ([Id])
GO
ALTER TABLE [Accountant].[TaxSlab] CHECK CONSTRAINT [FK_TaxDetails_Taxation]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_Account]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_Account] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Account] ([Id])
GO
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_Account]
GO
/****** Object:  ForeignKey [FK_SecurityAnswer_SecurityQuestion]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Guardian].[SecurityAnswer]  WITH CHECK ADD  CONSTRAINT [FK_SecurityAnswer_SecurityQuestion] FOREIGN KEY([QuestionId])
REFERENCES [Guardian].[SecurityQuestion] ([Id])
GO
ALTER TABLE [Guardian].[SecurityAnswer] CHECK CONSTRAINT [FK_SecurityAnswer_SecurityQuestion]
GO
/****** Object:  ForeignKey [FK_State_Country]    Script Date: 05/09/2015 17:09:57 ******/
ALTER TABLE [Configuration].[State]  WITH CHECK ADD  CONSTRAINT [FK_State_Country] FOREIGN KEY([CountryId])
REFERENCES [Configuration].[Country] ([Id])
GO
ALTER TABLE [Configuration].[State] CHECK CONSTRAINT [FK_State_Country]
GO
/****** Object:  ForeignKey [FK_BuildingClosureReason_Building]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Organization].[UnitClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_BuildingClosureReason_Building] FOREIGN KEY([UnitId])
REFERENCES [Lodge].[Building] ([Id])
GO
ALTER TABLE [Organization].[UnitClosureReason] CHECK CONSTRAINT [FK_BuildingClosureReason_Building]
GO
/****** Object:  ForeignKey [Customer_FK_IdentityProofId]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_IdentityProofId] FOREIGN KEY([IdentityProofId])
REFERENCES [Configuration].[IdentityProofType] ([Id])
GO
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_IdentityProofId]
GO
/****** Object:  ForeignKey [Customer_FK_InitialId]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_InitialId] FOREIGN KEY([InitialId])
REFERENCES [Configuration].[Initial] ([Id])
GO
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_InitialId]
GO
/****** Object:  ForeignKey [Customer_FK_StateId]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[Customer]  WITH CHECK ADD  CONSTRAINT [Customer_FK_StateId] FOREIGN KEY([StateId])
REFERENCES [Configuration].[State] ([Id])
GO
ALTER TABLE [Customer].[Customer] CHECK CONSTRAINT [Customer_FK_StateId]
GO
/****** Object:  ForeignKey [FK_BuildingFloor_Building]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[BuildingFloor]  WITH CHECK ADD  CONSTRAINT [FK_BuildingFloor_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
ALTER TABLE [Lodge].[BuildingFloor] CHECK CONSTRAINT [FK_BuildingFloor_Building]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_CatalogueModuleLink_Module]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Navigator].[CatalogueModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_CatalogueModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
ALTER TABLE [Navigator].[CatalogueModuleLink] CHECK CONSTRAINT [FK_CatalogueModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_CheckIn_ActionStatus]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_ActionStatus] FOREIGN KEY([StatusId])
REFERENCES [Customer].[ActionStatus] ([Id])
GO
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_ActionStatus]
GO
/****** Object:  ForeignKey [FK_CheckIn_RoomReservation]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[CheckIn]  WITH CHECK ADD  CONSTRAINT [FK_CheckIn_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
ALTER TABLE [Lodge].[CheckIn] CHECK CONSTRAINT [FK_CheckIn_RoomReservation]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Navigator].[ArtifactComponentLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Navigator].[ArtifactComponentLink] CHECK CONSTRAINT [FK_FormModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_FormModuleLink_Module]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Navigator].[ArtifactComponentLink]  WITH CHECK ADD  CONSTRAINT [FK_FormModuleLink_Module] FOREIGN KEY([ComponentId])
REFERENCES [License].[Component] ([Id])
GO
ALTER TABLE [Navigator].[ArtifactComponentLink] CHECK CONSTRAINT [FK_FormModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[InvoiceReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[InvoiceReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Report] FOREIGN KEY([ReportId])
REFERENCES [Accountant].[InvoiceReport] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_Artifact_Artifact1]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[InvoiceArtifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Artifact1] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceArtifact] CHECK CONSTRAINT [FK_Artifact_Artifact1]
GO
/****** Object:  ForeignKey [FK_Artifact_Invoice]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[InvoiceArtifact]  WITH CHECK ADD  CONSTRAINT [FK_Artifact_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Accountant].[Invoice] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceArtifact] CHECK CONSTRAINT [FK_Artifact_Invoice]
GO
/****** Object:  ForeignKey [FK_LineItemTaxation_LineItem]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[InvoiceLineItemTax]  WITH CHECK ADD  CONSTRAINT [FK_LineItemTaxation_LineItem] FOREIGN KEY([LineItemId])
REFERENCES [Accountant].[InvoiceLineItem] ([Id])
GO
ALTER TABLE [Accountant].[InvoiceLineItemTax] CHECK CONSTRAINT [FK_LineItemTaxation_LineItem]
GO
/****** Object:  ForeignKey [FK_PaymentArtifact_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[PaymentArtifact]  WITH CHECK ADD  CONSTRAINT [FK_PaymentArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Accountant].[PaymentArtifact] CHECK CONSTRAINT [FK_PaymentArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_PaymentArtifact_Payment]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[PaymentArtifact]  WITH CHECK ADD  CONSTRAINT [FK_PaymentArtifact_Payment] FOREIGN KEY([PaymentId])
REFERENCES [Accountant].[Payment] ([Id])
GO
ALTER TABLE [Accountant].[PaymentArtifact] CHECK CONSTRAINT [FK_PaymentArtifact_Payment]
GO
/****** Object:  ForeignKey [FK_PaymentLineItem_Payment]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[PaymentLineItem]  WITH CHECK ADD  CONSTRAINT [FK_PaymentLineItem_Payment] FOREIGN KEY([PaymentId])
REFERENCES [Accountant].[Payment] ([Id])
GO
ALTER TABLE [Accountant].[PaymentLineItem] CHECK CONSTRAINT [FK_PaymentLineItem_Payment]
GO
/****** Object:  ForeignKey [FK_PaymentLineItem_PaymentType]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Accountant].[PaymentLineItem]  WITH CHECK ADD  CONSTRAINT [FK_PaymentLineItem_PaymentType] FOREIGN KEY([PaymentTypeId])
REFERENCES [Accountant].[PaymentType] ([Id])
GO
ALTER TABLE [Accountant].[PaymentLineItem] CHECK CONSTRAINT [FK_PaymentLineItem_PaymentType]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportModuleLink_Module]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Navigator].[ReportModuleLink]  WITH CHECK ADD  CONSTRAINT [FK_ReportModuleLink_Module] FOREIGN KEY([ModuleId])
REFERENCES [License].[Component] ([Id])
GO
ALTER TABLE [Navigator].[ReportModuleLink] CHECK CONSTRAINT [FK_ReportModuleLink_Module]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Customer].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_ReportArtifact_Report]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[ReportArtifact]  WITH CHECK ADD  CONSTRAINT [FK_ReportArtifact_Report] FOREIGN KEY([ReportId])
REFERENCES [Customer].[Report] ([Id])
GO
ALTER TABLE [Customer].[ReportArtifact] CHECK CONSTRAINT [FK_ReportArtifact_Report]
GO
/****** Object:  ForeignKey [FK_ProfileContactNumber_Profile]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Guardian].[ProfileContactNumber]  WITH CHECK ADD  CONSTRAINT [FK_ProfileContactNumber_Profile] FOREIGN KEY([UserId])
REFERENCES [Guardian].[Profile] ([UserId])
GO
ALTER TABLE [Guardian].[ProfileContactNumber] CHECK CONSTRAINT [FK_ProfileContactNumber_Profile]
GO
/****** Object:  ForeignKey [FK_RoomReservationPayment_Payment]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[RoomReservationPayment]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationPayment_Payment] FOREIGN KEY([PaymentId])
REFERENCES [Accountant].[Payment] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservationPayment] CHECK CONSTRAINT [FK_RoomReservationPayment_Payment]
GO
/****** Object:  ForeignKey [FK_RoomReservationPayment_RoomReservation]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[RoomReservationPayment]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationPayment_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservationPayment] CHECK CONSTRAINT [FK_RoomReservationPayment_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_RoomReservationArtifact_RoomReservation]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[RoomReservationArtifact]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationArtifact_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservationArtifact] CHECK CONSTRAINT [FK_RoomReservationArtifact_RoomReservation]
GO
/****** Object:  ForeignKey [FK_Room_Building]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_Building] FOREIGN KEY([BuildingId])
REFERENCES [Lodge].[Building] ([Id])
GO
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_Building]
GO
/****** Object:  ForeignKey [FK_Room_BuildingFloor]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_BuildingFloor] FOREIGN KEY([FloorId])
REFERENCES [Lodge].[BuildingFloor] ([Id])
GO
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_BuildingFloor]
GO
/****** Object:  ForeignKey [FK_Room_RoomCategory]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomCategory] FOREIGN KEY([CategoryId])
REFERENCES [Lodge].[RoomCategory] ([Id])
GO
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomCategory]
GO
/****** Object:  ForeignKey [FK_Room_RoomStatus]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomStatus] FOREIGN KEY([StatusId])
REFERENCES [Lodge].[RoomStatus] ([Id])
GO
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomStatus]
GO
/****** Object:  ForeignKey [FK_Room_RoomType]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[Room]  WITH CHECK ADD  CONSTRAINT [FK_Room_RoomType] FOREIGN KEY([TypeId])
REFERENCES [Lodge].[RoomType] ([Id])
GO
ALTER TABLE [Lodge].[Room] CHECK CONSTRAINT [FK_Room_RoomType]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_Artifact]
GO
/****** Object:  ForeignKey [FK_CheckInArtifact_CheckIn]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Lodge].[CheckInArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CheckInArtifact_CheckIn] FOREIGN KEY([CheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
ALTER TABLE [Lodge].[CheckInArtifact] CHECK CONSTRAINT [FK_CheckInArtifact_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Artifact]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Artifact] FOREIGN KEY([ArtifactId])
REFERENCES [Navigator].[Artifact] ([Id])
GO
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Artifact]
GO
/****** Object:  ForeignKey [FK_CustomerForm_Customer]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[CustomerArtifact]  WITH CHECK ADD  CONSTRAINT [FK_CustomerForm_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
ALTER TABLE [Customer].[CustomerArtifact] CHECK CONSTRAINT [FK_CustomerForm_Customer]
GO
/****** Object:  ForeignKey [CustomerContactNumber_FK_CustomerId]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [Customer].[CustomerContactNumber]  WITH CHECK ADD  CONSTRAINT [CustomerContactNumber_FK_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
ALTER TABLE [Customer].[CustomerContactNumber] CHECK CONSTRAINT [CustomerContactNumber_FK_CustomerId]
GO
/****** Object:  ForeignKey [FK_CustomerInvoiceLink_Customer]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [AutoTourism].[CustomerInvoiceLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerInvoiceLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
ALTER TABLE [AutoTourism].[CustomerInvoiceLink] CHECK CONSTRAINT [FK_CustomerInvoiceLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerInvoiceLink_Invoice]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [AutoTourism].[CustomerInvoiceLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerInvoiceLink_Invoice] FOREIGN KEY([InvoiceId])
REFERENCES [Accountant].[Invoice] ([Id])
GO
ALTER TABLE [AutoTourism].[CustomerInvoiceLink] CHECK CONSTRAINT [FK_CustomerInvoiceLink_Invoice]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_CheckIn]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn] FOREIGN KEY([RoomCheckInId])
REFERENCES [Lodge].[CheckIn] ([Id])
GO
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_CheckIn]
GO
/****** Object:  ForeignKey [FK_CustomerRoomCheckInLink_Customer]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomCheckInLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
ALTER TABLE [AutoTourism].[CustomerRoomCheckInLink] CHECK CONSTRAINT [FK_CustomerRoomCheckInLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_Customer]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_Customer] FOREIGN KEY([CustomerId])
REFERENCES [Customer].[Customer] ([Id])
GO
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_Customer]
GO
/****** Object:  ForeignKey [FK_CustomerRoomReservationLink_RoomReservation]    Script Date: 05/09/2015 17:09:58 ******/
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink]  WITH CHECK ADD  CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation] FOREIGN KEY([RoomReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
ALTER TABLE [AutoTourism].[CustomerRoomReservationLink] CHECK CONSTRAINT [FK_CustomerRoomReservationLink_RoomReservation]
GO
/****** Object:  ForeignKey [FK_RoomClosureReason_Room]    Script Date: 05/09/2015 17:09:59 ******/
ALTER TABLE [Lodge].[RoomClosureReason]  WITH CHECK ADD  CONSTRAINT [FK_RoomClosureReason_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
ALTER TABLE [Lodge].[RoomClosureReason] CHECK CONSTRAINT [FK_RoomClosureReason_Room]
GO
/****** Object:  ForeignKey [FK_RoomImage_Room]    Script Date: 05/09/2015 17:09:59 ******/
ALTER TABLE [Lodge].[RoomImage]  WITH CHECK ADD  CONSTRAINT [FK_RoomImage_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
ALTER TABLE [Lodge].[RoomImage] CHECK CONSTRAINT [FK_RoomImage_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_Room]    Script Date: 05/09/2015 17:09:59 ******/
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_Room] FOREIGN KEY([RoomId])
REFERENCES [Lodge].[Room] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_Room]
GO
/****** Object:  ForeignKey [FK_RoomReservationDetails_RoomReservation]    Script Date: 05/09/2015 17:09:59 ******/
ALTER TABLE [Lodge].[RoomReservationDetails]  WITH CHECK ADD  CONSTRAINT [FK_RoomReservationDetails_RoomReservation] FOREIGN KEY([ReservationId])
REFERENCES [Lodge].[RoomReservation] ([Id])
GO
ALTER TABLE [Lodge].[RoomReservationDetails] CHECK CONSTRAINT [FK_RoomReservationDetails_RoomReservation]
GO
