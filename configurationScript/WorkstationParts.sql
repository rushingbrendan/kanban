CREATE TABLE [dbo].[WorkstationParts] (
    [workstationID] INT IDENTITY (1, 1) NOT NULL,
    [harnesses]     INT DEFAULT ((0)) NOT NULL,
    [reflectors]    INT DEFAULT ((0)) NOT NULL,
    [housings]      INT DEFAULT ((0)) NOT NULL,
    [lenses]        INT DEFAULT ((0)) NOT NULL,
    [bulbs]         INT DEFAULT ((0)) NOT NULL,
    [bezels]        INT DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([workstationID] ASC)
);

