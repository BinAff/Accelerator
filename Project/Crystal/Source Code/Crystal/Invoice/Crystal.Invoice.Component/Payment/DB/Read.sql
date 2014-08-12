CREATE PROCEDURE Invoice.PaymentRead
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, [Date], InvoiceId
	FROM Invoice.Payment
	WHERE Id = @Id
   
END