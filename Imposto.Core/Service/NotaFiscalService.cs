using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Configuration;
using Imposto.Core.Data;

namespace Imposto.Core.Service
{
    public class NotaFiscalService
    {
        private NotaFiscalDesconto notaFiscal = new NotaFiscalDesconto();
        private NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();

        public NotaFiscalService()
        {
            notaFiscal = new NotaFiscalDesconto();
            
        }

        public void Gravar(Domain.Pedido pedido)
        {
            try
            {
                // Gerar Nota Fiscal
                EmitirNotaFiscal(pedido);

                //Desconto
                notaFiscal.AplicarDesconto();

                // Gerar XML da Nota Fiscal
                GerarXML();

                // Persistir na base de dados a Nota Fiscal
                Incluir();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        private void GerarXML()
        {
            try
            {
                var arquivo = ConfigurationManager.AppSettings["pathXMLNotaFiscal"] + "NotaFiscalXML_" + notaFiscal.NumeroNotaFiscal + ".xml";

                XmlSerializer SerializerObj = new XmlSerializer(typeof(Domain.NotaFiscalDesconto));
                TextWriter WriteFileStream = new StreamWriter(arquivo);
                SerializerObj.Serialize(WriteFileStream, notaFiscal);
                WriteFileStream.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void Incluir()
        {
            try
            {
                notaFiscalRepository.Incluir(notaFiscal);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void EmitirNotaFiscal(Pedido pedido)
        {
            notaFiscal.NumeroNotaFiscal = new Random().Next(Int32.MaxValue);
            notaFiscal.Serie = new Random().Next(Int32.MaxValue);
            notaFiscal.NomeCliente = pedido.NomeCliente;
            notaFiscal.EstadoOrigem = pedido.EstadoOrigem;
            notaFiscal.EstadoDestino = pedido.EstadoDestino;

            foreach (PedidoItem itemPedido in pedido.ItensDoPedido)
            {
                NotaFiscalItem notaFiscalItem = new NotaFiscalItem();

                // IPI
                notaFiscalItem.BaseIpi = itemPedido.ValorItemPedido;
                if (!itemPedido.Brinde)
                {
                    notaFiscalItem.AliquotaIpi = 10;
                    notaFiscalItem.ValorIpi = itemPedido.ValorItemPedido * 0.1;
                }

                // Cfop
                notaFiscalItem.Cfop = notaFiscalRepository.Cfop(notaFiscal.EstadoOrigem, notaFiscal.EstadoDestino);
                               
                if (notaFiscal.EstadoDestino == notaFiscal.EstadoOrigem)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                }
                else
                {
                    notaFiscalItem.TipoIcms = "10";
                    notaFiscalItem.AliquotaIcms = 0.17;
                }

                if (notaFiscalItem.Cfop == "6.009")
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido * 0.90; //redução de base
                }
                else
                {
                    notaFiscalItem.BaseIcms = itemPedido.ValorItemPedido;
                }
                notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;

                if (itemPedido.Brinde)
                {
                    notaFiscalItem.TipoIcms = "60";
                    notaFiscalItem.AliquotaIcms = 0.18;
                    notaFiscalItem.ValorIcms = notaFiscalItem.BaseIcms * notaFiscalItem.AliquotaIcms;
                }

                notaFiscalItem.NomeProduto = itemPedido.NomeProduto;
                notaFiscalItem.CodigoProduto = itemPedido.CodigoProduto;
                notaFiscal.ItensDaNotaFiscal.Add(notaFiscalItem);
            }
        }

    }
}
