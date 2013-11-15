IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.[Profile]') AND type in (N'U'))
DROP TABLE Guardian.[Profile]
GO
CREATE TABLE Guardian.[Profile]
(
	UserId numeric(10, 0) NOT NULL, 
	Initial numeric(10, 0) NOT NULL, 
	FirstName varchar(50) NOT NULL, 
	MiddleName varchar(50) NULL, 
	LastName varchar(50) NOT NULL, 
	Dob datetime NOT NULL, 
	PRIMARY KEY (UserId)
);
ALTER TABLE Guardian.[Profile] ADD CONSTRAINT FKProfile713980 FOREIGN KEY (Initial) REFERENCES Initial (Id);
ALTER TABLE Guardian.[Profile] ADD CONSTRAINT FKProfile288245 FOREIGN KEY (UserId) REFERENCES [User] (Id);



IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.ProfileRead') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.ProfileRead
GO
CREATE PROCEDURE Guardian.ProfileRead
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT UserId, Initial, FirstName, MiddleName, LastName, Dob
	FROM Guardian.[Profile]
	WHERE UserId = @Id
   
END
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.[ProfileUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.[ProfileUpdate]
GO
CREATE PROCEDURE Guardian.[ProfileUpdate]
(
	@UserId Numeric(10,0),	
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
	Select @Cnt = COUNT(*) From [Profile] Where UserId = @UserId
	If @Cnt > 0
	Begin	
		UPDATE Guardian.[Profile]
		SET	
			Initial = @Initial,
			FirstName = @FirstName,
			MiddleName = @MiddleName,
			LastName = @LastName,
			Dob = @Dob
		WHERE UserId = @UserId
	End
	Else
	Begin
		Insert into [Profile](UserId,Initial,FirstName,MiddleName,LastName,Dob)
		values(@UserId,@Initial,@FirstName,ISNULL(@MiddleName,''),@LastName,@Dob)
	End
   
END

GO

/****** Object:  StoredProcedure Guardian.[ProfileDelete]    Script Date: 09/12/2012 00:01:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.[ProfileDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE Guardian.[ProfileDelete]
GO
CREATE PROCEDURE Guardian.[ProfileDelete]
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


Guardian.ProfileRead 1