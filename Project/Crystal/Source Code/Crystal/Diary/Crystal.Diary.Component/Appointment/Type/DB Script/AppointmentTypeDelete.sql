USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeDelete]    Script Date: 04/19/2014 11:21:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentTypeDelete]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE 		
	FROM Utility.AppointmentType
	WHERE Id = @Id   
   
END
