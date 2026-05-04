using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ConsoleApp1.Clases.CompAFN;
using ConsoleApp1.Clases; // para usar AFD

namespace ConsoleApp1
{
    public class AFN
    {
        public class AFNo
        {
            const char EPSILON = '\0';
            public int IdAFN = 0;
            //static int cont = 0;
            Estado EdoInicial = new Estado();
            HashSet<char> Alfabeto = new HashSet<char>();
            HashSet<Estado> EstadosAFN = new HashSet<Estado>();
            HashSet<Estado> EstadosAcept = new HashSet<Estado>();
            public AFNo()
            {
                IdAFN = 0;
            }

            public void AsignarNumeros()
            {
                int i = 0;
                foreach (Estado e in EstadosAFN)
                    e.Num = i++;
            }

            public void RecolectarEstados()
            {
                HashSet<Estado> visitados = new HashSet<Estado>();
                Queue<Estado> cola = new Queue<Estado>();

                cola.Enqueue(EdoInicial);
                visitados.Add(EdoInicial);

                while (cola.Count > 0)
                {
                    Estado actual = cola.Dequeue();
                    foreach (var t in actual.Transiciones)
                    {
                        Estado siguiente = t.edosig;
                        if (!visitados.Contains(siguiente))
                        {
                            visitados.Add(siguiente);
                            cola.Enqueue(siguiente);
                        }
                    }
                }

                EstadosAFN = visitados;
            }
            public void GuardarAFN(string ruta)
            {
                // 1️⃣ Recolectar todos los estados reales
                RecolectarEstados();

                // 2️⃣ Asignar números
                AsignarNumeros();

                // 3️⃣ Crear el StringBuilder
                StringBuilder sb = new StringBuilder();

                // Q = Estados
                sb.AppendLine("Estados: " + string.Join(",", EstadosAFN.Select(e => e.Num)));

                // Σ = Alfabeto
                sb.AppendLine("Alfabeto: " + string.Join(",", Alfabeto));

                // q0 = Estado inicial
                sb.AppendLine("Inicial: " + EdoInicial.Num);

                // F = Estados de aceptación
                sb.AppendLine("Aceptacion: " + string.Join(",", EstadosAcept.Select(e => e.Num)));

                // δ = Transiciones
                sb.AppendLine("Transiciones:");
                foreach (Estado e in EstadosAFN)
                {
                    foreach (Transicion t in e.Transiciones)
                    {
                        foreach (char c in t.simbolo)
                        {
                            string simbolo = (c == EPSILON) ? "ε" : c.ToString();
                            sb.AppendLine($"{e.Num},{simbolo},{t.edosig.Num}");
                        }
                    }
                }

                // 4️⃣ Escribir todo al archivo de una vez
                File.WriteAllText(ruta, sb.ToString(), Encoding.UTF8);
            }
            public static AFNo CrearAFNBasico(char c1, char c2) //Cambiado debido a la manera en como funciona la Tabla.
            {
                AFNo F = new AFNo();
                Estado E1 = new Estado();
                Estado E2 = new Estado();
                Transicion T = new Transicion(); // genera otra transicion con un simbolo y dando el estado final
                for(char C=c1; C<=c2; C++)
                {
                    T.simbolo.Add(C);
                    F.Alfabeto.Add(C); //se agrega al alfabeto viable
                }
                E1.Transiciones.Add(T);
                T.edosig = E2;
                E2.edoacept = true;
                F.EstadosAFN.Clear();
                F.EdoInicial = E1;
                F.EstadosAFN.Add(E1);
                F.EstadosAFN.Add(E2);
                F.EstadosAcept.Add(E2);
                return F;
            }
            public AFNo UnirAFN(AFNo F2)
            {
                Estado E1 = new Estado();
                Estado E2 = new Estado();
                AFNo F = new AFNo();
                E1.Transiciones.Add(new Transicion(EPSILON, this.EdoInicial));
                E1.Transiciones.Add(new Transicion(EPSILON, F2.EdoInicial));
                foreach (Estado e in this.EstadosAcept)
                {
                    e.Transiciones.Add(new Transicion(EPSILON, E2));
                    e.edoacept = false;
                }
                foreach (Estado e in F2.EstadosAcept)
                {
                    e.Transiciones.Add(new Transicion(EPSILON, E2));
                    e.edoacept = false;
                }
                E2.edoacept = true;
                this.EdoInicial = E1;
                this.Alfabeto.UnionWith(F2.Alfabeto);
                this.EstadosAFN.UnionWith(F2.EstadosAFN);
                this.EstadosAFN.Add(E1);
                this.EstadosAFN.Add(E2);
                this.EstadosAcept.Clear();
                this.EstadosAcept.Add(E2);
                return this;
            }
            public void Concatenar(AFNo B)
            {
                foreach (Estado e in this.EstadosAcept)
                {
                    e.edoacept = false;
                    e.Transiciones.Add(new Transicion(EPSILON, B.EdoInicial)); // ε
                }

                this.EstadosAcept = B.EstadosAcept;

                foreach (Estado e in B.EstadosAFN)
                    this.EstadosAFN.Add(e);

                foreach (char c in B.Alfabeto)
                    this.Alfabeto.Add(c);
            }
            public void CerraduraKleene()
            {
                Estado nuevoIni = new Estado();
                Estado nuevoFin = new Estado();
                nuevoFin.edoacept = true;

                nuevoIni.Transiciones.Add(new Transicion(EPSILON, this.EdoInicial));
                nuevoIni.Transiciones.Add(new Transicion(EPSILON, nuevoFin));

                foreach (Estado e in this.EstadosAcept)
                {
                    e.Transiciones.Add(new Transicion(EPSILON, this.EdoInicial));
                    e.Transiciones.Add(new Transicion(EPSILON, nuevoFin));
                    e.edoacept = false;
                }

                this.EdoInicial = nuevoIni;
                this.EstadosAcept = new HashSet<Estado> { nuevoFin };

                this.EstadosAFN.Add(nuevoIni);
                this.EstadosAFN.Add(nuevoFin);
            }
            public void CerraduraPositiva()
            {
                Estado nuevoIni = new Estado();
                Estado nuevoFin = new Estado();
                nuevoFin.edoacept = true;

                nuevoIni.Transiciones.Add(new Transicion(EPSILON, this.EdoInicial));

                foreach (Estado e in this.EstadosAcept)
                {
                    e.Transiciones.Add(new Transicion(EPSILON, this.EdoInicial));
                    e.Transiciones.Add(new Transicion(EPSILON, nuevoFin));
                    e.edoacept = false;
                }

                this.EdoInicial = nuevoIni;
                this.EstadosAcept = new HashSet<Estado> { nuevoFin };

                this.EstadosAFN.Add(nuevoIni);
                this.EstadosAFN.Add(nuevoFin);
            }
            public void Opcional()
            {
                Estado nuevoIni = new Estado();
                Estado nuevoFin = new Estado();
                nuevoFin.edoacept = true;

                nuevoIni.Transiciones.Add(new Transicion(EPSILON, this.EdoInicial));
                nuevoIni.Transiciones.Add(new Transicion(EPSILON, nuevoFin));

                foreach (Estado e in this.EstadosAcept)
                {
                    e.Transiciones.Add(new Transicion(EPSILON, nuevoFin));
                    e.edoacept = false;
                }

                this.EdoInicial = nuevoIni;
                this.EstadosAcept = new HashSet<Estado> { nuevoFin };

                this.EstadosAFN.Add(nuevoIni);
                this.EstadosAFN.Add(nuevoFin);
            }
            public void Prueba()
            {
                AFNo afn = new AFNo();

                // Estado inicial ya existe en afn.EdoInicial
                Estado e1 = afn.EdoInicial;

                // Crear un nuevo estado de aceptación
                Estado e2 = new Estado();
                e2.edoacept = true;

                // Crear una transición: 0 --a--> 1
                e1.Transiciones.Add(new Transicion('a', e2));

                // Registrar en AFN
                afn.EstadosAFN.Add(e2);
                afn.EstadosAcept.Add(e2);
                afn.Alfabeto.Add('a');

                // Guardar
                afn.GuardarAFN("afn.txt");
            }
            public void AsignarToken(int token)
            {
                foreach (Estado e in EstadosAcept)
                {
                    e.token = token;
                }
            }
            public AFD ConvAFNaAFD()
            {
                int CardAlfabeto;// NumEdosAFD;
                int i, j, r;
                char[] ArrAlfabeto;
                AFD.ConjIj Ij, Ik;
                bool existe;

                HashSet<Estado> ConjAux = new HashSet<Estado>();
                HashSet<AFD.ConjIj> EdosAFD = new HashSet<AFD.ConjIj>();
                Queue<AFD.ConjIj> EdosSinAnalizar = new Queue<AFD.ConjIj>();

                EdosAFD.Clear();
                EdosSinAnalizar.Clear();

                CardAlfabeto = Alfabeto.Count;
                ArrAlfabeto = new char[CardAlfabeto];
                i = 0;
                foreach (char c in Alfabeto)
                    ArrAlfabeto[i++] = c;

                j = 0; // Contador para los estados del AFD
                Ij = new AFD.ConjIj(CardAlfabeto)
                {
                    ConjI = AFD.CerraduraEpsilon(EdoInicial),
                    j = j
                };

                EdosAFD.Add(Ij);
                EdosSinAnalizar.Enqueue(Ij);
                j++;

                while (EdosSinAnalizar.Count != 0) // Mientras se tengan estados Ij sin analizar
                {
                    Ij = EdosSinAnalizar.Dequeue();

                    // Calcular el IrA del Ij con cada símbolo del alfabeto
                    foreach (char c in ArrAlfabeto)
                    {
                        Ik = new AFD.ConjIj(CardAlfabeto)
                        {
                            ConjI = AFD.Ir_A(Ij.ConjI, c)
                        };

                        if (Ik.ConjI.Count == 0) // Si el conjunto fue vacío (No hubo transiciones)
                            continue;

                        // Revisar si el conjunto de estados ya existe
                        existe = false;
                        foreach (AFD.ConjIj I in EdosAFD)
                        {
                            if (I.ConjI.SetEquals(Ik.ConjI))
                            {
                                existe = true;
                                // El conjunto ya existe → la transición del Estado Ij.j con c va a I.j
                                r = AFD.IndiceCaracter(ArrAlfabeto, c);
                                Ij.TransicionesAFD[r] = I.j;
                                break;
                            }
                        }

                        if (!existe) // Si el conjunto Ik no existía, será un nuevo estado
                        {
                            Ik.j = j; // Le ponemos su índice (numeración) al nuevo estado
                            r = AFD.IndiceCaracter(ArrAlfabeto, c);
                            Ij.TransicionesAFD[r] = Ik.j;
                            EdosAFD.Add(Ik);           // Se agrega el nuevo estado a la colección
                            EdosSinAnalizar.Enqueue(Ik); // Al ser nuevo estado, falta por analizar
                            j++;
                        }
                    }
                }

                // Determinar cuáles estados del AFD son de aceptación
                foreach (AFD.ConjIj I in EdosAFD)
                {
                    foreach (Estado e in I.ConjI)
                    {
                        if (e.edoacept)
                        {
                            I.EsAceptacion = true;
                            if (e.token != -1)
                                I.Token = e.token; // conservar el token del AFN
                            break;
                        }
                    }
                }

                // Construir y retornar el objeto AFD
                AFD afd = new AFD();
                afd.EdosAFD = EdosAFD;
                afd.EstadoInicial = 0;
                afd.Alfabeto = new HashSet<char>(Alfabeto);

                return afd;
            }
            public static AFNo UnirAFNs(List<(AFNo afn, int token)> lista)
            {
                AFNo nuevo = new AFNo();
                Estado nuevoInicial = new Estado();

                nuevo.EdoInicial = nuevoInicial;

                foreach (var item in lista)
                {
                    AFNo afn = item.afn;
                    int token = item.token;

                    // Asignar token a estados finales
                    afn.AsignarToken(token);

                    // Conectar con epsilon
                    nuevoInicial.Transiciones.Add(new Transicion('\0', afn.EdoInicial));

                    // Unir estructuras
                    nuevo.EstadosAFN.UnionWith(afn.EstadosAFN);
                    nuevo.Alfabeto.UnionWith(afn.Alfabeto);
                    nuevo.EstadosAcept.UnionWith(afn.EstadosAcept);
                }

                nuevo.EstadosAFN.Add(nuevoInicial);

                return nuevo;
            }
        }
    }
}