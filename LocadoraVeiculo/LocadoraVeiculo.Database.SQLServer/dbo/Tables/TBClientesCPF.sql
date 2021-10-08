CREATE TABLE [dbo].[TBClientesCPF] (
    [Id]           INT           NOT NULL,
    [Cpf]          VARCHAR (14)  NOT NULL,
    [Rg]           VARCHAR (10)  NOT NULL,
    [Cnh]          VARCHAR (12)  NOT NULL,
    [DataValidade] DATETIME2 (7) NOT NULL,
    [IdCliente]    INT           NOT NULL,
    CONSTRAINT [PK_TBClientesCPF] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_TBClientesCPF_TBClienteBase_Id] FOREIGN KEY ([Id]) REFERENCES [dbo].[TBClienteBase] ([Id]),
    CONSTRAINT [FK_TBClientesCPF_TBClientesCNPJ_IdCliente] FOREIGN KEY ([IdCliente]) REFERENCES [dbo].[TBClientesCNPJ] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TBClientesCPF_IdCliente]
    ON [dbo].[TBClientesCPF]([IdCliente] ASC);

