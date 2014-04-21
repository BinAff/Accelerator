USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentUpdate]    Script Date: 04/19/2014 11:21:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentUpdate]
(
	@Id Numeric(10,0),
	@ActorId Numeric(10,0),
	@Title Varchar(50),
	@TypeId Numeric(10,0),
	@Start Datetime,
	@End Datetime,
	@Location Varchar(50),
	@Description Varchar(250),
	@ImportanceId Numeric(10,0) = null,
	@Reminder Datetime = null
)
AS
BEGIN
	UPDATE [Utility].[Appointment]
	SET ActorId = @ActorId
		,[Title] = @Title
		,[TypeId] = @TypeId
		,[Start] = @Start
		,[End] = @End
		,[Location] = @Location
		,[Description] = @Description
		,[ImportanceId] = @ImportanceId
		,[Reminder] = @Reminder
	WHERE Id = @Id   
END
