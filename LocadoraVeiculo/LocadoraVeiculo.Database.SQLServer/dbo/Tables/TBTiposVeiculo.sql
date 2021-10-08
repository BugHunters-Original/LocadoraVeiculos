CREATE TABLE [dbo].[TBTiposVeiculo] (
    [Id]                       INT             IDENTITY (1, 1) NOT NULL,
    [NomeTipo]                 VARCHAR (64)    NOT NULL,
    [ValorDiarioPDiario]       DECIMAL (18)    NOT NULL,
    [ValorKmRodadoPDiario]     DECIMAL (18)    NOT NULL,
    [ValorDiarioPControlado]   DECIMAL (18)    NOT NULL,
    [LimitePControlado]        DECIMAL (18, 2) NULL,
    [ValorKmRodadoPControlado] DECIMAL (18)    NOT NULL,
    [ValorDiarioPLivre]        DECIMAL (18)    NOT NULL,
    CONSTRAINT [PK_TBTiposVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

