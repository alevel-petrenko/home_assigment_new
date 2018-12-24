CREATE TABLE [dbo].[Transactions] (
    [Id]        INT        IDENTITY (1, 1) NOT NULL,
    [ClientId]  INT        NULL,
    [Date]      DATETIME   NULL,
    [Amount]    FLOAT (53) NULL,
    [IsDeleted] BIT        NULL,
    CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Transactions_Client] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Client] ([Id])
);

