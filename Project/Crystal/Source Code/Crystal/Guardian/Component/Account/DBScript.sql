IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.AccountResetPassword') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.AccountResetPassword
GO
CREATE PROCEDURE Gaurdian.AccountResetPassword
(
	@Id Numeric(10,0),
	@Password Varchar(50)
)
AS
BEGIN
	
	UPDATE Gaurdian.Account
	SET	
		[Password] = @Password	
	WHERE Id = @Id
   
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.AccountInsert') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.AccountInsert
GO
CREATE PROCEDURE Gaurdian.AccountInsert
(  
   @LoginId Varchar(15),   
   @Password Varchar(127),
   --@RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
   INSERT INTO Gaurdian.Account(LoginId, [Password])
   VALUES (@LoginId, @Password)   
   SET @Id = @@IDENTITY   
   --INSERT INTO User_Role (UserId, RoleId)
   --VALUES(@Id, @RoleId)
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.AccountDelete') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.AccountDelete
GO
CREATE PROCEDURE Gaurdian.AccountDelete
(
   @Id Numeric(10,0)
)
AS
BEGIN
   DELETE FROM Gaurdian.Account
   WHERE Id = @Id
END

--StoredProcedure Gaurdian.ProfileContactNumberRead
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.ProfileContactNumberRead') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.ProfileContactNumberRead
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.AccountReadAll') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.AccountReadAll
GO
CREATE PROCEDURE Gaurdian.AccountReadAll
AS
BEGIN	
	SELECT 
		Id,
		LoginId,
		[Password]
	FROM Gaurdian.Account
	WHERE LoginId != 'support'   
	SELECT 
		UserId, 
		RoleId
	FROM Gaurdian.UserRole   
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.AccountUpdate') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.AccountUpdate
GO
CREATE PROCEDURE Gaurdian.AccountUpdate
(
   @Id Numeric(10,0),
   @LoginId Varchar(15),
   @Password Varchar(127)
   --@RoleId Numeric(10,0)
)
AS
BEGIN	
	UPDATE Gaurdian.Account
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

--StoredProcedure Gaurdian.UserRoleInsert
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.UserRoleInsert') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.UserRoleInsert
GO
CREATE PROCEDURE Gaurdian.UserRoleInsert
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
   INSERT INTO Gaurdian.UserRole (UserId, RoleId)
   VALUES(@UserId, @RoleId)   
   SET @Id = @@IDENTITY
END
GO

--StoredProcedure Gaurdian.UserRoleDelete
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.UserRoleDelete') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.UserRoleDelete
GO
CREATE PROCEDURE Gaurdian.UserRoleDelete
(
	@UserId Numeric(10,0)
)
AS
BEGIN	
	DELETE 		
	FROM Gaurdian.UserRole
	WHERE UserId = @UserId
END
GO

--ProfileContactNumber
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.ProfileContactNumber') AND type in (N'U'))
DROP TABLE Gaurdian.ProfileContactNumber
GO
CREATE TABLE Gaurdian.ProfileContactNumber(
	UserId Numeric(10, 0) NOT NULL,
	ContactNumber Varchar(50) NOT NULL
) ON [PRIMARY]
ALTER TABLE Gaurdian.ProfileContactNumber  WITH CHECK ADD  CONSTRAINT ProfileContactNumber_FK_UserId FOREIGN KEY(UserId)
REFERENCES Gaurdian.Account (Id)
ALTER TABLE Gaurdian.ProfileContactNumber CHECK CONSTRAINT ProfileContactNumber_FK_UserId
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.ProfileContactNumberInsert') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.ProfileContactNumberInsert
GO
Create PROCEDURE Gaurdian.ProfileContactNumberInsert
(  
   @UserId Numeric(10,0),
   @ContactNumber Varchar(50),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN   
   INSERT INTO Gaurdian.ProfileContactNumber(UserId, ContactNumber)
   VALUES(@UserId, @ContactNumber)   
   SET @Id = @@IDENTITY
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.ProfileContactNumberDelete') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.ProfileContactNumberDelete
GO
CREATE PROCEDURE Gaurdian.ProfileContactNumberDelete
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Gaurdian.ProfileContactNumberRead') AND type in (N'P', N'PC'))
DROP PROCEDURE Gaurdian.ProfileContactNumberRead
GO
CREATE PROCEDURE Gaurdian.ProfileContactNumberRead 
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	SELECT 
		0 As Id,
		UserId,		
		ContactNumber
	FROM Gaurdian.ProfileContactNumber
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
