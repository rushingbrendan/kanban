
USE asqlKanban;

DROP PROCEDURE IF EXISTS PlaceOrder
GO
CREATE PROCEDURE PlaceOrder(@orderQuantity int)

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	INSERT INTO dbo.OrderLineTable(timeRequested, quantity)
	VALUES (GETDATE(), @orderQuantity );
	
	
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

-- end
RETURN 0