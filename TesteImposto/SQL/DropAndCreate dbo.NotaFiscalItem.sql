USE [Teste]
GO

/****** Object: Table [dbo].[NotaFiscalItem] Script Date: 09/08/2017 14:53:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[NotaFiscalItem];


GO
CREATE TABLE [dbo].[NotaFiscalItem] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [IdNotaFiscal]  INT             NULL,
    [Cfop]          VARCHAR (5)     NULL,
    [TipoIcms]      VARCHAR (20)    NULL,
    [BaseIcms]      DECIMAL (18, 5) NULL,
    [AliquotaIcms]  DECIMAL (18, 5) NULL,
    [ValorIcms]     DECIMAL (18, 5) NULL,
    [NomeProduto]   VARCHAR (50)    NULL,
    [CodigoProduto] VARCHAR (20)    NULL,
    [BaseIpi]       DECIMAL (18, 5) NULL,
    [AliquotaIpi]   DECIMAL (18, 5) NULL,
    [ValorIpi]      DECIMAL (18, 5) NULL,
	[Desconto]      DECIMAL (18, 5) NULL
);


