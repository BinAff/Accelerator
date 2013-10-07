USE DevelopmentRND

CREATE PROCEDURE [dbo].[IdentityProofTypeInsert]
(  
	@Name Varchar(50),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO IdentityProofType([Name])
	VALUES(@Name)
   
	SET @Id = @@IDENTITY
END

CREATE PROCEDURE [dbo].[IdentityProofTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM IdentityProofType
	WHERE Id = @Id   
	
END

CREATE PROCEDURE [dbo].[IdentityProofTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM IdentityProofType
   
END

CREATE PROCEDURE [dbo].[IdentityProofTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE IdentityProofType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END

CREATE PROCEDURE [dbo].[IdentityProofTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM IdentityProofType
	WHERE Id = @Id   
   
END