CREATE TABLE [dbo].[TBClienteCPF] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [NomeC]         VARCHAR (50)  NULL,
    [TelefoneC]     VARCHAR (50)  NULL,
    [EnderecoC]     VARCHAR (50)  NULL,
    [CPF]           VARCHAR (50)  NULL,
    [RG]            VARCHAR (50)  NULL,
    [CNH]           VARCHAR (50)  NULL,
    [Data_Validade] DATE          NULL,
    [Id_Cliente]    INT           NULL,
    [EmailC]        VARCHAR (250) NULL,
    CONSTRAINT [PK_Id_Condutor] PRIMARY KEY CLUSTERED ([Id] ASC)
);



