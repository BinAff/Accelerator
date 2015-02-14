CREATE PROCEDURE Invoice.PaymentInsert
(  	
	@InvoiceId Numeric(10,0) = null,
	@ReceiptNumber Varchar(50),
	@Date DateTime,
	@Id  Numeric(10,0) OUTPUT
)
AS
BEGIN	
	
	BEGIN TRANSACTION
	
	DECLARE @Max Int
	SELECT @Max = MAX(SerialNumber) + 1 FROM Invoice.Payment WHERE Date = @Date
	
	INSERT INTO Invoice.Payment(SerialNumber, [Date], InvoiceId)
	VALUES(@Max, @Date, @InvoiceId)
    
    COMMIT TRANSACTION
    
	SET @Id = @@IDENTITY
	
END