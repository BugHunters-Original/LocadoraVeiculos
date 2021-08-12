CREATE TABLE [dbo].[TBTipoCombustivel] (
    [Preco_Gasolina] DECIMAL (18) NULL,
    [Preco_Diesel]   DECIMAL (18) NULL,
    [Preco_Alcool]   DECIMAL (18) NULL, 
    [Id] INT NOT NULL IDENTITY, 
    CONSTRAINT [PK_TBTipoCombustivel] PRIMARY KEY ([Id])
);



