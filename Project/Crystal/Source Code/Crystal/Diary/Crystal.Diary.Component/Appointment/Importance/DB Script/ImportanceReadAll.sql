USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[ImportanceReadAll]    Script Date: 04/19/2014 11:21:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[ImportanceReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM Utility.Importance
   
END
