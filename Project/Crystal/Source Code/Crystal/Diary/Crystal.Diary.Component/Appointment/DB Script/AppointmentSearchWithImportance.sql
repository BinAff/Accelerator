USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentSearchWithImportance]    Script Date: 04/19/2014 11:21:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentSearchWithImportance]
( 
	@Start Datetime,
	@End Datetime,
	@Importance Numeric(1,0)
)
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
	WHERE [Start] >= @Start AND [Start] <= @End AND [End] <= @End AND ImportanceId = @Importance
   
END
