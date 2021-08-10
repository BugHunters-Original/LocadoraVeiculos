CREATE TABLE [dbo].[TBCliente] (
    [Id]       INT          IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (10) NULL,
    [Endereco] VARCHAR (50) NULL,
    [Telefone] VARCHAR (50) NULL,
    [CPF_CNPJ] VARCHAR (50) NULL,
    [Tipo]     VARCHAR (50) NULL,
    CONSTRAINT [PK_TBCliente] PRIMARY KEY CLUSTERED ([Id] ASC)
);

