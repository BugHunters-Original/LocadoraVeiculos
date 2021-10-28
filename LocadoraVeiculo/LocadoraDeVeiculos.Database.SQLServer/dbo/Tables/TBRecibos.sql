CREATE TABLE [dbo].[TBRecibos] (
    [Id]    INT             IDENTITY (1, 1) NOT NULL,
    [Email] NVARCHAR (MAX)  NULL,
    [Ms]    VARBINARY (MAX) NULL,
    CONSTRAINT [PK_TBRecibos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

