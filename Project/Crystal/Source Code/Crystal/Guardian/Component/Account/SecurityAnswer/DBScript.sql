IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'Guardian.SecurityAnswer') AND type in (N'U'))
DROP TABLE Guardian.SecurityAnswer
GO
CREATE TABLE Guardian.SecurityAnswer
(
	Id numeric(10, 0) NOT NULL, 
	UserId numeric(10, 0) NOT NULL, 
	QuestionId numeric(10, 0) NOT NULL, 
	Answer varchar(50) NOT NULL
	PRIMARY KEY (Id)
);
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

CREATE PROCEDURE Guardian.SecurityAnswerRead
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, UserId, QuestionId, Answer 		
	FROM Guardian.SecurityAnswer
	WHERE UserId = @Id   
   
END

GO

CREATE PROCEDURE Guardian.SecurityAnswerUpdate
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

CREATE PROCEDURE Guardian.SecurityAnswerDelete
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Guardian.SecurityAnswer
	WHERE UserId = @Id   
   
END

GO
