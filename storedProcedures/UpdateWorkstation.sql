CREATE PROCEDURE UpdateWorkstation 
@stationID int,
@harnesses int, 
@reflectors int, 
@housings int, 
@lenses int, 
@bulbs int, 
@bezels int
AS

-- begin try (error checking) 
BEGIN TRY

	UPDATE dbo.WorkstationParts
	SET harnesses=@harnesses, reflectors=@reflectors, housings=@housings, lenses=@lenses, bulbs=@bulbs, bezels=@bezels
	WHERE workstationID=@stationID;
	
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