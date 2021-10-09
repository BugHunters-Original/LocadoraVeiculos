CREATE TABLE [dbo].[TBClientesBase] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Nome]     VARCHAR (100) NOT NULL,
    [Endereco] VARCHAR (100) NOT NULL,
    [Telefone] VARCHAR (15)  NOT NULL,
    [Email]    VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_TBClientesBase] PRIMARY KEY CLUSTERED ([Id] ASC)
);

