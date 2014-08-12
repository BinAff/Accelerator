CREATE PROCEDURE Invoice.PaymentLineItemUpdate
(
	@Id Numeric(10,0),
	@Reference Varchar(16),
	@Amount Numeric(10,2),
	@PaymentTypeId Numeric(10,0),
	@Remark Varchar(255),
	@PaymentId Numeric(10,0)
)
AS
BEGIN
	
	UPDATE Invoice.PaymentLineItem
	SET			
		Reference = @Reference,
		Amount = @Amount,
		PaymentTypeId = @PaymentTypeId,
		Remark = @Remark,
		PaymentId = @PaymentId
	WHERE Id = @Id
   
END