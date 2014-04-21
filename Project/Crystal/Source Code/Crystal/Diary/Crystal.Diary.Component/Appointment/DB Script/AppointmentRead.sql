USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentRead]    Script Date: 04/19/2014 11:21:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE Id = @Id   
	
END
