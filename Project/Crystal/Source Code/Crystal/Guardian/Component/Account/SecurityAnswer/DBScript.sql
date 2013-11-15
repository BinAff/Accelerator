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

CREATE PROCEDURE [dbo].[SecurityAnswerUpdate]
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

/****** Object:  StoredProcedure [dbo].[SecurityAnswerDelete]    Script Date: 09/12/2012 00:00:23 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SecurityAnswerDelete]
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
