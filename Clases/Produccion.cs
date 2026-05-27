using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Clases
{
    public class Production
    {
        public string Left { get; set; }

        public List<string> Right { get; set; }

        public Production(
            string left,
            List<string> right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            if (Right == null || Right.Count == 0)
                return $"{Left} -> ε";

            return $"{Left} -> {string.Join(" ", Right)}";
        }
    }

}
