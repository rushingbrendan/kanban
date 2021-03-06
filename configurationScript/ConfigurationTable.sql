﻿CREATE TABLE [dbo].[ConfigurationTable] (
    [PK_configurationID]        INT             IDENTITY (1, 1) NOT NULL,
    [harnessQuantity]           INT             NOT NULL,
    [reflectorQuantity]         INT             NOT NULL,
    [housingQuantity]           INT             NOT NULL,
    [lensQuantity]              INT             NOT NULL,
    [bulbQuantity]              INT             NOT NULL,
    [bezelQuantity]             INT             NOT NULL,
    [runnerCollectionTimeCycle] INT             NOT NULL,
    [numberOfStations]          INT             NOT NULL,
    [testTraySize]              INT             NOT NULL,
    [rookieDefectRate]          DECIMAL (10, 2) NOT NULL,
    [normalDefectRate]          DECIMAL (10, 2) NOT NULL,
    [experiencedDefectRate]     DECIMAL (10, 2) NOT NULL,
    [rookieAssemblyTime]        INT             NOT NULL,
    [normalAssemblyTime]        INT             NOT NULL,
    [experiencedAssemblyTime]   INT             NOT NULL,
    [timeScale]                 INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([PK_configurationID] ASC)
);

