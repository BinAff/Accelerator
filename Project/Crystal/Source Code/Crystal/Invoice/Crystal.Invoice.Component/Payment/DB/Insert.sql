CREATE PROCEDURE Invoice.PaymentInsert
(  	
	@InvoiceId Numeric(10,0) = null,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	INSERT INTO Invoice.Payment(InvoiceId, [Date])
	VALUES(@InvoiceId,GETDATE())
   
	SET @Id = @@IDENTITY
	
END