using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class NotaFiscalDesconto : NotaFiscal
    {
        /***
         * 
         *  Método para aplicar desconto nos itens da Nota Fiscal
         *  
         *  ***/
        public void AplicarDesconto()
        {
            try
            {
                // Desconto Sudeste
                if (this.EstadoDestino == "SP" || this.EstadoDestino == "MG" || this.EstadoDestino == "ES" || this.EstadoDestino == "RJ")
                {
                    foreach (var itemPedido in this.ItensDaNotaFiscal)
                    {
                        itemPedido.Desconto = 10;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            
        }
    }
}
