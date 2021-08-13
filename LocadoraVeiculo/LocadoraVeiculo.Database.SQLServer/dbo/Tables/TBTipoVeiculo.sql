CREATE TABLE [dbo].[TBTipoVeiculo] (
    [Id]                       INT          IDENTITY (1, 1) NOT NULL,
    [NomeTipo]                 VARCHAR (50) NOT NULL,
    [Valor_Diario_PDiario]     DECIMAL (18) NULL,
    [Preco_KMDiario]           DECIMAL (18) NULL,
    [Valor_Diario_PControlado] DECIMAL (18) NULL,
    [KMDia__KMControlado]      INT          NULL,
    [Preco_KMLivre]            DECIMAL (18) NULL,
    CONSTRAINT [PK_TBTipoVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);





