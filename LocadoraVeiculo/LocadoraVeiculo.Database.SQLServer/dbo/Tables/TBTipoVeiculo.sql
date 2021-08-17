CREATE TABLE [dbo].[TBTipoVeiculo] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [NomeTipo]                 VARCHAR (50) NOT NULL,
    [Valor_Diario_PDiario]     FLOAT (53)   NULL,
    [Preco_KMDiario]           FLOAT (53)   NULL,
    [Valor_Diario_PControlado] FLOAT (53)   NULL,
    [KMDia__KMControlado]      INT          NULL,
    [Preco_KMLivre]            FLOAT (53)   NULL,
    CONSTRAINT [PK_TBTipoVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

