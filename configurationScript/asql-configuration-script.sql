DROP DATABASE IF EXISTS asqlKanban;
CREATE DATABASE asqlKanban;

USE asqlKanban;

DROP TABLE IF EXISTS Worker;
CREATE TABLE Worker (
	PK_workerType NVARCHAR(5) NOT NULL PRIMARY KEY,
	skillLevel DECIMAL(3,2) NOT NULL,
	assemblyTime DECIMAL(5,2) NOT NULL
);

DROP TABLE IF EXISTS ConfigurationTable;
CREATE TABLE ConfigurationTable (
	PK_configurationID INT IDENTITY(1,1) PRIMARY KEY,
	FK_workerType NVARCHAR(5) REFERENCES Worker(PK_workerType),
	harnessQuantity INT NOT NULL,
	reflectorQuantity INT NOT NULL,
	housingQuantity INT NOT NULL,
	lensQuantity INT NOT NULL,
	bulbQuantity INT NOT NULL,
	runnerCollectionTimeCycle INT NOT NULL,
	numberOfStations INT NOT NULL,
	testTraySize INT NOT NULL
);