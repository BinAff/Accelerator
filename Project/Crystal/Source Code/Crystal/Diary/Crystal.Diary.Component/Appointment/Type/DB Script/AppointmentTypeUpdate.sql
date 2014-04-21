USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Utility].[AppointmentTypeUpdate]    Script Date: 04/19/2014 11:21:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Utility].[AppointmentTypeUpdate]
(
	@Id Numeric(10,0),
	@Name Varchar(50)
)
AS
BEGIN
	
	UPDATE Utility.AppointmentType
	SET	
		[Name] = @Name	
	WHERE Id = @Id
   
END
