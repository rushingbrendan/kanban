﻿CREATE PROCEDURE GetEmployeeAssemblyTime(@employeeTimeInput varchar(20))

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	-- declaration of variables used in procedure
	IF (@employeeTimeInput = 'Rookie')
		SELECT rookieAssemblyTime FROM ConfigurationTable
		WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable);

	ELSE IF (@employeeTimeInput = 'Normal')
		SELECT normalAssemblyTime FROM ConfigurationTable
		WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable);

	ELSE IF (@employeeTimeInput = 'Experienced')
		SELECT experiencedAssemblyTime FROM ConfigurationTable
		WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable);

	ELSE
		RETURN -1

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