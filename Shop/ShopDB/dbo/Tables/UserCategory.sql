CREATE TABLE [dbo].[UserCategory] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [IsDeleted] BIT           NULL,
    CONSTRAINT [PK_UserCategory] PRIMARY KEY CLUSTERED ([Id] ASC)
);

