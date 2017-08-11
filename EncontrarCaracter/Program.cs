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
            try
            {
                // Execução com a string informada no teste
                Console.WriteLine(Pesquisa.PrimeiraVogalNaoRepetida(new StringStream("aAbBABacfe")));
                Console.ReadKey();

                // Execução com a string alterado para não localizar
                Console.WriteLine(Pesquisa.PrimeiraVogalNaoRepetida(new StringStream("aAbBABacff")));
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            
        }

        
    }
}
