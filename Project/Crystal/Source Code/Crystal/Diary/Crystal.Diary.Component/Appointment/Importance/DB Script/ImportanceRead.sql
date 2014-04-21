USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceRead]    Script Date: 04/19/2014 11:21:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[ImportanceRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,	[Name]
	FROM Utility.Importance
	WHERE Id = @Id   
	
END
