CREATE TABLE [dbo].[BuiltFogLampsTable] (
    [PK_fog_lamp_id]    INT          IDENTITY (1, 1) NOT NULL,
    [timeBuilt]         DATETIME     NOT NULL,
    [workerSkill]       VARCHAR (20) NULL,
    [workStationNumber] INT          NULL,
    [test_pass_status]  BIT          NULL,
    PRIMARY KEY CLUSTERED ([PK_fog_lamp_id] ASC)
);

