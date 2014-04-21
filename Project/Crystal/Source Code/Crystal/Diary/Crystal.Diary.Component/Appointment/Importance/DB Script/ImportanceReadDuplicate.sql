USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadDuplicate]    Script Date: 04/19/2014 11:21:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[ImportanceReadDuplicate]
(
	@Name VARCHAR(150)		
)
AS
BEGIN
	SELECT Id	
	FROM Utility.Importance
	WHERE Name = @Name				
END
