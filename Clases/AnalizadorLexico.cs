using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Clases
{
    public class AnalizadorLexico
    {
        private int token;
        private int EdoActual;
        private int EdoTransicion;

        private string CadenaSigma;
        public string Lexema;

        private bool PasoPorEdoAcept;
        private int IniLexema;
        private int FinLexema;
        private int IndiceCaracterActual;
        private char CaracterActual;

        private Stack<EstadoAnalizLexico> Pila;
        private AFD AutomataFD;

        public AnalizadorLexico()
        {
            CadenaSigma = "";
            Lexema = "";
            PasoPorEdoAcept = false;
            IniLexema = 0;
            FinLexema = -1;
            IndiceCaracterActual = 0;
            token = -1;
            Pila = new Stack<EstadoAnalizLexico>();
            AutomataFD = null;
        }

        public AnalizadorLexico(AFD afd, string sigma)
        {
            AutomataFD = afd;
            CadenaSigma = sigma;
            Lexema = "";
            PasoPorEdoAcept = false;
            IniLexema = 0;
            FinLexema = -1;
            IndiceCaracterActual = 0;
            token = -1;
            Pila = new Stack<EstadoAnalizLexico>();
        }

        public void SetSigma(string sigma)
        {
            CadenaSigma = sigma;
            Lexema = "";
            IniLexema = 0;
            FinLexema = -1;
            IndiceCaracterActual = 0;
            token = -1;
            PasoPorEdoAcept = false;
            Pila.Clear();
        }

        public EstadoAnalizLexico GetEdoAnalizLexico()
        {
            return new EstadoAnalizLexico
            {
                Token = token,
                EdoActual = EdoActual,
                EdoTransicion = EdoTransicion,
                Lexema = Lexema,
                PasoPorEdoAcept = PasoPorEdoAcept,
                IniLexema = IniLexema,
                FinLexema = FinLexema,
                IndiceCaracterActual = IndiceCaracterActual
            };
        }

        public bool SetEdoAnalizLexico(EstadoAnalizLexico edo)
        {
            if (edo == null)
                return false;

            token = edo.Token;
            EdoActual = edo.EdoActual;
            EdoTransicion = edo.EdoTransicion;
            Lexema = edo.Lexema;
            PasoPorEdoAcept = edo.PasoPorEdoAcept;
            IniLexema = edo.IniLexema;
            FinLexema = edo.FinLexema;
            IndiceCaracterActual = edo.IndiceCaracterActual;

            return true;
        }

        public bool UndoToken()
        {
            if (Pila.Count == 0)
                return false;

            EstadoAnalizLexico edoAnterior = Pila.Pop();
            return SetEdoAnalizLexico(edoAnterior);
        }

        public int yylex()
        {
            if (AutomataFD == null)
                throw new Exception("No hay AFD cargado en el analizador léxico");

            Lexema = "";
            PasoPorEdoAcept = false;
            token = -1;

            while (IndiceCaracterActual < CadenaSigma.Length &&
                   char.IsWhiteSpace(CadenaSigma[IndiceCaracterActual]))
            {
                IndiceCaracterActual++;
            }

            if (IndiceCaracterActual >= CadenaSigma.Length)
                return 0; // Fin de cadena

            Pila.Push(GetEdoAnalizLexico());

            IniLexema = IndiceCaracterActual;
            FinLexema = -1;
            EdoActual = AutomataFD.EstadoInicial;

            List<char> alfabeto = AutomataFD.Alfabeto.OrderBy(c => c).ToList();

            while (IndiceCaracterActual < CadenaSigma.Length)
            {
                CaracterActual = CadenaSigma[IndiceCaracterActual];

                int indiceAlfabeto = alfabeto.IndexOf(CaracterActual);

                if (indiceAlfabeto == -1)
                    break;

                AFD.ConjIj estado = AutomataFD.EdosAFD.FirstOrDefault(e => e.j == EdoActual);

                if (estado == null)
                    break;

                EdoTransicion = estado.TransicionesAFD[indiceAlfabeto];

                if (EdoTransicion == -1)
                    break;

                EdoActual = EdoTransicion;
                IndiceCaracterActual++;

                AFD.ConjIj nuevoEstado = AutomataFD.EdosAFD.FirstOrDefault(e => e.j == EdoActual);

                if (nuevoEstado != null && nuevoEstado.EsAceptacion)
                {
                    PasoPorEdoAcept = true;
                    token = nuevoEstado.Token;
                    FinLexema = IndiceCaracterActual;
                }
            }

            if (PasoPorEdoAcept)
            {
                Lexema = CadenaSigma.Substring(IniLexema, FinLexema - IniLexema);
                IndiceCaracterActual = FinLexema;
                return token;
            }

            Lexema = CadenaSigma[IniLexema].ToString();
            IndiceCaracterActual = IniLexema + 1;
            return -1; // Error léxico
        }
    }

    public class EstadoAnalizLexico
    {
        public int Token { get; set; }
        public int EdoActual { get; set; }
        public int EdoTransicion { get; set; }
        public string Lexema { get; set; }
        public bool PasoPorEdoAcept { get; set; }
        public int IniLexema { get; set; }
        public int FinLexema { get; set; }
        public int IndiceCaracterActual { get; set; }
    }
}