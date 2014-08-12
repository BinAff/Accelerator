CREATE PROCEDURE Invoice.PaymentLineItemReadForParent
(
	@ParentId Numeric(10,0)
)
AS
BEGIN
	
	SELECT Id, Reference, Amount, PaymentTypeId,
		Remark, PaymentId
	FROM Invoice.PaymentLineItem
	WHERE PaymentId = @ParentId	
	
END