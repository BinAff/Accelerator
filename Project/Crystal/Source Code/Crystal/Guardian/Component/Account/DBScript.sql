IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserResetPassword]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserResetPassword]
GO
CREATE PROCEDURE [dbo].[UserResetPassword]
(
	@Id Numeric(10,0),
	@Password Varchar(50)
)
AS
BEGIN
	
	UPDATE [user]
	SET	
		[Password] = @Password	
	WHERE Id = @Id
   
END

/****** Object:  StoredProcedure [dbo].[UserInsert]    Script Date: 09/06/2012 21:05:46 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserInsert]
GO
CREATE PROCEDURE [dbo].[UserInsert]
(  
   @LoginId Varchar(15),   
   @Password Varchar(127),
   --@RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
	
   INSERT INTO [User](LoginId, Password)
   VALUES (@LoginId, @Password)
   
   SET @Id = @@IDENTITY
   
   --INSERT INTO User_Role (UserId, RoleId)
   --VALUES(@Id, @RoleId)

END

GO

/****** Object:  StoredProcedure [dbo].[UserRoleInsert]    Script Date: 09/06/2012 21:07:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserRoleInsert]
GO
CREATE PROCEDURE [dbo].[UserRoleInsert]
(  
   @UserId Numeric(10,0),
   @RoleId Numeric(10,0),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
   
   INSERT INTO User_Role (UserId, RoleId)
   VALUES(@UserId, @RoleId)
   
   SET @Id = @@IDENTITY

END

GO

/****** Object:  StoredProcedure [dbo].[UserRoleDelete]    Script Date: 09/08/2012 13:16:04 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserRoleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserRoleDelete]
GO
CREATE PROCEDURE [dbo].[UserRoleDelete]
(
	@UserId Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM User_Role
	WHERE UserId = @UserId   
   
END

GO

/****** Object:  StoredProcedure [dbo].[UserReadAll]    Script Date: 09/08/2012 13:18:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserReadAll]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserReadAll]
GO
CREATE PROCEDURE [dbo].[UserReadAll]
AS
BEGIN
	
   SELECT 
		Id,
		LoginId,
		[Password]
   FROM [User]
   Where LoginId != 'support'
   
   SELECT 
	UserId, 
	RoleId
   FROm User_Role 
   
END

GO

/****** Object:  StoredProcedure [dbo].[UserUpdate]    Script Date: 09/09/2012 19:59:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserUpdate]
GO
CREATE PROCEDURE [dbo].[UserUpdate]
(
   @Id Numeric(10,0),
   @LoginId Varchar(15),
   @Password Varchar(127)
   --@RoleId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE [User]
	SET	
		LoginId = @LoginId,
		Password = @Password	
	WHERE Id = @Id

	--UPDATE User_Role
	--SET
	--	RoleId	= @RoleId
	--WHERE UserId = @Id
   
END

GO

/****** Object:  Table [dbo].[ProfileContactNumber]    Script Date: 09/10/2012 23:30:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProfileContactNumber]') AND type in (N'U'))
DROP TABLE [dbo].[ProfileContactNumber]
GO
CREATE TABLE [dbo].[ProfileContactNumber](
	[UserId] [numeric](10, 0) NOT NULL,
	[ContactNumber] [varchar](50) NOT NULL
) ON [PRIMARY]
ALTER TABLE [dbo].[ProfileContactNumber]  WITH CHECK ADD  CONSTRAINT [ProfileContactNumber_FK_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ALTER TABLE [dbo].[ProfileContactNumber] CHECK CONSTRAINT [ProfileContactNumber_FK_UserId]
GO

/****** Object:  StoredProcedure [dbo].[UserContactNumberInsert]    Script Date: 09/10/2012 23:39:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserContactNumberInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserContactNumberInsert]
GO
Create PROCEDURE [dbo].[UserContactNumberInsert]
(  
   @UserId Numeric(10,0),
   @ContactNumber varchar(50),
   @Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
   
   INSERT INTO ProfileContactNumber(UserId, ContactNumber)
   VALUES(@UserId, @ContactNumber)
   
   SET @Id = @@IDENTITY

END

GO

/****** Object:  StoredProcedure [dbo].[UserContactNumberDelete]    Script Date: 09/10/2012 23:40:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserContactNumberDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserContactNumberDelete]
GO
CREATE PROCEDURE [dbo].[UserContactNumberDelete]
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

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UserDelete]
GO
CREATE PROCEDURE [dbo].[UserDelete]
(
   @Id Numeric(10,0)
)
AS
BEGIN

   DELETE FROM [User]
   WHERE Id = @Id
   
END

/****** Object:  StoredProcedure [dbo].[ProfileContactNumberRead]    Script Date: 09/11/2012 00:37:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProfileContactNumberRead]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[ProfileContactNumberRead]
GO
CREATE PROCEDURE [dbo].[ProfileContactNumberRead] 
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		0 As Id,
		UserId,		
		ContactNumber
	FROM ProfileContactNumber
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
