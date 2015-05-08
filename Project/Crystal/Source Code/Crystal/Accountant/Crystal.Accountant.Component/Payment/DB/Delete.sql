CREATE PROCEDURE Invoice.PaymentDelete
(
	@Id Numeric(10,0)
)
AS
BEGIN
	
	DELETE FROM Invoice.Payment
	WHERE Id = @Id  
   
END