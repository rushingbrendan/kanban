USE asqlKanban;

DROP TABLE IF EXISTS OrderTable;
CREATE TABLE OrderTable (
	FK_orderLine_id INT NOT NULL,	
	timeBuilt DateTime NOT NULL,
	FK_fogLamp_id INT NOT NULL,	
);