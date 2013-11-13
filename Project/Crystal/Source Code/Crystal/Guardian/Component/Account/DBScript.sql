IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.AccountResetPassword') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.AccountResetPassword
GO
CREATE PROCEDURE Guardian.AccountResetPassword
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.AccountInsert') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.AccountInsert
GO
CREATE PROCEDURE Guardian.AccountInsert
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.AccountDelete') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.AccountDelete
GO
CREATE PROCEDURE Guardian.AccountDelete
(
   @Id Numeric(10,0)
)
AS
BEGIN
   DELETE FROM Guardian.Account
   WHERE Id = @Id
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.AccountRead') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.AccountRead
GO
CREATE PROCEDURE Guardian.AccountRead
(
   @Id Numeric(10,0)
)
AS
BEGIN	
	SELECT 
		Id,
		LoginId,
		[Password],
		(SELECT RoleId 
			FROM Guardian.UserRole 
			WHERE UserId = @Id) AS RoleId
	FROM Guardian.Account
	WHERE LoginId != @Id  
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.AccountReadAll') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.AccountReadAll
GO
CREATE PROCEDURE Guardian.AccountReadAll
AS
BEGIN	
	SELECT 
		Id,
		LoginId,
		[Password]
	FROM Guardian.Account
	WHERE LoginId != 'support'   
	SELECT 
		UserId, 
		RoleId
	FROM Guardian.UserRole   
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.AccountUpdate') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.AccountUpdate
GO
CREATE PROCEDURE Guardian.AccountUpdate
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

--UserRoleInsert
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.UserRoleInsert') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.UserRoleInsert
GO
CREATE PROCEDURE Guardian.UserRoleInsert
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
   INSERT INTO Guardian.UserRole (UserId, RoleId)
   VALUES(@UserId, @RoleId)   
   SET @Id = @@IDENTITY
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.UserRoleRead') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.UserRoleRead
GO
CREATE PROCEDURE Guardian.UserRoleRead
(
	@UserId Numeric(10,0)
)
AS
BEGIN	
	SELECT UserId, RoleId		
	FROM Guardian.UserRole
	WHERE UserId = @UserId
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.UserRoleReadAll') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.UserRoleReadAll
GO
CREATE PROCEDURE Guardian.UserRoleReadAll
(
	@UserId Numeric(10,0)
)
AS
BEGIN	
	SELECT UserId, RoleId		
	FROM Guardian.UserRole
END

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.UserRoleUpdate') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.UserRoleUpdate
GO
CREATE PROCEDURE Guardian.UserRoleUpdate
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.UserRoleDelete') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.UserRoleDelete
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.UserRoleDelete') AND type in (N'U'))
DROP TABLE Guardian.UserRoleDelete
GO
CREATE PROCEDURE Guardian.UserRoleDelete
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

--ProfileContactNumber
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.ProfileContactNumber') AND type in (N'U'))
DROP TABLE Guardian.ProfileContactNumber
GO
CREATE TABLE Guardian.ProfileContactNumber(
	UserId Numeric(10, 0) NOT NULL,
	ContactNumber Varchar(50) NOT NULL
) ON [PRIMARY]
ALTER TABLE Guardian.ProfileContactNumber  WITH CHECK ADD  CONSTRAINT ProfileContactNumber_FK_UserId FOREIGN KEY(UserId)
REFERENCES Guardian.Account (Id)
ALTER TABLE Guardian.ProfileContactNumber CHECK CONSTRAINT ProfileContactNumber_FK_UserId
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.ProfileContactNumberInsert') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.ProfileContactNumberInsert
GO
Create PROCEDURE Guardian.ProfileContactNumberInsert
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.ProfileContactNumberDelete') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.ProfileContactNumberDelete
GO
CREATE PROCEDURE Guardian.ProfileContactNumberDelete
(
	@UserId Numeric(10,0)
)
AS
BEGIN	
	DELETE 		
	FROM ProfileContactNumber
	WHERE UserId = @UserId   
END

GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.ProfileContactNumberRead') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.ProfileContactNumberRead
GO
CREATE PROCEDURE Guardian.ProfileContactNumberRead 
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	SELECT 
		0 As Id,
		UserId,		
		ContactNumber
	FROM Guardian.ProfileContactNumber
	WHERE UserId = @ParentId   
END
GO

--BEGIN TRANSACTION

--EXEC ProfileDelete 3
--EXEC SecurityAnswerDelete 3
--EXEC UserRoleDelete 3
--EXEC UserContactNumberDelete 3
--EXEC UserDelete 3

--COMMIT TRANSACTION
