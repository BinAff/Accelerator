CREATE TABLE Guardian.UserRule(
	DefaultPassword Varchar(50) NULL
) ON [PRIMARY]
GO

CREATE PROCEDURE Guardian.[UserRuleRead] 
(  
   @Id Numeric(10,0)  
)  
AS  
BEGIN  
   
	Select 
		DefaultPassword	
	From UserRule
 
END
GO

CREATE PROCEDURE Guardian.[UserRuleInsert]
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