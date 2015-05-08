USE [AutoTourism]
GO
/****** Object:  StoredProcedure [Invoice].[TaxationRead]    Script Date: 05/27/2014 10:58:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE Invoice.TaxationRead
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id,	Name, Amount, IsPercentage
	FROM Invoice.Taxation
	WHERE Id = @Id
	
	SELECT *
	FROM Invoice.TaxDetails
	WHERE TaxDefId = @Id
	
END
