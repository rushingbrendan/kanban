

DROP PROCEDURE IF EXISTS GetDefectRate
GO
CREATE PROCEDURE GetDefectRate(@employeeTimeInput nchar(20))

-- parameters for procedure

AS


	DECLARE @returnedDefectRate decimal (2,2)
	
	-- declaration of variables used in procedure
	IF (@employeeTimeInput = 'Rookie')
		SELECT @returnedDefectRate = ( SELECT rookieDefectRate FROM ConfigurationTable
		WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable));

	ELSE IF (@employeeTimeInput = 'Normal')
		 SELECT @returnedDefectRate = (SELECT normalDefectRate FROM ConfigurationTable AS returnedDefectRate
		WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable));

	ELSE IF (@employeeTimeInput = 'Experienced')
		SELECT @returnedDefectRate = (SELECT experiencedDefectRate FROM ConfigurationTable AS returnedDefectRate
		WHERE PK_configurationID = (SELECT MAX(PK_configurationID) FROM ConfigurationTable));

-- end
SELECT @returnedDefectRate