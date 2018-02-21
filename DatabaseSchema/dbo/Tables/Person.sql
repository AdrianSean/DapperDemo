CREATE TABLE [dbo].[Person] (
    [Id]        UNIQUEIDENTIFIER DEFAULT (newid()) NOT NULL,
    [FirstName] VARCHAR (50)     NOT NULL,
    [LastName]  VARCHAR (50)     NOT NULL,
    [Age]       INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

