USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Invoice].[SlabRead]    Script Date: 05/27/2014 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Invoice].[SlabRead]
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab
	WHERE TaxId = @Id	
	
END	
	
END