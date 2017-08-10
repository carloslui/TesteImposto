using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrarCaracter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Pesquisa.PrimeiraVogalNaoRepetida(new StringStream("aAbBABacfe")));
            Console.ReadKey();
        }

        
    }
}
