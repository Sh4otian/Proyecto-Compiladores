using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Clases
{
    public class Grammar
    {
        private static readonly HashSet<string> EpsilonTokens = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "ε", "epsilon", "EPSILON" };

        public List<string> NonTerminals { get; private set; } = new List<string>();
        public HashSet<string> Terminals { get; private set; } = new HashSet<string>();
        public List<Production> Productions { get; private set; } = new List<Production>();
        public string StartSymbol { get; private set; }

        public static Grammar Parse(string input)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            var grammar = new Grammar();
            var rawProductions = new List<(string left, List<string> right)>();
            var nonTerminals = new HashSet<string>();

            var lines = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var rawLine in lines)
            {
                var line = rawLine.Trim();
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("//") || line.StartsWith("#"))
                    continue;

                var arrowIndex = line.IndexOf("->", StringComparison.Ordinal);
                if (arrowIndex < 0)
                    throw new InvalidDataException($"Línea inválida en la gramática: '{line}'. Debe tener '->'.");

                var left = line.Substring(0, arrowIndex).Trim();
                if (left.Length == 0)
                    throw new InvalidDataException($"No se encontró no terminal en la parte izquierda de: '{line}'.");

                nonTerminals.Add(left);
                var rightSide = line.Substring(arrowIndex + 2).Trim();
                var alternatives = rightSide.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (var alternative in alternatives)
                {
                    var symbols = TokenizeAlternative(alternative.Trim());
                    rawProductions.Add((left, symbols));
                }
            }

            if (rawProductions.Count == 0)
                throw new InvalidDataException("La gramática está vacía o no contiene producciones válidas.");

            grammar.StartSymbol = rawProductions[0].left;
            grammar.NonTerminals = nonTerminals.ToList();

            foreach (var item in rawProductions)
            {
                var rhs = item.right;
                if (rhs.Count == 1 && IsEpsilonToken(rhs[0]))
                {
                    rhs = new List<string>();
                }

                grammar.Productions.Add(new Production(item.left, rhs));
            }

            foreach (var production in grammar.Productions)
            {
                foreach (var symbol in production.Right)
                {
                    if (IsEpsilonToken(symbol))
                        continue;
                    if (!nonTerminals.Contains(symbol))
                        grammar.Terminals.Add(symbol);
                }
            }

            return grammar;
        }

        private static List<string> TokenizeAlternative(string alternative)
        {
            var symbols = new List<string>();
            var current = new StringBuilder();
            int length = alternative.Length;

            void FlushCurrent()
            {
                if (current.Length > 0)
                {
                    symbols.Add(current.ToString());
                    current.Clear();
                }
            }

            for (int i = 0; i < length; i++)
            {
                char c = alternative[i];
                if (char.IsWhiteSpace(c))
                {
                    FlushCurrent();
                    continue;
                }

                if (c == 'ε')
                {
                    FlushCurrent();
                    symbols.Add("ε");
                    continue;
                }

                if (char.IsUpper(c))
                {
                    FlushCurrent();
                    var token = new StringBuilder();
                    token.Append(c);
                    i++;
                    while (i < length && (char.IsLetterOrDigit(alternative[i]) || alternative[i] == '\''))
                    {
                        token.Append(alternative[i]);
                        i++;
                    }
                    i--;
                    symbols.Add(token.ToString());
                    continue;
                }

                if (char.IsLower(c) || char.IsDigit(c) || c == '_')
                {
                    FlushCurrent();
                    var token = new StringBuilder();
                    token.Append(c);
                    i++;
                    while (i < length && (char.IsLower(alternative[i]) || char.IsDigit(alternative[i]) || alternative[i] == '_'))
                    {
                        token.Append(alternative[i]);
                        i++;
                    }
                    i--;
                    symbols.Add(token.ToString());
                    continue;
                }

                if (c == '\\' && i + 1 < length)
                {
                    FlushCurrent();
                    i++;
                    symbols.Add(alternative[i].ToString());
                    continue;
                }

                if (IsPunctuationSymbol(c))
                {
                    FlushCurrent();
                    symbols.Add(c.ToString());
                    continue;
                }

                // Cualquier otro carácter distinto se trata como símbolo independiente
                FlushCurrent();
                symbols.Add(c.ToString());
            }

            FlushCurrent();
            return symbols;
        }

        private static bool IsPunctuationSymbol(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/' || c == '(' || c == ')' || c == '[' || c == ']' || c == '{' || c == '}' || c == ',' || c == ':' || c == ';' || c == '.' || c == '?' || c == '|' || c == '=';
        }

        private static bool IsEpsilonToken(string token)
        {
            return token != null && EpsilonTokens.Contains(token.Trim());
        }

        public bool IsNonTerminal(string symbol)
        {
            return symbol != null && NonTerminals.Contains(symbol);
        }

        public bool IsTerminal(string symbol)
        {
            if (symbol == null)
                return false;
            if (IsEpsilonToken(symbol))
                return false;
            return !IsNonTerminal(symbol);
        }

        public Dictionary<string, HashSet<string>> ComputeFirst()
        {
            var first = NonTerminals.ToDictionary(nt => nt, nt => new HashSet<string>());
            bool changed;
            do
            {
                changed = false;
                foreach (var production in Productions)
                {
                    var left = production.Left;
                    var firstRight = FirstOfSequence(production.Right, first);
                    foreach (var symbol in firstRight)
                    {
                        if (first[left].Add(symbol))
                            changed = true;
                    }
                }
            } while (changed);

            return first;
        }

        public Dictionary<string, HashSet<string>> ComputeFollow(Dictionary<string, HashSet<string>> first)
        {
            var follow = NonTerminals.ToDictionary(nt => nt, nt => new HashSet<string>());
            if (!string.IsNullOrEmpty(StartSymbol))
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
                        var symbol = right[i];
                        if (!IsNonTerminal(symbol))
                            continue;

                        var nextSequence = right.Skip(i + 1).ToList();
                        var firstNext = FirstOfSequence(nextSequence, first);

                        foreach (var terminal in firstNext.Where(t => !IsEpsilonToken(t)))
                        {
                            if (follow[symbol].Add(terminal))
                                changed = true;
                        }

                        if (nextSequence.Count == 0 || firstNext.Any(IsEpsilonToken))
                        {
                            foreach (var terminal in follow[left])
                            {
                                if (follow[symbol].Add(terminal))
                                    changed = true;
                            }
                        }
                    }
                }
            } while (changed);

            return follow;
        }

        private HashSet<string> FirstOfSequence(List<string> symbols, Dictionary<string, HashSet<string>> first)
        {
            var result = new HashSet<string>();
            if (symbols == null || symbols.Count == 0)
            {
                result.Add("ε");
                return result;
            }

            bool allEpsilon = true;
            foreach (var symbol in symbols)
            {
                if (IsEpsilonToken(symbol))
                {
                    continue;
                }

                if (IsTerminal(symbol))
                {
                    result.Add(symbol);
                    allEpsilon = false;
                    break;
                }

                var firstSymbol = first.ContainsKey(symbol) ? first[symbol] : new HashSet<string>();
                foreach (var item in firstSymbol.Where(s => !IsEpsilonToken(s)))
                    result.Add(item);

                if (!firstSymbol.Any(IsEpsilonToken))
                {
                    allEpsilon = false;
                    break;
                }
            }

            if (allEpsilon)
                result.Add("ε");

            return result;
        }

        public LL1TableResult BuildLL1Table(Dictionary<string, HashSet<string>> first, Dictionary<string, HashSet<string>> follow)
        {
            var terminals = Terminals.OrderBy(t => t).ToList();
            if (!terminals.Contains("$"))
                terminals.Add("$");

            var table = NonTerminals.ToDictionary(nt => nt, nt => new Dictionary<string, string>());
            var conflicts = new List<string>();

            foreach (var production in Productions)
            {
                var left = production.Left;
                var firstAlpha = FirstOfSequence(production.Right, first);
                foreach (var terminal in firstAlpha.Where(t => !IsEpsilonToken(t)))
                {
                    AddTableEntry(table, conflicts, left, terminal, production);
                }

                if (firstAlpha.Any(IsEpsilonToken))
                {
                    foreach (var terminal in follow[left])
                    {
                        AddTableEntry(table, conflicts, left, terminal, production);
                    }
                }
            }

            return new LL1TableResult
            {
                NonTerminals = new List<string>(NonTerminals),
                Terminals = terminals,
                Table = table,
                Conflicts = conflicts
            };
        }

        private void AddTableEntry(Dictionary<string, Dictionary<string, string>> table, List<string> conflicts, string left, string terminal, Production production)
        {
            if (!table[left].TryGetValue(terminal, out var existing))
            {
                table[left][terminal] = production.ToString();
                return;
            }

            if (!string.Equals(existing, production.ToString(), StringComparison.Ordinal))
            {
                conflicts.Add($"Conflicto en tabla LL(1): [{left}, {terminal}] ya tiene '{existing}' y se intenta agregar '{production}'.");
            }
        }
    }

    public class Production
    {
        public string Left { get; }
        public List<string> Right { get; }

        public Production(string left, List<string> right)
        {
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            var rightSide = Right.Count == 0 ? "ε" : string.Join(" ", Right);
            return $"{Left} -> {rightSide}";
        }
    }

    public class LL1TableResult
    {
        public List<string> NonTerminals { get; set; }
        public List<string> Terminals { get; set; }
        public Dictionary<string, Dictionary<string, string>> Table { get; set; }
        public List<string> Conflicts { get; set; }
    }
}
