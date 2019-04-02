USE asqlKanban;

DROP TABLE IF EXISTS TestTray;
CREATE TABLE TestTray (
	PK_testUnitNumber varchar(10) PRIMARY KEY,
	testTray_id INT NOT NULL,	
	FK_lamp_id INT FOREIGN KEY REFERENCES BuiltFogLampsTable(PK_fog_lamp_id),
	lampPosition INT NOT NULL
);