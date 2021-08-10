CREATE TABLE [dbo].[TBTaxasDaLocacao] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [Id_Locacao] INT NULL,
    [Id_Taxa]    INT NULL,
    CONSTRAINT [PK_TBTaxasDaLocacao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBTaxasDaLocacao_TBLocacao] FOREIGN KEY ([Id_Locacao]) REFERENCES [dbo].[TBLocacao] ([Id]),
    CONSTRAINT [FK_TBTaxasDaLocacao_TBTaxasServicos] FOREIGN KEY ([Id_Taxa]) REFERENCES [dbo].[TBTaxasServicos] ([Id])
);

