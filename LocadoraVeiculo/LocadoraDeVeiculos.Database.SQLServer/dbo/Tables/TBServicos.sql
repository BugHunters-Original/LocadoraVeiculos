CREATE TABLE [dbo].[TBServicos] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [Nome]        VARCHAR (50) NOT NULL,
    [Preco]       FLOAT (53)   NOT NULL,
    [CalculoTipo] INT          NOT NULL,
    CONSTRAINT [PK_TBServicos] PRIMARY KEY CLUSTERED ([Id] ASC)
);



