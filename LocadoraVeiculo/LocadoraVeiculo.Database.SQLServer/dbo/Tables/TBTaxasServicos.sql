CREATE TABLE [dbo].[TBTaxasServicos] (
    [IdLocacao] INT NOT NULL,
    [IdTaxa]    INT NOT NULL,
    [Id]        INT NOT NULL,
    CONSTRAINT [PK_TBTaxasServicos] PRIMARY KEY CLUSTERED ([IdLocacao] ASC, [IdTaxa] ASC),
    CONSTRAINT [FK_TBTaxasServicos_Locacoes_IdLocacao] FOREIGN KEY ([IdLocacao]) REFERENCES [dbo].[Locacoes] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TBTaxasServicos_TBServicos_IdTaxa] FOREIGN KEY ([IdTaxa]) REFERENCES [dbo].[TBServicos] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TBTaxasServicos_IdTaxa]
    ON [dbo].[TBTaxasServicos]([IdTaxa] ASC);

