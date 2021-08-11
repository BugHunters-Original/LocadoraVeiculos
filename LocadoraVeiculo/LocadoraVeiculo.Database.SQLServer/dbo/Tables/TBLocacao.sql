CREATE TABLE [dbo].[TBLocacao] (
    [Id]                   INT          IDENTITY (1, 1) NOT NULL,
    [Id_Condutor]          INT          NULL,
    [Id_Cliente]           INT          NULL,
    [Id_Veiculo]           INT          NULL,
    [Data_saida]           DATE         NULL,
    [Data_retornoEsperado] DATE         NULL,
    [Data_retornoChegada]  DATE         NULL,
    [Valor_Caucao]         FLOAT (53)   NULL,
    [Plano]                VARCHAR (50) NULL,
    CONSTRAINT [PK_TBLocacao] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBLocacao_Id_Condutor] FOREIGN KEY ([Id_Condutor]) REFERENCES [dbo].[TBClienteCPF] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBCliente] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[TBClienteCNPJ] ([Id]),
    CONSTRAINT [FK_TBLocacao_TBVeiculos] FOREIGN KEY ([Id_Veiculo]) REFERENCES [dbo].[TBVeiculos] ([Id])
);



