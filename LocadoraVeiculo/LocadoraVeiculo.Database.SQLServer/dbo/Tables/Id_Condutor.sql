CREATE TABLE [dbo].[Id_Condutor] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [Nome]          NCHAR (10) NULL,
    [Telefone]      NCHAR (10) NULL,
    [Endereco]      NCHAR (10) NULL,
    [CPF]           NCHAR (10) NULL,
    [RG]            NCHAR (10) NULL,
    [CNH]           NCHAR (10) NULL,
    [Data_Validade] NCHAR (10) NULL,
    [Id_Cliente]    INT        NULL,
    CONSTRAINT [PK_Id_Condutor] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Id_Condutor_TBCliente] FOREIGN KEY ([Id_Cliente]) REFERENCES [dbo].[TBCliente] ([Id])
);

