CREATE TABLE [dbo].[TBTipoCombustivel] (
    [Preco_Gasolina] FLOAT (18) NULL,
    [Preco_Diesel]   FLOAT (18) NULL,
    [Preco_Alcool]   FLOAT (18) NULL, 
    [Id] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_TBTipoCombustivel] PRIMARY KEY ([Id])
);



