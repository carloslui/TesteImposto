using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrarCaracter
{
    public static class Pesquisa
    {
        /***
         * Dada uma stream, encontre o primeiro caracter Vogal, após uma consoante e que não se repita no resto da stream.
         * 
         * **/
        public static char PrimeiraVogalNaoRepetida(IStream input)
        {
            char c, charNaoRepetido = char.MinValue;
            int size = 10;
            char[] vogal = { 'a', 'A', 'e', 'E', 'i', 'I', 'o', 'O', 'u', 'U' };
            bool isConsoanteCharAnterior = false;
            int indexVogalLidas = 0;

            // Armazena as vogais que já foram lidas
            char[] vogalLidas = new char[size];

            // Ler toda stream
            while (input.hasNext())
            {
                // busca o próximo
                c = input.getNext();

                // Verifica se é vogal 
                if (indexOf(c, vogal))
                {
                    if (isConsoanteCharAnterior)
                    {
                        // Verifica se está repetida
                        if (!indexOf(c, vogalLidas))
                        {
                            charNaoRepetido = c;
                        }
                    }
                    vogalLidas[indexVogalLidas++] = c;
                }
                else
                {
                    isConsoanteCharAnterior = true;
                }

            }

            return charNaoRepetido;
        }

        /***
         * Pesquisa do caracter na array chars
         * **/
        
        private static bool indexOf(char c, char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
            {
                if (c == chars[i])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
