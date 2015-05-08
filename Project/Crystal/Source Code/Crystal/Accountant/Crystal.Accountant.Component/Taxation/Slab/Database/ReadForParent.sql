USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Invoice].[SlabReadForParent]    Script Date: 05/27/2014 15:10:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [Invoice].[SlabReadForParent]
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT TaxId Id, Limit, Amount, StartDate, EndDate
	FROM Invoice.Slab
	WHERE TaxId = @ParentId	
	
END