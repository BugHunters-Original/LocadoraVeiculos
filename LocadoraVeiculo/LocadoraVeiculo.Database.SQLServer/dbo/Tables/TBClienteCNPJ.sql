CREATE TABLE [dbo].[TBClienteCNPJ] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (50) NULL,
    [Endereco] VARCHAR (50) NULL,
    [Telefone] VARCHAR (50) NULL,
    [CNPJ]     VARCHAR (50) NULL,
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

