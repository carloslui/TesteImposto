using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrarCaracter
{
    /***
     * 
     * Implementação dos métodos da interface IStream
     * 
     * **/
    public class StringStream : IStream
    {
        private String stream;

        private int indexOf = 0;

        public StringStream(String stream)
        {
            this.stream = stream;
        }
        
        // Captura o próximo
        public char getNext()
        {
            return this.stream[indexOf++];
        }

        // Verifica se tem próximo
        public bool hasNext()
        {
            return (this.stream.Length > indexOf);
        }
    }
}
