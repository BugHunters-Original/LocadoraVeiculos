CREATE TABLE [dbo].[TBVeiculos] (
    [Id]                      INT          IDENTITY (1, 1) NOT NULL,
    [Nome]                    VARCHAR (50) NOT NULL,
    [Numero_placa]            VARCHAR (50) NOT NULL,
    [Numero_chassi]           NCHAR (17)   NULL,
    [Foto]                    IMAGE        NULL,
    [Cor]                     NCHAR (10)   NULL,
    [Marca]                   NCHAR (10)   NULL,
    [Ano]                     INT          NULL,
    [Numero_portas]           INT          NULL,
    [Capacidade_tanque]       INT          NULL,
    [Tamanho_porta_mala]      CHAR (1)     NULL,
    [KM_inicial]              INT          NULL,
    [Tipo_combustivel]        VARCHAR (50) NOT NULL,
    [Id_Tipo_Veiculo]         INT          NOT NULL,
    [Disponibilidade_veiculo] INT          NOT NULL,
    CONSTRAINT [PK_TBVeiculos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBVeiculos_TBTipoVeiculo] FOREIGN KEY ([Id_Tipo_Veiculo]) REFERENCES [dbo].[TBTipoVeiculo] ([Id])
);





