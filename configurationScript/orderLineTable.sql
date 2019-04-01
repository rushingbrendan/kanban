
USE asqlKanban;


--  DROP TABLE IF EXISTS ConfigurationTable;
CREATE TABLE OrderLineTable (
	PK_orderLine_id INT IDENTITY(1,1) PRIMARY KEY,	
	timeRequested DateTime NOT NULL,
	quantity INT NOT NULL,
	quantityBuilt INT	
);