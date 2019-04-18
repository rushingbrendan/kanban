CREATE PROCEDURE AddBuiltFogLamp(@workStationNumber int, @workerSkill varchar(20), @test_pass_status bit )

-- parameters for procedure

AS

-- begin try (error checking) 
BEGIN TRY
	
	INSERT INTO dbo.BuiltFogLampsTable(workStationNumber, workerSkill, timeBuilt, test_pass_status)
	VALUES (@workStationNumber, @workerSkill, GETDATE() ,@test_pass_status);

	DECLARE @lampID int = (SELECT MAX(PK_fog_lamp_id) FROM BuiltFogLampsTable);
	EXEC AddLampToTestTray @lampID;	
	
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