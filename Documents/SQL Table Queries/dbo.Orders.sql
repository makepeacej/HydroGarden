CREATE TABLE [dbo].[Orders] (
    [orderID]       INT        IDENTITY (1, 1) NOT NULL,
    [custID]        INT        NULL,
    [datePlaced]    NCHAR (20) NULL,
    [dateScheduled] NCHAR (20) NULL,
    [isCompleted]   BIT        NULL,
    [productID]     INT        NULL,
    PRIMARY KEY CLUSTERED ([orderID] ASC),
    CONSTRAINT [FK_custID] FOREIGN KEY ([custID]) REFERENCES [dbo].[knownUsers] ([Id]),
    CONSTRAINT [FK_productID] FOREIGN KEY ([productID]) REFERENCES [dbo].[Products] ([productID])
);

