USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadAll]    Script Date: 05/27/2014 11:27:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Invoice].[SlabReadAll]
AS
BEGIN
	
	SELECT TaxId, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab	
	
END
