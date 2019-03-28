DROP DATABASE IF EXISTS asqlKanban;
CREATE DATABASE asqlKanban;

USE asqlKanban;


--  DROP TABLE IF EXISTS ConfigurationTable;
CREATE TABLE ConfigurationTable (
	PK_configurationID INT IDENTITY(1,1) PRIMARY KEY,	
	harnessQuantity INT NOT NULL,
	reflectorQuantity INT NOT NULL,
	housingQuantity INT NOT NULL,
	lensQuantity INT NOT NULL,
	bulbQuantity INT NOT NULL,
	bezelQuantity INT NOT NULL,
	runnerCollectionTimeCycle INT NOT NULL,
	numberOfStations INT NOT NULL,
	testTraySize INT NOT NULL,
	rookieDefectRate DECIMAL(10,2) NOT NULL,
	normalDefectRate DECIMAL(10,2) NOT NULL,
	experiencedDefectRate DECIMAL(10,2) NOT NULL,
	rookieAssemblyTime INT NOT NULL,
	normalAssemblyTime INT NOT NULL,
	experiencedAssemblyTime INT NOT NULL,
	timeScale INT NOT NULL

);