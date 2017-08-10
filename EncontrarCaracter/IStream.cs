using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncontrarCaracter
{
    public interface IStream
    {
         char getNext();
         Boolean hasNext();
    }
}
