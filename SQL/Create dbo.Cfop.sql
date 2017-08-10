USE [Teste]
GO

/****** Object: Table [dbo].[NotaFiscal] Script Date: 09/08/2017 21:19:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Cfop] (
	[EstadoOrigem]     VARCHAR (50) NOT NULL,
    [EstadoDestino]    VARCHAR (50) NOT NULL,
	[Cfop]			   VARCHAR (5)  NULL,
	Primary Key (EstadoOrigem, EstadoDestino)
);


