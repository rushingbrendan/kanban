
USE asqlKanban;


--  DROP TABLE IF EXISTS ConfigurationTable;
CREATE TABLE BuiltFogLampsTable (
	PK_fog_lamp_id INT IDENTITY(1,1) PRIMARY KEY,	
	timeBuilt DateTime NOT NULL,
	workerSkill varchar(20),
	workStationNumber INT,
	test_pass_status BIT
);