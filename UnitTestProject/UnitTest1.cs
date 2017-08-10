using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EncontrarCaracter;

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
    }
}
