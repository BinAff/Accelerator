CREATE PROCEDURE Invoice.PaymentUpdate
(
	@Id Numeric(10,0),
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Invoice.Payment
	SET
		InvoiceId = @InvoiceId,
		[Date] = GETDATE()
	WHERE Id = @Id
   
END