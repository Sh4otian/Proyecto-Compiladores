using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.Clases.Grammar;

namespace ConsoleApp1.Clases
{
    public class ConversionGram
    {
        public Grammar Parse(string input)
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
                    production.Id =
    grammar.Productions.Count;


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
        public void Validar(
    Grammar grammar)
        {
            if (grammar.Productions.Count == 0)
                throw new Exception(
                    "La gramática no tiene producciones.");

            var first =
                grammar.Productions[0];

            // Debe tener exactamente un símbolo
            if (first.Right.Count != 1)
            {
                throw new Exception(
                    "La primera producción debe ser aumentada.");
            }

            // S' -> S
            string start =
                first.Right[0];

            if (!grammar.NonTerminals.Contains(start))
            {
                throw new Exception(
                    "Producción aumentada inválida.");
            }
        }
    }
}
