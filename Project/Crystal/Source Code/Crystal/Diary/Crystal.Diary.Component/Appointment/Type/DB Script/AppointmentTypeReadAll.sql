USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeReadAll]    Script Date: 04/19/2014 11:21:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentTypeReadAll]
AS
BEGIN
	
	SELECT 
		Id,
		[Name]
	FROM Utility.AppointmentType
   
END
