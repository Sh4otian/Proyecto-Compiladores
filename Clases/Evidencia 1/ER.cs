using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp1.AFN;

namespace ConsoleApp1.Clases
{
    internal class ER
    {
        public class Token
        {
            public string Valor;
            public bool EsOperador;
            public bool EsRango = false;
            public char RangoInicio;
            public char RangoFin;
        }

        public static bool EsOperador(char c)
        {
            return c == '|' || c == '.' || c == '*' || c == '+' || c == '?';
        }

        public static int Precedencia(string op)
        {
            switch (op)
            {
                case "*":
                case "+":
                case "?": return 3;
                case ".": return 2;
                case "|": return 1;
                default: return 0;
            }
        }

        static bool EsUnario(string op)
        {
            return op == "*" || op == "+" || op == "?";
        }

        // ================= TOKENIZAR =================
        public static List<Token> Tokenizar(string exp)
        {
            var tokens = new List<Token>();

            for (int i = 0; i < exp.Length; i++)
            {
                char c = exp[i];

                if (c == '\\')
                {
                    tokens.Add(new Token { Valor = exp[i + 1].ToString(), EsOperador = false });
                    i++;
                }
                else if (EsOperador(c))
                {
                    tokens.Add(new Token { Valor = c.ToString(), EsOperador = true });
                }
                else if (c == '(' || c == ')')
                {
                    tokens.Add(new Token { Valor = c.ToString(), EsOperador = true });
                }
                else if (c == '[')
                {
                    i++;
                    if (i + 2 >= exp.Length || exp[i + 1] != '-')
                        throw new Exception("Formato de rango inválido");

                    char inicio = exp[i];
                    char fin = exp[i + 2];

                    if (inicio > fin)
                        throw new Exception($"Rango inválido: {inicio}-{fin}");

                    tokens.Add(new Token
                    {
                        EsOperador = false,
                        EsRango = true,
                        RangoInicio = inicio,
                        RangoFin = fin,
                        Valor = $"{inicio}-{fin}"
                    });

                    i += 3; // saltar rango
                }
                else
                {
                    tokens.Add(new Token { Valor = c.ToString(), EsOperador = false });
                }
            }

            return tokens;
        }
        // ================= CONCATENACIÓN =================
        public static List<Token> InsertarConcatenacion(List<Token> tokens)
        {
            var resultado = new List<Token>();

            for (int i = 0; i < tokens.Count; i++)
            {
                resultado.Add(tokens[i]);

                if (i < tokens.Count - 1)
                {
                    var a = tokens[i];
                    var b = tokens[i + 1];

                    if (
                        (!a.EsOperador || a.Valor == ")" || EsUnario(a.Valor)) &&
                        (!b.EsOperador || b.Valor == "(")
                    )
                    {
                        resultado.Add(new Token { Valor = ".", EsOperador = true });
                    }
                }
            }

            return resultado;
        }

        // ================= INFIX → POSTFIX =================
        public static List<Token> InfijaAPostfija(List<Token> tokens)
        {
            var salida = new List<Token>();
            var pila = new Stack<Token>();

            foreach (var token in tokens)
            {
                if (!token.EsOperador)
                {
                    salida.Add(token);
                }
                else if (token.Valor == "(")
                {
                    pila.Push(token);
                }
                else if (token.Valor == ")")
                {
                    while (pila.Peek().Valor != "(")
                        salida.Add(pila.Pop());

                    pila.Pop(); // quitar "("
                }
                else
                {
                    while (pila.Count > 0 &&
                           Precedencia(pila.Peek().Valor) >= Precedencia(token.Valor))
                    {
                        salida.Add(pila.Pop());
                    }

                    pila.Push(token);
                }
            }

            while (pila.Count > 0)
                salida.Add(pila.Pop());

            return salida;
        }

        // ================= EVALUAR POSTFIJA =================
        public static string EvaluarPostfija(List<Token> tokens)
        {
            var pila = new Stack<string>();

            foreach (var token in tokens)
            {
                if (!token.EsOperador)
                {
                    pila.Push(token.Valor);
                }
                else
                {
                    if (EsUnario(token.Valor))
                    {
                        string a = pila.Pop();
                        pila.Push($"({a}){token.Valor}");
                    }
                    else
                    {
                        string b = pila.Pop();
                        string a = pila.Pop();

                        if (token.Valor == "|")
                            pila.Push($"({a}|{b})");
                        else if (token.Valor == ".")
                            pila.Push($"{a}{b}");
                    }
                }
            }

            return pila.Pop();
        }
        public static AFNo ConstruirAFNDesdePostfija(List<Token> postfija)
        {
            Stack<AFNo> pila = new Stack<AFNo>();

            foreach (var token in postfija)
            {
                if (!token.EsOperador)
                {
                    if (token.EsRango)
                    {
                        pila.Push(AFNo.CrearAFNBasico(token.RangoInicio, token.RangoFin));
                    }
                    else
                    {
                        char c = token.Valor[0];
                        pila.Push(AFNo.CrearAFNBasico(c, c));
                    }
                }
                else
                {
                    if (token.Valor == "*")
                    {
                        var a = pila.Pop();
                        a.CerraduraKleene();
                        pila.Push(a);
                    }
                    else if (token.Valor == "+")
                    {
                        var a = pila.Pop();
                        a.CerraduraPositiva();
                        pila.Push(a);
                    }
                    else if (token.Valor == "?")
                    {
                        var a = pila.Pop();
                        a.Opcional();
                        pila.Push(a);
                    }
                    else if (token.Valor == ".")
                    {
                        var b = pila.Pop();
                        var a = pila.Pop();
                        a.Concatenar(b);
                        pila.Push(a);
                    }
                    else if (token.Valor == "|")
                    {
                        var b = pila.Pop();
                        var a = pila.Pop();
                        pila.Push(a.UnirAFN(b));
                    }
                }
            }

            return pila.Pop();
        }


    }
}
