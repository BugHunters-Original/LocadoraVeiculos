CREATE TABLE [dbo].[TBDesconto] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Codigo]      VARCHAR (50) NOT NULL,
    [Valor]       FLOAT (53)   NOT NULL,
    [Tipo]        VARCHAR (50) NOT NULL,
    [Validade]    DATE         NOT NULL,
    [Id_Parceiro] INT          NOT NULL,
    [Meio]        VARCHAR (50) NOT NULL,
    [NomeCupom]   VARCHAR (50) NULL,
    [ValorMinimo] FLOAT (53)   NULL,
    [Usos]        INT          NULL,
    CONSTRAINT [PK_TBDesconto] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBDesconto_TBParceiros] FOREIGN KEY ([Id_Parceiro]) REFERENCES [dbo].[TBParceiros] ([Id])
);





