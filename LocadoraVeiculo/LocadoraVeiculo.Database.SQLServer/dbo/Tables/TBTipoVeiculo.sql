CREATE TABLE [dbo].[TBTipoVeiculo] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [NomeTipo]                 VARCHAR (50) NOT NULL,
    [Valor_Diario_PDiario]     FLOAT NULL,
    [Preco_KMDiario]           FLOAT NULL,
    [Valor_Diario_PControlado] FLOAT NULL,
    [KMDia__KMControlado]      INT          NULL,
    [Preco_KMLivre]            FLOAT NULL,
    CONSTRAINT [PK_TBTipoVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);





