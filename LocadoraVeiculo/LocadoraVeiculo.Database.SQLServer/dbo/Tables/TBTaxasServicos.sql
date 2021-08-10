CREATE TABLE [dbo].[TBTaxasServicos] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome_taxa]    VARCHAR (50) NULL,
    [Preco_taxa]   FLOAT (53)   NULL,
    [Tipo_calculo] INT          NULL,
    CONSTRAINT [PK_TBTaxasServicos] PRIMARY KEY CLUSTERED ([Id] ASC)
);

