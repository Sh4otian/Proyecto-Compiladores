using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Clases.FirstFollow;
using static ConsoleApp1.Clases.Grammar;



namespace ConsoleApp1.Clases
{
    public class Tablasll1
    {
        public LL1TableResult BuildLL1Table(Grammar grammar,
            Dictionary<string, HashSet<string>> first,
            Dictionary<string, HashSet<string>> follow, FirstFollow conv)
        {
            var result = new LL1TableResult
            {
                NonTerminals =
                    grammar.NonTerminals.ToList(),

                Terminals =
                    grammar.Terminals.OrderBy(x => x).ToList(),

                Table =
                    new Dictionary<string,
                    Dictionary<string, string>>(),

                Conflicts =
                    new List<string>()
            };

            // inicializar tabla
            foreach (var nt in grammar.NonTerminals)
            {
                result.Table[nt] =
                    new Dictionary<string, string>();
            }

            // llenar tabla
            foreach (var production in grammar.Productions)
            {
                var left = production.Left;

                var firstAlpha =
                    conv.FirstOfSequence(grammar,
                        production.Right,
                        first);

                // FIRST(alpha) - ε
                foreach (var terminal in firstAlpha
                    .Where(x => !Grammar.IsEpsilon(x)))
                {
                    AddTableEntry(
                        result,
                        left,
                        terminal,
                        production.ToString());
                }

                // si alpha => ε
                if (firstAlpha.Contains(EPSILON))
                {
                    foreach (var terminal in follow[left])
                    {
                        AddTableEntry(
                            result,
                            left,
                            terminal,
                            production.ToString());
                    }
                }
            }

            return result;
        }

        private void AddTableEntry(
            LL1TableResult result,
            string nonTerminal,
            string terminal,
            string production)
        {
            if (result.Table[nonTerminal]
                .ContainsKey(terminal))
            {
                result.Conflicts.Add(
                    $"Conflicto en M[{nonTerminal}, {terminal}]");
            }
            else
            {
                result.Table[nonTerminal][terminal]
                    = production;
            }
        }
    }

    // =====================================================
    // RESULTADO LL1
    // =====================================================

    public class LL1TableResult
    {
        public List<string> NonTerminals { get; set; }

        public List<string> Terminals { get; set; }

        public Dictionary<string,
            Dictionary<string, string>>
            Table
        { get; set; }

        public List<string> Conflicts { get; set; }
    }
}
