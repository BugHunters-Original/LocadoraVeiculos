﻿CREATE TABLE [dbo].[TBParceiros] (
    [Id]            INT          IDENTITY (1, 1) NOT NULL,
    [Nome_Parceiro] VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TBParceiros] PRIMARY KEY CLUSTERED ([Id] ASC)
);

