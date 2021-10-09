CREATE TABLE [dbo].[TBLocacoes] (
    [Id]               INT          IDENTITY (1, 1) NOT NULL,
    [IdCliente]        INT          NOT NULL,
    [IdVeiculo]        INT          NOT NULL,
    [IdDesconto]       INT          NULL,
    [IdCondutor]       INT          NOT NULL,
    [DataSaida]        DATE         NOT NULL,
    [DataRetorno]      DATE         NOT NULL,
    [TipoLocacao]      VARCHAR (20) NOT NULL,
    [StatusLocacao]    VARCHAR (20) NOT NULL,
    [TipoCliente]      INT          NOT NULL,
    [Dias]             INT          NOT NULL,
    [PrecoServicos]    FLOAT (53)   NOT NULL,
    [PrecoCombustivel] FLOAT (53)   NOT NULL,
    [PrecoPlano]       FLOAT (53)   NOT NULL,
    [PrecoTotal]       FLOAT (53)   NOT NULL,
    CONSTRAINT [PK_TBLocacoes] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBLocacoes_TBClientesBase_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[TBClientesBase] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TBLocacoes_TBClientesCPF_IdCondutor] FOREIGN KEY ([IdCondutor]) REFERENCES [dbo].[TBClientesCPF] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TBLocacoes_TBDescontos_IdDesconto] FOREIGN KEY ([IdDesconto]) REFERENCES [dbo].[TBDescontos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_TBLocacoes_TBVeiculos_IdVeiculo] FOREIGN KEY ([IdVeiculo]) REFERENCES [dbo].[TBVeiculos] ([Id]) ON DELETE CASCADE
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TBLocacoes_IdVeiculo]
    ON [dbo].[TBLocacoes]([IdVeiculo] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TBLocacoes_IdDesconto]
    ON [dbo].[TBLocacoes]([IdDesconto] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_TBLocacoes_IdCondutor]
    ON [dbo].[TBLocacoes]([IdCondutor] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_TBLocacoes_IdCliente]
    ON [dbo].[TBLocacoes]([IdCliente] ASC);

