CREATE TABLE [dbo].[TBTiposVeiculo] (
    [Id]                       INT             IDENTITY (1, 1) NOT NULL,
    [NomeTipo]                 VARCHAR (64)    NOT NULL,
    [ValorDiarioPDiario]       FLOAT (53)      NOT NULL,
    [ValorKmRodadoPDiario]     FLOAT (53)      NOT NULL,
    [ValorDiarioPControlado]   FLOAT (53)      NOT NULL,
    [LimitePControlado]        DECIMAL (18, 2) NULL,
    [ValorKmRodadoPControlado] FLOAT (53)      NOT NULL,
    [ValorDiarioPLivre]        FLOAT (53)      NOT NULL,
    CONSTRAINT [PK_TBTiposVeiculo] PRIMARY KEY CLUSTERED ([Id] ASC)
);

