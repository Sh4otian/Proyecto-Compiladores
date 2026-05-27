using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Clases.Grammar;

namespace ConsoleApp1.Clases
{
    public class FirstFollow
    {

        // =====================================================
        // FIRST
        // =====================================================

        public Dictionary<string, HashSet<string>>
            ComputeFirst(Grammar grammar)
        {
            var first =
                new Dictionary<string, HashSet<string>>();

            foreach (var nt in grammar.NonTerminals)
            {
                first[nt] = new HashSet<string>();
            }

            bool changed;

            do
            {
                changed = false;

                foreach (var production in grammar.Productions)
                {
                    var left = production.Left;

                    var firstAlpha =
                        FirstOfSequence(grammar,
                            production.Right,
                            first);

                    foreach (var item in firstAlpha)
                    {
                        if (first[left].Add(item))
                            changed = true;
                    }
                }

            } while (changed);

            return first;
        }

        // =====================================================
        // FIRST(α)
        // =====================================================

        public HashSet<string> FirstOfSequence(Grammar grammar,
            List<string> symbols,
            Dictionary<string, HashSet<string>> first)
        {
            var result = new HashSet<string>();

            // α = ε
            if (symbols == null || symbols.Count == 0)
            {
                result.Add(EPSILON);
                return result;
            }

            bool nullable = true;

            foreach (var symbol in symbols)
            {
                // terminal
                if (grammar.IsTerminal(symbol))
                {
                    result.Add(symbol);
                    nullable = false;
                    break;
                }

                // no terminal
                foreach (var item in first[symbol]
                    .Where(x => !IsEpsilon(x)))
                {
                    result.Add(item);
                }

                // no produce ε
                if (!first[symbol].Contains(EPSILON))
                {
                    nullable = false;
                    break;
                }
            }

            if (nullable)
                result.Add(EPSILON);

            return result;
        }

        // =====================================================
        // FOLLOW
        // =====================================================

        public Dictionary<string, HashSet<string>>
            ComputeFollow(Grammar grammar,
            Dictionary<string, HashSet<string>> first)
        {
            var follow =
                new Dictionary<string, HashSet<string>>();

            foreach (var nt in grammar.NonTerminals)
            {
                follow[nt] = new HashSet<string>();
            }

            follow[grammar.StartSymbol].Add("$");

            bool changed;

            do
            {
                changed = false;

                foreach (var production in grammar.Productions)
                {
                    var left = production.Left;
                    var right = production.Right;

                    for (int i = 0; i < right.Count; i++)
                    {
                        var B = right[i];

                        if (!grammar.IsNonTerminal(B))
                            continue;

                        var beta =
                            right.Skip(i + 1).ToList();

                        var firstBeta =
                            FirstOfSequence(grammar,beta, first);

                        // FIRST(beta) - ε
                        foreach (var item in firstBeta
                            .Where(x => !IsEpsilon(x)))
                        {
                            if (follow[B].Add(item))
                                changed = true;
                        }

                        // si beta => ε
                        if (beta.Count == 0 ||
                            firstBeta.Contains(EPSILON))
                        {
                            foreach (var item in follow[left])
                            {
                                if (follow[B].Add(item))
                                    changed = true;
                            }
                        }
                    }
                }

            } while (changed);

            return follow;
        }

    }
}
