CREATE TABLE [dbo].[TBFuncionario] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [Nome]         VARCHAR (50) NOT NULL,
    [Salario]      FLOAT (53)   NOT NULL,
    [CPF]          VARCHAR (50) NULL,
    [Data_entrada] DATE         NULL,
    [Usuario]      VARCHAR (50) NOT NULL,
    [Senha]        VARCHAR (64) NOT NULL,
    CONSTRAINT [PK_TBFuncionario] PRIMARY KEY CLUSTERED ([Id] ASC)
);

