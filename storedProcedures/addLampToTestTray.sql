CREATE PROCEDURE AddLampToTestTray(@fogLampID int)

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	DECLARE @lampsPerTray int = 60;
	DECLARE @latestTestTray int = (SELECT MAX(testTray_id) FROM TestTray);
	DECLARE @lampCount int;
	DECLARE @trayID int;
	DECLARE @testUnitNumber varchar(10);

	IF @latestTestTray IS NULL
		SET @latestTestTray = 1;

	SELECT @lampCount = (SELECT MAX(lampPosition) FROM TestTray WHERE testTray_id = @latestTestTray);

	IF @lampCount IS NULL
		SET @lampCount = 0;

	IF @lampCount < @lampsPerTray
		SET @lampCount += 1;
	ELSE
	BEGIN
		SET @latestTestTray += 1;
		SET @lampCount = 1;
	END

	SET @testUnitNumber = 'FL' + (SELECT RIGHT('000000'+CAST(@latestTestTray AS varchar(6)),6)) + (SELECT RIGHT('00'+CAST(@lampCount AS varchar(2)), 2));

	INSERT INTO TestTray(PK_testUnitNumber, testTray_id, FK_lamp_id, lampPosition)
	VALUES(@testUnitNumber, @latestTestTray, @fogLampID, @lampCount);

	
	
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