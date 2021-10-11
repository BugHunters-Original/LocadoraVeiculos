CREATE TABLE [dbo].[TBTaxasDaLocacao] (
    [IdLocacao] INT NOT NULL,
    [IdTaxa]    INT NOT NULL,
    [Id]        INT NOT NULL,
    CONSTRAINT [PK_TBTaxasDaLocacao] PRIMARY KEY CLUSTERED ([IdLocacao] ASC, [IdTaxa] ASC),
    CONSTRAINT [FK_TBTaxasDaLocacao_TBLocacoes_IdLocacao] FOREIGN KEY ([IdLocacao]) REFERENCES [dbo].[TBLocacoes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TBTaxasDaLocacao_TBServicos_IdTaxa] FOREIGN KEY ([IdTaxa]) REFERENCES [dbo].[TBServicos] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_TBTaxasDaLocacao_IdTaxa]
    ON [dbo].[TBTaxasDaLocacao]([IdTaxa] ASC);

