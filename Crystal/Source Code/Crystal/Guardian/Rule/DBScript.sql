

CREATE TABLE [dbo].[RuleUser](
	[DefaultPassword] [varchar](50) NULL
) ON [PRIMARY]

/***************************/

CREATE PROCEDURE [dbo].[RuleUserRead] 
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select 
	DefaultPassword	
	From RuleUser
 
END

/***************************/

CREATE PROCEDURE [dbo].[RuleUserInsert]
(  
	@DefaultUserPwd Varchar(50),	
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	Declare @Cnt Int
	Select @Cnt = COUNT(*) From RuleUser
	
	if(@Cnt > 0)
	Begin	
		update RuleUser
		set [DefaultPassword] = @DefaultUserPwd	
	End
	Else
	Begin
		INSERT INTO RuleUser([DefaultPassword])
		VALUES(@DefaultUserPwd)
    End
    
	SET @Id = 1
END
