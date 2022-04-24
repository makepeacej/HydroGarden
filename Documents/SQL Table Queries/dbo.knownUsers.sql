CREATE TABLE [dbo].[knownUsers] (
    [Id]       INT        IDENTITY (1, 1) NOT NULL,
    [username] NCHAR (40) NOT NULL,
    [password] NCHAR (40) NOT NULL,
    [email]    NCHAR (40) NOT NULL,
    [ranking]  INT        DEFAULT ((1)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

