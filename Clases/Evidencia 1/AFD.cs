using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static ConsoleApp1.AFN;
using static ConsoleApp1.Clases.CompAFN;

namespace ConsoleApp1.Clases
{
    public class AFD
    {
        const char EPSILON = '\0';

        // CLASE ConjIj (ConjuntoIj) —  representa un estado del AFD
        // Cada estado AFD es un CONJUNTO de estados AFN
        public class ConjIj
        {
            public HashSet<Estado> ConjI;   // conjunto de estados AFN
            public int j;                   // id del estado AFD
            public int[] TransicionesAFD;   // TransicionesAFD[r] = id estado AFD destino con símbolo r
            public bool EsAceptacion;
            public int Token = -1;

            public ConjIj(int cardAlfabeto)
            {
                ConjI = new HashSet<Estado>();
                TransicionesAFD = new int[cardAlfabeto];
                for (int i = 0; i < cardAlfabeto; i++)
                    TransicionesAFD[i] = -1; // -1 = sin transición
            }
        }

        // CAMPOS DEL AFD

        public HashSet<ConjIj> EdosAFD = new HashSet<ConjIj>();
        public int EstadoInicial = 0;
        public HashSet<char> Alfabeto = new HashSet<char>();

        // GUARDAR AFD EN ARCHIVO

        public void GuardarAFD(string ruta)
        {
            char[] arrAlfabeto = Alfabeto.ToArray();
            int cardAlfabeto = arrAlfabeto.Length;
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Alfabeto: " + string.Join(",", arrAlfabeto));
            sb.AppendLine("Inicial: " + EstadoInicial);
            sb.AppendLine("Estados: " + string.Join(",", EdosAFD.OrderBy(e => e.j).Select(e => e.j)));
            sb.AppendLine("Aceptacion: " + string.Join(",", EdosAFD.Where(e => e.EsAceptacion).Select(e => e.j)));
            sb.AppendLine("Tokens: " + string.Join(",", EdosAFD.Where(e => e.EsAceptacion).Select(e => $"{e.j}:{e.Token}")));
            sb.AppendLine("Transiciones:");

            foreach (ConjIj estado in EdosAFD.OrderBy(e => e.j))
                for (int r = 0; r < cardAlfabeto; r++)
                    if (estado.TransicionesAFD[r] != -1)
                        sb.AppendLine($"{estado.j},{arrAlfabeto[r]},{estado.TransicionesAFD[r]}");

            File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
        }

        // CARGAR AFD DESDE ARCHIVO
        public static AFD CargarAFD(string ruta)
        {
            AFD afd = new AFD();
            string[] lineas = File.ReadAllLines(ruta, Encoding.UTF8);

            char[] arrAlfabeto = null;
            var tokenMap = new Dictionary<int, int>();
            var estadosAcept = new HashSet<int>();
            var transTemp = new List<(int desde, char simbolo, int hacia)>();
            var idsEstados = new List<int>();

            foreach (string linea in lineas)
            {
                if (linea.StartsWith("Alfabeto:"))
                {
                    var partes = linea.Replace("Alfabeto:", "").Trim().Split(',');
                    arrAlfabeto = partes.Where(p => p.Trim().Length == 1)
                                       .Select(p => p.Trim()[0]).ToArray();
                    foreach (char c in arrAlfabeto)
                        afd.Alfabeto.Add(c);
                }
                else if (linea.StartsWith("Inicial:"))
                    afd.EstadoInicial = int.Parse(linea.Replace("Inicial:", "").Trim());
                else if (linea.StartsWith("Estados:"))
                {
                    foreach (var p in linea.Replace("Estados:", "").Trim().Split(','))
                        if (int.TryParse(p.Trim(), out int id))
                            idsEstados.Add(id);
                }
                else if (linea.StartsWith("Aceptacion:"))
                {
                    foreach (var p in linea.Replace("Aceptacion:", "").Trim().Split(','))
                        if (int.TryParse(p.Trim(), out int id))
                            estadosAcept.Add(id);
                }
                else if (linea.StartsWith("Tokens:"))
                {
                    foreach (var p in linea.Replace("Tokens:", "").Trim().Split(','))
                    {
                        var kv = p.Trim().Split(':');
                        if (kv.Length == 2 && int.TryParse(kv[0], out int id) && int.TryParse(kv[1], out int tok))
                            tokenMap[id] = tok;
                    }
                }
                else if (linea.StartsWith("Transiciones:")) continue;
                else if (linea.Contains(","))
                {
                    var partes = linea.Trim().Split(',');
                    if (partes.Length == 3 &&
                        int.TryParse(partes[0], out int desde) &&
                        partes[1].Trim().Length == 1 &&
                        int.TryParse(partes[2], out int hacia))
                        transTemp.Add((desde, partes[1].Trim()[0], hacia));
                }
            }

            // Construir estados
            int card = arrAlfabeto?.Length ?? 0;
            foreach (int id in idsEstados)
                afd.EdosAFD.Add(new ConjIj(card)
                {
                    j = id,
                    EsAceptacion = estadosAcept.Contains(id),
                    Token = tokenMap.ContainsKey(id) ? tokenMap[id] : -1
                });

            // Asignar transiciones
            foreach (var (desde, simbolo, hacia) in transTemp)
            {
                ConjIj edo = afd.EdosAFD.FirstOrDefault(e => e.j == desde);
                if (edo != null && arrAlfabeto != null)
                {
                    int r = IndiceCaracter(arrAlfabeto, simbolo);
                    if (r != -1) edo.TransicionesAFD[r] = hacia;
                }
            }

            return afd;
        }

        // ANALIZAR CADENA

        public bool AnalizarCadena(string cadena)
        {
            char[] arrAlfabeto = Alfabeto.ToArray();
            int estadoActual = EstadoInicial;

            foreach (char c in cadena)
            {
                ConjIj edo = EdosAFD.FirstOrDefault(e => e.j == estadoActual);
                if (edo == null) return false;

                int r = IndiceCaracter(arrAlfabeto, c);
                if (r == -1 || edo.TransicionesAFD[r] == -1) return false;

                estadoActual = edo.TransicionesAFD[r];
            }

            ConjIj edoFinal = EdosAFD.FirstOrDefault(e => e.j == estadoActual);
            return edoFinal != null && edoFinal.EsAceptacion;
        }

        // ANALIZADOR LÉXICO
        public List<(string lexema, int token)> AnalizarLexico(string entrada)
        {
            char[] arrAlfabeto = Alfabeto.ToArray();
            var resultado = new List<(string, int)>();
            int i = 0;

            while (i < entrada.Length)
            {
                if (char.IsWhiteSpace(entrada[i])) { i++; continue; }

                int estadoActual = EstadoInicial;
                int ultimoToken = -1;
                int posUltima = i;
                int j = i;

                while (j < entrada.Length)
                {
                    ConjIj edo = EdosAFD.FirstOrDefault(e => e.j == estadoActual);
                    if (edo == null) break;

                    int r = IndiceCaracter(arrAlfabeto, entrada[j]);
                    if (r == -1 || edo.TransicionesAFD[r] == -1) break;

                    estadoActual = edo.TransicionesAFD[r];
                    j++;

                    ConjIj edoActual = EdosAFD.FirstOrDefault(e => e.j == estadoActual);
                    if (edoActual != null && edoActual.EsAceptacion)
                    {
                        ultimoToken = edoActual.Token;
                        posUltima = j;
                    }
                }

                if (ultimoToken == -1)
                {
                    resultado.Add((entrada[i].ToString(), -1));
                    i++;
                }
                else
                {
                    resultado.Add((entrada.Substring(i, posUltima - i), ultimoToken));
                    i = posUltima;
                }
            }

            return resultado;
        }

        // HELPERS para que AFNo los use en ConvertirAFD()

        // ε-clausura de un estado individual (cerraura epsilon)
        internal static HashSet<Estado> CerraduraEpsilon(Estado edo)
        {
            return CerraduraEpsilonSet(new HashSet<Estado> { edo });
        }

        // ε-clausura de un conjunto de estados (cerradura epsilon)
        internal static HashSet<Estado> CerraduraEpsilonSet(HashSet<Estado> estados)
        {
            HashSet<Estado> clausura = new HashSet<Estado>(estados);
            Stack<Estado> pila = new Stack<Estado>(estados);

            while (pila.Count > 0)
            {
                Estado e = pila.Pop();
                foreach (Transicion t in e.Transiciones)
                    if (t.simbolo.Contains(EPSILON) && !clausura.Contains(t.edosig))
                    {
                        clausura.Add(t.edosig);
                        pila.Push(t.edosig);
                    }
            }

            return clausura;
        }

        // Ir_A: mover un conjunto con un símbolo + ε-clausura 
        internal static HashSet<Estado> Ir_A(HashSet<Estado> estados, char simbolo)
        {
            HashSet<Estado> mover = new HashSet<Estado>();
            foreach (Estado e in estados)
                foreach (Transicion t in e.Transiciones)
                    if (t.simbolo.Contains(simbolo))
                        mover.Add(t.edosig);

            return CerraduraEpsilonSet(mover);
        }

        // Índice de un carácter en el arreglo del alfabeto
        internal static int IndiceCaracter(char[] arrAlfabeto, char c)
        {
            for (int i = 0; i < arrAlfabeto.Length; i++)
                if (arrAlfabeto[i] == c) return i;
            return -1;
        }
    }
}