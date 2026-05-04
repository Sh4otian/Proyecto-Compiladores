using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    internal class CompAFN
    {
        public class Estado
        {
            public int Num;
            public bool edoacept;
            public int token;
            public HashSet<Transicion> Transiciones = new HashSet<Transicion>();
            public Estado()
            {
                token = -1;
                edoacept = false;
            }
        }
        public class Transicion
        {
            public HashSet<char> simbolo = new HashSet<char>();
            public Estado edosig;
            public Transicion() { }
            public Transicion(char add, Estado Adds)
            {
                simbolo.Add(add);
                edosig = Adds;
            }
        }

    }
}
