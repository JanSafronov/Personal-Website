CREATE TABLE [dbo].[Messages] (
    [Id]      INT         NOT NULL,
    [Name]    NCHAR (50)  NOT NULL,
    [Message] NCHAR (500) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

