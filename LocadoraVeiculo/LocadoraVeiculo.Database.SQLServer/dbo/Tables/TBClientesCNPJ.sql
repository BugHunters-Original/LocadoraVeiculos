CREATE TABLE [dbo].[TBClientesCNPJ] (
    [Id]   INT          NOT NULL,
    [Cnpj] VARCHAR (20) NOT NULL,
    CONSTRAINT [PK_TBClientesCNPJ] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBClientesCNPJ_TBClienteBase_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[TBClienteBase] ([Id])
);

