USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeRead]    Script Date: 04/19/2014 11:21:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentTypeRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT 
		Id,	[Name]
	FROM Utility.AppointmentType
	WHERE Id = @Id   
	
END
