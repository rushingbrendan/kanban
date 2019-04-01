
USE asqlKanban;


--  DROP TABLE IF EXISTS ConfigurationTable;
CREATE TABLE OrderTable (
	PK_order_id INT IDENTITY(1,1) PRIMARY KEY,	
	FK_orderLine_id INT NOT NULL,	
	timeBuilt DateTime NOT NULL,
	FK_fogLamp_id INT NOT NULL,	
);