CREATE TABLE [dbo].[TBDescontos] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [Codigo]      VARCHAR (50) NOT NULL,
    [Valor]       FLOAT (53)   NOT NULL,
    [ValorMinimo] FLOAT (53)   NOT NULL,
    [Tipo]        INT          NOT NULL,
    [Validade]    DATE         NOT NULL,
    [IdParceiro]  INT          NOT NULL,
    [Meio]        VARCHAR (50) NOT NULL,
    [Usos]        INT          NOT NULL,
    CONSTRAINT [PK_TBDescontos] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBDescontos_TBParceiros_IdParceiro] FOREIGN KEY ([IdParceiro]) REFERENCES [dbo].[TBParceiros] ([Id]) ON DELETE CASCADE
);




GO
CREATE NONCLUSTERED INDEX [IX_TBDescontos_IdParceiro]
    ON [dbo].[TBDescontos]([IdParceiro] ASC);

