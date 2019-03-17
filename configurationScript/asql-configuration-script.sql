DROP DATABASE IF EXISTS asqlKanban;

CREATE DATABASE asqlKanban;


USE asqlKanban;
GO

CREATE TABLE ConfigurationTable (
	PK_configurationID INT IDENTITY(1,1) PRIMARY KEY,
	harnessQuantity INT NOT NULL,
	reflectorQuantity INT NOT NULL,
	housingQuantity INT NOT NULL,
	lensQuantity INT NOT NULL,
	bulbQuantity INT NOT NULL,
	runnerCollectionTimeCycle INT NOT NULL,
	numberOfStations INT NOT NULL,
	testTraySize INT NOT NULL,		
	FK_workerTable INT
);
