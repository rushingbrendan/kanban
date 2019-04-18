CREATE PROCEDURE AddWorkstation 
@harnesses int, 
@reflectors int, 
@housings int, 
@lenses int, 
@bulbs int, 
@bezels int
AS

-- begin try (error checking) 
BEGIN TRY
	
	DECLARE @workstationID int;

	INSERT INTO dbo.WorkstationParts(harnesses, reflectors, housings, lenses, bulbs, bezels)
	VALUES (@harnesses, @reflectors, @housings, @lenses, @bulbs, @bezels);

	SELECT TOP 1 @workstationID=workstationID FROM dbo.WorkstationParts ORDER BY workstationID DESC;

	RETURN @workstationID;
	
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