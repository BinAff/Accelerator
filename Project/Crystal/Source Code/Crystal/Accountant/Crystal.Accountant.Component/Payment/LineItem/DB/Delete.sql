CREATE PROCEDURE Invoice.PaymentLineItemDelete
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE
	FROM Invoice.PaymentLineItem
	WHERE Id = @Id
   
END