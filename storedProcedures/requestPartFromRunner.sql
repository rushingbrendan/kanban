

DROP PROCEDURE IF EXISTS RequestPartFromRunner
GO
CREATE PROCEDURE RequestPartFromRunner(@partName varchar(20), @workStationNumber int)

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	INSERT INTO dbo.RunnerTable(timeRequested, workStationNumber, partName)
	VALUES (GETDATE(), @workStationNumber, @partName);
	
	
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