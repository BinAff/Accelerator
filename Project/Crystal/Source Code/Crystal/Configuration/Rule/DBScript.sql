/****** Object:  Table [dbo].[RuleConfiguration]    Script Date: 08/21/2012 22:51:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[RuleConfiguration](
	[DateFormat] [varchar](50) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

/****** Object:  StoredProcedure [dbo].[RuleConfigurationInsert]    Script Date: 08/21/2012 22:52:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RuleConfigurationInsert]
(  
	@DateFormat Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From RuleConfiguration
	
	if(@Cnt > 0)
	Begin	
		update RuleConfiguration
		set [DateFormat] = @DateFormat
	End
	Else
	Begin
		INSERT INTO RuleConfiguration([DateFormat])
		VALUES(@DateFormat)
    End
    
	SET @Id = 1
END

GO

/****** Object:  StoredProcedure [dbo].[RuleConfigurationRead]    Script Date: 08/21/2012 22:54:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[RuleConfigurationRead]
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select 
	[DateFormat]		
	From RuleConfiguration
 
END
GO
