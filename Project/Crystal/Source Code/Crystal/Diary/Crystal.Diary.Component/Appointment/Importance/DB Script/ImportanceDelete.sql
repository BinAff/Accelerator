USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceDelete]    Script Date: 04/19/2014 11:21:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[ImportanceDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.Importance
	WHERE Id = @Id   
   
END
