CREATE TABLE [dbo].[OrderTable] (
    [FK_orderLine_id] INT      NOT NULL,
    [timeBuilt]       DATETIME NOT NULL,
    [FK_fogLamp_id]   INT      NOT NULL
);

