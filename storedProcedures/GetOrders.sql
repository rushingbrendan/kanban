CREATE PROCEDURE GetOrders(@complete bit = 1)

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY

	SELECT PK_orderLine_id, quantity, quantityBuilt, complete
	FROM OrderLineTable
	WHERE complete=@complete;


END TRY

-- catch any errors
BEGIN CATCH
	SELECT ErrorLine= ERROR_LINE(), 
	ErrorMessage= ERROR_MESSAGE(), 
	ErrorNumber= ERROR_NUMBER(), 
	ErrorProcedure= ERROR_PROCEDURE(), 
	ErrorSeverity= ERROR_SEVERITY(), 
	ErrorState= ERROR_STATE()
END CATCH