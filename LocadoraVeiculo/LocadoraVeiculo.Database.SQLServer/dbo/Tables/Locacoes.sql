CREATE TABLE [dbo].[Locacoes] (
    [Id]               INT             IDENTITY (1, 1) NOT NULL,
    [IdCliente]        INT             NOT NULL,
    [ClienteId]        INT             NULL,
    [IdVeiculo]        INT             NOT NULL,
    [VeiculoId]        INT             NULL,
    [IdDesconto]       INT             NOT NULL,
    [DescontoId]       INT             NULL,
    [IdCondutor]       INT             NOT NULL,
    [CondutorId]       INT             NULL,
    [DataSaida]        DATETIME2 (7)   NOT NULL,
    [DataRetorno]      DATETIME2 (7)   NOT NULL,
    [TipoLocacao]      NVARCHAR (MAX)  NULL,
    [StatusLocacao]    NVARCHAR (MAX)  NULL,
    [TipoCliente]      INT             NOT NULL,
    [Dias]             INT             NOT NULL,
    [PrecoServicos]    DECIMAL (18, 2) NULL,
    [PrecoCombustivel] DECIMAL (18, 2) NULL,
    [PrecoPlano]       DECIMAL (18, 2) NULL,
    [PrecoTotal]       DECIMAL (18, 2) NULL,
    CONSTRAINT [PK_Locacoes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Locacoes_TBClientesBase_ClienteId] FOREIGN KEY ([ClienteId]) REFERENCES [dbo].[TBClientesBase] ([Id]),
    CONSTRAINT [FK_Locacoes_TBClientesCPF_CondutorId] FOREIGN KEY ([CondutorId]) REFERENCES [dbo].[TBClientesCPF] ([Id]),
    CONSTRAINT [FK_Locacoes_TBDescontos_DescontoId] FOREIGN KEY ([DescontoId]) REFERENCES [dbo].[TBDescontos] ([Id]),
    CONSTRAINT [FK_Locacoes_TBVeiculos_VeiculoId] FOREIGN KEY ([VeiculoId]) REFERENCES [dbo].[TBVeiculos] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Locacoes_VeiculoId]
    ON [dbo].[Locacoes]([VeiculoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Locacoes_DescontoId]
    ON [dbo].[Locacoes]([DescontoId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Locacoes_CondutorId]
    ON [dbo].[Locacoes]([CondutorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Locacoes_ClienteId]
    ON [dbo].[Locacoes]([ClienteId] ASC);

