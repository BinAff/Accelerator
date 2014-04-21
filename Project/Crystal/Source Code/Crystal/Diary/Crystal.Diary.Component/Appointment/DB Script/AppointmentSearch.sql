USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearch]    Script Date: 04/19/2014 11:21:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentSearch]
( 
	@Start Datetime,
	@End Datetime
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE [Start] >= @Start AND [Start] <= @End AND [End] <= @End
   
END
