USE [AutoTourism]
GO

/****** Object:  StoredProcedure [Lodge].[CheckinUpdateCheckOut]    Script Date: 05/23/2015 23:31:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Lodge].[CheckinUpdateCheckOut]') AND type in (N'P', N'PC'))
DROP PROCEDURE [Lodge].[CheckinUpdateCheckOut]
GO

USE [AutoTourism]
GO

/****** Object:  StoredProcedure [Lodge].[CheckinUpdateCheckOut]    Script Date: 05/23/2015 23:31:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Lodge].[CheckinUpdateCheckOut]
(	
	@ProductId Numeric(10,0),
	@StatusId Numeric(10,0)
	--@CompletionTime DateTime OUTPUT
)
AS
BEGIN
	Declare @CompletionTime DateTime
	SET @CompletionTime = GETDATE()
	UPDATE Lodge.CheckIn
	SET	StatusId = @StatusId,
		CheckOutDate = @CompletionTime
	WHERE Id = @ProductId
	 
	SELECT @CompletionTime
END

GO


