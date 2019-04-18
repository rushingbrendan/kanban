CREATE PROCEDURE GetFogLampBuiltData

-- parameters for procedure


AS


-- begin try (error checking) 
BEGIN TRY
	
	-- declaration of variables used in procedure

	--get 12 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount12
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-11,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-12,getdate());

	--get 11 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount11
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-10,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-11,getdate());

	--get 10 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount10
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-9,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-10,getdate());

	--get 9 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount9
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-8,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-9,getdate());

	--get 8 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount8
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-7,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-8,getdate());

	--get 7 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount7
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-6,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-7,getdate());

	--get 6 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount6
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-5,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-6,getdate());

	--get 5 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount5
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-4,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-5,getdate());

	--get 4 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount4
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-3,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-4,getdate());

	--get 3 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount3
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-2,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-3,getdate());

	--get 2 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount2
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-1,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-2,getdate());

	--get 1 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampCount1
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 1 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-0,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-1,getdate());

--get 12 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad12
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-11,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-12,getdate());

	--get 11 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad11
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-10,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-11,getdate());

	--get 10 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad10
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-9,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-10,getdate());

	--get 9 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad9
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-8,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-9,getdate());

	--get 8 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad8
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-7,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-8,getdate());

	--get 7 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad7
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-6,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-7,getdate());

	--get 6 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad6
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-5,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-6,getdate());

	--get 5 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad5
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-4,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-5,getdate());

	--get 4 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad4
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-3,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-4,getdate());

	--get 3 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad3
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-2,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-3,getdate());

	--get 2 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad2
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-1,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-2,getdate());

	--get 1 hours ago
	SELECT COUNT([dbo].BuiltFogLampsTable.PK_fog_lamp_id) AS fogLampBad1
	FROM BuiltFogLampsTable
	WHERE BuiltFogLampsTable.test_pass_status = 0 
			AND BuiltFogLampsTable.timeBuilt < dateadd(HH,-0,getdate())
			AND BuiltFogLampsTable.timeBuilt > dateadd(HH,-1,getdate());



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