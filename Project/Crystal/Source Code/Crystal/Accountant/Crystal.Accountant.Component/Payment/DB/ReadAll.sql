CREATE PROCEDURE Invoice.PaymentReadAll
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Invoice.Payment WITH (NOLOCK)
   
END