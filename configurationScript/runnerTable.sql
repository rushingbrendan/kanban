CREATE TABLE [dbo].[RunnerTable] (
    [PK_runnerRequest_id] INT          IDENTITY (1, 1) NOT NULL,
    [timeRequested]       DATETIME     NOT NULL,
    [workStationNumber]   INT          NOT NULL,
    [partName]            VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([PK_runnerRequest_id] ASC)
);

