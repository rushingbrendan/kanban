﻿CREATE PROCEDURE AddWorkstation 
@harnesses int, 
@reflectors int, 
@housings int, 
@lenses int, 
@bulbs int, 
@bezels int
AS

-- begin try (error checking) 
BEGIN TRY
	
	INSERT INTO dbo.WorkstationParts(harnesses, reflectors, housings, lenses, bulbs, bezels)
	VALUES (@harnesses, @reflectors, @housings, @lenses, @bulbs, @bezels);
	
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