CREATE PROCEDURE Invoice.PaymentReadAll
AS
BEGIN
	
	SELECT Id, [Date], InvoiceId
	FROM Invoice.Payment
   
END