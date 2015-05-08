CREATE PROCEDURE Invoice.PaymentLineItemRead
(
	@Id Numeric(10,0)
)
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
	WHERE Id = @Id   
	
END