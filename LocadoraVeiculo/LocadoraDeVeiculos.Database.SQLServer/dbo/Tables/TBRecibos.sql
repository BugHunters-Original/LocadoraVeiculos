CREATE TABLE [dbo].[TBRecibos] (
    [Id]     INT             IDENTITY (1, 1) NOT NULL,
    [Email]  NVARCHAR (MAX)  NULL,
    [Pdf]    VARBINARY (MAX) NULL,
    [Status] INT             NOT NULL,
    CONSTRAINT [PK_TBRecibos] PRIMARY KEY CLUSTERED ([Id] ASC)
);



