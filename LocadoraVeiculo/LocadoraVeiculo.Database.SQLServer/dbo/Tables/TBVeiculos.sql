CREATE TABLE [dbo].[TBVeiculos] (
    [Id]                     INT          IDENTITY (1, 1) NOT NULL,
    [Nome]                   VARCHAR (64) NOT NULL,
    [NumeroPlaca]            VARCHAR (64) NOT NULL,
    [NumeroChassi]           VARCHAR (64) NOT NULL,
    [Foto]                   IMAGE        NOT NULL,
    [Cor]                    VARCHAR (64) NOT NULL,
    [Marca]                  VARCHAR (64) NOT NULL,
    [Ano]                    INT          NULL,
    [NumeroPortas]           INT          NOT NULL,
    [CapacidadeTanque]       INT          NOT NULL,
    [CapacidadePessoas]      INT          NOT NULL,
    [TamanhoPortaMalas]      CHAR (1)     NOT NULL,
    [KmInicial]              INT          NOT NULL,
    [TipoCombustivel]        VARCHAR (64) NOT NULL,
    [DisponibilidadeVeiculo] INT          NOT NULL,
    [IdGrupoVeiculo]         INT          NOT NULL,
    CONSTRAINT [PK_TBVeiculos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculos_TBTiposVeiculo_IdGrupoVeiculo] FOREIGN KEY ([IdGrupoVeiculo]) REFERENCES [dbo].[TBTiposVeiculo] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TBVeiculos_IdGrupoVeiculo]
    ON [dbo].[TBVeiculos]([IdGrupoVeiculo] ASC);

