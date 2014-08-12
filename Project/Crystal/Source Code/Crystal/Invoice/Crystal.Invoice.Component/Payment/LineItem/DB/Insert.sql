CREATE PROCEDURE Invoice.PaymentLineItemInsert
(  	
	@Reference Varchar(16),
	@Remark Varchar(255),
	@Amount money,
	@PaymentTypeId Numeric(10,0),
	@PaymentId Numeric(10,0),
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN
	
	INSERT INTO Invoice.PaymentLineItem(PaymentTypeId, Reference, Remark, Amount, PaymentId)
	VALUES(@PaymentTypeId, @Reference, @Remark, @Amount, @PaymentId)
    
	SET @Id = @@IDENTITY
END
