USE asqlKanban;

DROP TABLE IF EXISTS RunnerTable;
CREATE TABLE RunnerTable (
	PK_runnerRequest_id INT IDENTITY(1,1) PRIMARY KEY,	
	timeRequested DateTime NOT NULL,
	workStationNumber INT NOT NULL,
	partName varchar(20) NOT NULL
);