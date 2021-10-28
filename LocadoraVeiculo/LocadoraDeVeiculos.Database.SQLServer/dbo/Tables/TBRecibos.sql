CREATE TABLE [dbo].[TBRecibos] (
    [Id]        INT             IDENTITY (1, 1) NOT NULL,
    [LocacaoId] INT             NULL,
    [Pdf]       VARBINARY (MAX) NULL,
    [Status]    INT             NOT NULL,
    CONSTRAINT [PK_TBRecibos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBRecibos_TBLocacoes_LocacaoId] FOREIGN KEY ([LocacaoId]) REFERENCES [dbo].[TBLocacoes] ([Id])
);






GO
CREATE NONCLUSTERED INDEX [IX_TBRecibos_LocacaoId]
    ON [dbo].[TBRecibos]([LocacaoId] ASC);

