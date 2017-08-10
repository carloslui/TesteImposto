using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class NotaFiscalItem
    {

        public NotaFiscalItem()
        {
            this.Id = 0;
            this.IdNotaFiscal = 0;
            this.Cfop = string.Empty;
            this.TipoIcms = string.Empty;
            this.BaseIcms = 0;
            this.AliquotaIcms = 0;
            this.ValorIcms = 0;
            this.NomeProduto = string.Empty;
            this.CodigoProduto = string.Empty;
            this.BaseIpi = 0;
            this.AliquotaIpi = 0;
            this.ValorIpi = 0;
            this.Desconto = 0;

        }
        public int Id { get; set; }
        public int IdNotaFiscal { get; set; }
        public string Cfop { get; set; }
        public string TipoIcms { get; set; }
        public double BaseIcms { get; set; }
        public double AliquotaIcms { get; set; }
        public double ValorIcms { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public double BaseIpi { get; set; }
        public double AliquotaIpi { get; set; }
        public double ValorIpi { get; set; }
        public double Desconto { get; set; }
    }
}
