using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Clases
{
    public class Grammar
    {
        public const string EPSILON = "ε";

        public List<string> NonTerminals { get; private set; }
            = new List<string>();

        public HashSet<string> Terminals { get; private set; }
            = new HashSet<string>();

        public List<Production> Productions { get; private set; }
            = new List<Production>();

        public string StartSymbol { get; set; }
        public static bool IsEpsilon(string symbol)
        {
            return symbol == EPSILON;
        }

        public bool IsNonTerminal(string symbol)
        {
            return NonTerminals.Contains(symbol);
        }

        public bool IsTerminal(string symbol)
        {
            if (IsEpsilon(symbol))
                return false;

            return !IsNonTerminal(symbol);
        }
    }
}