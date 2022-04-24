CREATE TABLE [dbo].[Products] (
    [productID]    INT          IDENTITY (1, 1) NOT NULL,
    [name]         VARCHAR (40) NULL,
    [price]        FLOAT (53)   NULL,
    [availability] BIT          NULL,
    PRIMARY KEY CLUSTERED ([productID] ASC)
);

