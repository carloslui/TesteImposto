using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncontrarCaracter;
using Imposto.Core.Data;
using Imposto.Core.Domain;
using Imposto.Core.Service;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        
            Assert.AreEqual(Pesquisa.PrimeiraVogalNaoRepetida(new StringStream("aAbBABacfe")), 'e');
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(Pesquisa.PrimeiraVogalNaoRepetida(new StringStream("aAbBABacfe")), 'a');
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(Pesquisa.PrimeiraVogalNaoRepetida(new StringStream("aAbBABacfecfi")), 'i');
        }


        // Nota Fiscal
        [TestMethod]
        public void TestMethod4()
        {
            NotaFiscalDesconto notaFiscal = new NotaFiscalDesconto();
            NotaFiscalRepository notaFiscalRepository = new NotaFiscalRepository();
            NotaFiscalService NotaFiscalService = new NotaFiscalService();
            Pedido pedido = new Pedido();

            
            pedido.EstadoOrigem = "SP";
            pedido.EstadoDestino = "RJ";
            pedido.NomeCliente = "Carlos Lui";

            pedido.ItensDoPedido.Add(
                new PedidoItem()
                {
                    Brinde = false,
                    CodigoProduto = "1256",
                    NomeProduto = "Tenis",
                    ValorItemPedido = 200
                });
                

            NotaFiscalService.Gravar(pedido);
        }
    }
}
