CREATE TABLE [dbo].[Client] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (MAX) NULL,
    [IsDeleted]  BIT            NULL,
    [CategoryId] INT            NULL,
    CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Client_UserCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[UserCategory] ([Id])
);



