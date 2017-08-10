

create procedure P_NOTAFISCAL_CFOP

as

	select
		nfi.Cfop,
		sum(nfi.BaseIcms) "Valor Total da Base de ICMS",
		sum(nfi.ValorIcms) "Valor Total do ICMS",
		sum(nfi.BaseIpi) "Valor Total da Base de IPI ",
		sum(nfi.ValorIpi) "Valor Total do IPI "
	from 
		NotaFiscalItem nfi
	group by 
		nfi.Cfop