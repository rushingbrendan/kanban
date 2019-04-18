﻿CREATE PROCEDURE GetFogLamps

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount
	FROM BuiltFogLampsTable;


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