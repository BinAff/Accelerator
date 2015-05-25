USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Lodge].[RoomReservationDetailsInsert]    Script Date: 05/25/2015 14:39:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Lodge].[RoomReservationDetailsInsert]
(  
	@RoomId  Numeric(10,0),
	@ReservationId  Numeric(10,0),
	@ExtraAccomodation Int = 0,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Lodge.RoomReservationDetails(RoomId, ReservationId, ExtraAccomodation)
	VALUES(@RoomId, @ReservationId, @ExtraAccomodation)
   
	SET @Id = @@IDENTITY
	
END
GO

DROP PROCEDURE [Lodge].[RoomReservationRoomLinkRead]
GO
CREATE PROCEDURE [Lodge].[RoomReservationDetailsRead]
(
   @ReservationId Numeric(10,0)
)
AS
BEGIN
	
   SELECT Id, RoomId, ReservationId, ExtraAccomodation
   FROM Lodge.RoomReservationDetails WITH (NOLOCK)
   WHERE ReservationId = @ReservationId

END
GO