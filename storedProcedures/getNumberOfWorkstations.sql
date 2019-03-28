

DROP PROCEDURE IF EXISTS GetNumberOfWorkStations
GO
CREATE PROCEDURE GetNumberOfWorkStations

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	-- declaration of variables used in procedure

	SELECT numberOfStations FROM ConfigurationTable
	WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable);


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