CREATE PROCEDURE Invoice.PaymentLineItemReadAll
AS
BEGIN
	
	SELECT
		Id,
		Reference,
		Amount,
		PaymentTypeId,
		Remark,
		PaymentId
	FROM Invoice.PaymentLineItem
	
END