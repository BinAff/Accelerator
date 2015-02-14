CREATE PROCEDURE Invoice.PaymentUpdate
(
	@Id Numeric(10,0),
	@Date DateTime,
	@InvoiceId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Invoice.Payment
	SET
		InvoiceId = @InvoiceId,
		[Date] = @Date
	WHERE Id = @Id
   
END