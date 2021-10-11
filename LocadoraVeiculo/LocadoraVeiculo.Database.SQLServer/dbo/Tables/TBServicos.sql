CREATE TABLE [dbo].[TBServicos] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [Preco]       FLOAT (53)   NOT NULL,
    [TipoCalculo] INT          NOT NULL,
    [LocacaoId]   INT          NULL,
    CONSTRAINT [PK_TBServicos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBServicos_TBLocacoes_LocacaoId] FOREIGN KEY ([LocacaoId]) REFERENCES [dbo].[TBLocacoes] ([Id])
);




GO
CREATE NONCLUSTERED INDEX [IX_TBServicos_LocacaoId]
    ON [dbo].[TBServicos]([LocacaoId] ASC);

