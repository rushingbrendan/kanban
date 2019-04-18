CREATE TABLE [dbo].[OrderLineTable] (
    [PK_orderLine_id] INT      IDENTITY (1, 1) NOT NULL,
    [timeRequested]   DATETIME NOT NULL,
    [quantity]        INT      NOT NULL,
    [quantityBuilt]   INT      DEFAULT ((0)) NOT NULL,
    [complete]        BIT      DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([PK_orderLine_id] ASC)
);

