CREATE PROCEDURE Invoice.PaymentRead
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, SerialNumber, [Date], InvoiceId
	FROM Invoice.Payment WITH (NOLOCK)
	WHERE Id = @Id
   
END