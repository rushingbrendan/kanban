CREATE PROCEDURE GetLastWorkstation 
AS

-- begin try (error checking) 
BEGIN TRY

	SELECT TOP 1 workstationID FROM dbo.WorkstationParts ORDER BY workstationID DESC;
	
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