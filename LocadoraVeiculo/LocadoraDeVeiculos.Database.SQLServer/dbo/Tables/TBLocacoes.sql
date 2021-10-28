CREATE TABLE [dbo].[TBLocacoes] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [IdCliente]        INT          NULL,
    [IdVeiculo]        INT          NULL,
    [IdDesconto]       INT          NULL,
    [IdCondutor]       INT          NULL,
    [DataSaida]        DATE         NOT NULL,
    [DataRetorno]      DATE         NOT NULL,
    [TipoLocacao]      VARCHAR (20) NOT NULL,
    [StatusLocacao]    VARCHAR (20) NULL,
    [TipoCliente]      INT          NOT NULL,
    [Dias]             INT          NOT NULL,
    [StatusEnvioEmail] VARCHAR (20) NOT NULL,
    [PrecoServicos]    FLOAT (53)   NULL,
    [PrecoCombustivel] FLOAT (53)   NULL,
    [PrecoPlano]       FLOAT (53)   NOT NULL,
    [PrecoTotal]       FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_TBLocacoes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBLocacoes_TBClientesBase_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[TBClientesBase] ([Id]),
    CONSTRAINT [FK_TBLocacoes_TBClientesCPF_IdCondutor] FOREIGN KEY ([IdCondutor]) REFERENCES [dbo].[TBClientesCPF] ([Id]),
    CONSTRAINT [FK_TBLocacoes_TBDescontos_IdDesconto] FOREIGN KEY ([IdDesconto]) REFERENCES [dbo].[TBDescontos] ([Id]),
    CONSTRAINT [FK_TBLocacoes_TBVeiculos_IdVeiculo] FOREIGN KEY ([IdVeiculo]) REFERENCES [dbo].[TBVeiculos] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_TBLocacoes_IdCliente]
    ON [dbo].[TBLocacoes]([IdCliente] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TBLocacoes_IdCondutor]
    ON [dbo].[TBLocacoes]([IdCondutor] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TBLocacoes_IdDesconto]
    ON [dbo].[TBLocacoes]([IdDesconto] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TBLocacoes_IdVeiculo]
    ON [dbo].[TBLocacoes]([IdVeiculo] ASC);

