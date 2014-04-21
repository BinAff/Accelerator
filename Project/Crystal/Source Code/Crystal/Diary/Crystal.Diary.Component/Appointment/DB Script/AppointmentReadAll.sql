USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentReadAll]    Script Date: 04/19/2014 11:21:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentReadAll]
AS
BEGIN
	
	SELECT Id, ActorId, Title,TypeId,[Start],[End]
           ,[Location],[Description],[ImportanceId],[Reminder]
	FROM Utility.Appointment
   
END
