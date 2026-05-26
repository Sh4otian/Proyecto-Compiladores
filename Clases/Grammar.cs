using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Clases
{
    public class Grammar
    {
        private const string EPSILON = "ε";

        public List<string> NonTerminals { get; private set; }
            = new List<string>();

        public HashSet<string> Terminals { get; private set; }
            = new HashSet<string>();

        public List<Production> Productions { get; private set; }
            = new List<Production>();

        public string StartSymbol { get; private set; }

        // =====================================================
        // PARSE
        // =====================================================

        public static Grammar Parse(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new Exception("La gramática está vacía.");

            var grammar = new Grammar();

            var lines = input.Split(
                new[] { '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            // =========================
            // PRIMERA PASADA:
            // obtener no terminales
            // =========================

            foreach (var raw in lines)
            {
                var line = raw.Trim();

                if (line.Length == 0)
                    continue;

                if (line.StartsWith("//") ||
                    line.StartsWith("#"))
                    continue;

                var parts = line.Split(new[] { "->" },
                    StringSplitOptions.None);

                if (parts.Length != 2)
                    throw new InvalidDataException(
                        $"Producción inválida: {line}");

                var left = parts[0].Trim();

                if (string.IsNullOrWhiteSpace(left))
                    throw new InvalidDataException(
                        $"No terminal inválido: {line}");

                if (grammar.StartSymbol == null)
                    grammar.StartSymbol = left;

                if (!grammar.NonTerminals.Contains(left))
                    grammar.NonTerminals.Add(left);
            }

            // =========================
            // SEGUNDA PASADA:
            // producciones
            // =========================

            foreach (var raw in lines)
            {
                var line = raw.Trim();

                if (line.Length == 0)
                    continue;

                if (line.StartsWith("//") ||
                    line.StartsWith("#"))
                    continue;

                var parts = line.Split(new[] { "->" },
                    StringSplitOptions.None);

                var left = parts[0].Trim();

                var alternatives = parts[1]
                    .Split('|');

                foreach (var alt in alternatives)
                {
                    var symbols = TokenizeAlternative(
                        alt.Trim());

                    // ε => producción vacía
                    if (symbols.Count == 1 &&
                        IsEpsilon(symbols[0]))
                    {
                        symbols.Clear();
                    }

                    var production =
                        new Production(left, symbols);

                    grammar.Productions.Add(production);
                }
            }

            // =========================
            // TERMINALES
            // =========================

            foreach (var production in grammar.Productions)
            {
                foreach (var symbol in production.Right)
                {
                    if (grammar.IsNonTerminal(symbol))
                        continue;

                    if (IsEpsilon(symbol))
                        continue;

                    grammar.Terminals.Add(symbol);
                }
            }

            grammar.Terminals.Add("$");

            return grammar;
        }

        // =====================================================
        // TOKENIZER
        // =====================================================

        private static List<string> TokenizeAlternative(
            string alternative)
        {
            var tokens = new List<string>();

            for (int i = 0; i < alternative.Length;)
            {
                char c = alternative[i];

                // espacios
                if (char.IsWhiteSpace(c))
                {
                    i++;
                    continue;
                }

                // epsilon
                if (c == 'ε')
                {
                    tokens.Add(EPSILON);
                    i++;
                    continue;
                }

                // No terminal tipo E'
                if (char.IsUpper(c))
                {
                    var token = new StringBuilder();

                    token.Append(c);
                    i++;

                    while (i < alternative.Length &&
                           alternative[i] == '\'')
                    {
                        token.Append(alternative[i]);
                        i++;
                    }

                    tokens.Add(token.ToString());
                    continue;
                }

                // terminal tipo num
                if (char.IsLetter(c))
                {
                    var token = new StringBuilder();

                    while (i < alternative.Length &&
                          (char.IsLetterOrDigit(alternative[i]) ||
                           alternative[i] == '_'))
                    {
                        token.Append(alternative[i]);
                        i++;
                    }

                    tokens.Add(token.ToString());
                    continue;
                }

                // símbolos
                tokens.Add(c.ToString());
                i++;
            }

            return tokens;
        }

        // =====================================================
        // HELPERS
        // =====================================================

        private static bool IsEpsilon(string symbol)
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

        // =====================================================
        // FIRST
        // =====================================================

        public Dictionary<string, HashSet<string>>
            ComputeFirst()
        {
            var first =
                new Dictionary<string, HashSet<string>>();

            foreach (var nt in NonTerminals)
            {
                first[nt] = new HashSet<string>();
            }

            bool changed;

            do
            {
                changed = false;

                foreach (var production in Productions)
                {
                    var left = production.Left;

                    var firstAlpha =
                        FirstOfSequence(
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

        private HashSet<string> FirstOfSequence(
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
                if (IsTerminal(symbol))
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
            ComputeFollow(
            Dictionary<string, HashSet<string>> first)
        {
            var follow =
                new Dictionary<string, HashSet<string>>();

            foreach (var nt in NonTerminals)
            {
                follow[nt] = new HashSet<string>();
            }

            follow[StartSymbol].Add("$");

            bool changed;

            do
            {
                changed = false;

                foreach (var production in Productions)
                {
                    var left = production.Left;
                    var right = production.Right;

                    for (int i = 0; i < right.Count; i++)
                    {
                        var B = right[i];

                        if (!IsNonTerminal(B))
                            continue;

                        var beta =
                            right.Skip(i + 1).ToList();

                        var firstBeta =
                            FirstOfSequence(beta, first);

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

        // =====================================================
        // TABLA LL1
        // =====================================================

        public LL1TableResult BuildLL1Table(
            Dictionary<string, HashSet<string>> first,
            Dictionary<string, HashSet<string>> follow)
        {
            var result = new LL1TableResult
            {
                NonTerminals =
                    NonTerminals.ToList(),

                Terminals =
                    Terminals.OrderBy(x => x).ToList(),

                Table =
                    new Dictionary<string,
                    Dictionary<string, string>>(),

                Conflicts =
                    new List<string>()
            };

            // inicializar tabla
            foreach (var nt in NonTerminals)
            {
                result.Table[nt] =
                    new Dictionary<string, string>();
            }

            // llenar tabla
            foreach (var production in Productions)
            {
                var left = production.Left;

                var firstAlpha =
                    FirstOfSequence(
                        production.Right,
                        first);

                // FIRST(alpha) - ε
                foreach (var terminal in firstAlpha
                    .Where(x => !IsEpsilon(x)))
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
    // PRODUCTION
    // =====================================================

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