CREATE TABLE [dbo].[AmountOrdered] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [custID]    INT        NOT NULL,
    [orderID]   INT        NOT NULL,
    [productID] INT        NOT NULL,
    [quantity]  FLOAT (53) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_AssignedCust] FOREIGN KEY ([custID]) REFERENCES [dbo].[knownUsers] ([Id]),
    CONSTRAINT [FK_AssignedOrder] FOREIGN KEY ([orderID]) REFERENCES [dbo].[Orders] ([orderID]),
    CONSTRAINT [FK_AssignedProduct] FOREIGN KEY ([productID]) REFERENCES [dbo].[Products] ([productID])
);

