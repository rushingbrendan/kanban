CREATE TABLE [dbo].[TestTray] (
    [PK_testUnitNumber] VARCHAR (10) NOT NULL,
    [testTray_id]       INT          NOT NULL,
    [FK_lamp_id]        INT          NULL,
    [lampPosition]      INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([PK_testUnitNumber] ASC),
    FOREIGN KEY ([FK_lamp_id]) REFERENCES [dbo].[BuiltFogLampsTable] ([PK_fog_lamp_id])
);

