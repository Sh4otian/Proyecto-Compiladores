using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static ConsoleApp1.AFN;
using static ConsoleApp1.Clases.ER;

namespace ConsoleApp1
{

    public partial class Form1 : Form
    {
        List<AFNo> afns = new List<AFNo>();
        int cont = 0;
        //List<AFD> afds = new();
        //AFD afdActual;

        public Form1()
        {
            InitializeComponent();
            AFNo Pru = new AFNo();
            Pru.Prueba();
        }

        private void btnCrearAFN_Click(object sender, EventArgs e)
        {
            try
            {
                char inicio = txtInicio.Text[0];
                char fin = txtFin.Text[0];

                AFNo afn= AFNo.CrearAFNBasico(inicio, fin);
                afn.IdAFN = ++cont;
                afn.GuardarAFN("afn.txt");

                afns.Add(afn);
                listAFN.Items.Add($"AFN {afns.Count - 1}: [{inicio}-{fin}]");

                txtInicio.Clear();
                txtFin.Clear();
                txtToken.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnUnion_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count != 2)
            {
                MessageBox.Show("Selecciona 2 AFNs para la unión");
                return;
            }

            int idx1 = listAFN.SelectedIndices[0];
            int idx2 = listAFN.SelectedIndices[1];

            AFNo resultado = afns[idx1];// Thompson.Union(afns[idx1], afns[idx2]);
            resultado = resultado.UnirAFN(afns[idx2]);
            resultado.IdAFN = ++cont;
            afns.Add(resultado);
            listAFN.Items.Add($"AFN {afns.Count - 1}: Unión [{idx1},{idx2}]");
            MessageBox.Show("Unión creada");
        }

        private void btnConcatenacion_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count != 2)
            {
                MessageBox.Show("Selecciona 2 AFNs para la concatenación");
                return;
            }

            int idx1 = listAFN.SelectedIndices[0];
            int idx2 = listAFN.SelectedIndices[1];

            AFNo resultado = afns[idx1];
            resultado.Concatenar(afns[idx2]);
            resultado.IdAFN = ++cont;
            //Thompson.Concatenacion(afns[idx1], afns[idx2]);
            afns.Add(resultado);
            listAFN.Items.Add($"AFN {afns.Count - 1}: Concatenación [{idx1},{idx2}]");
            MessageBox.Show("Concatenación creada");
        }

        private void btnCerraduraPositiva_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Selecciona 1 AFN para la cerradura +");
                return;
            }

            int idx = listAFN.SelectedIndices[0];
            AFNo resultado = afns[idx];
            resultado.CerraduraPositiva();
            resultado.IdAFN = ++cont;
            afns.Add(resultado);
            listAFN.Items.Add($"AFN {afns.Count - 1}: Cerradura+ [{idx}]");
            MessageBox.Show("Cerradura + aplicada");
        }

        private void btnCerraduraKleene_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Selecciona 1 AFN para la cerradura *");
                return;
            }

            int idx = listAFN.SelectedIndices[0];
            AFNo resultado = afns[idx];
            resultado.CerraduraKleene();
            resultado.IdAFN = ++cont;
            afns.Add(resultado);
            listAFN.Items.Add($"AFN {afns.Count - 1}: Cerradura* [{idx}]");
            MessageBox.Show("Cerradura * aplicada");
        }

        private void btnOpcional_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Selecciona 1 AFN para opcional");
                return;
            }

            int idx = listAFN.SelectedIndices[0];
            AFNo resultado = afns[idx];
            resultado.Opcional();
            resultado.IdAFN = ++cont;
            afns.Add(resultado);
            listAFN.Items.Add($"AFN {afns.Count - 1}: Opcional [{idx}]");
            MessageBox.Show("Opcional aplicada");
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count != 1)
            {
                MessageBox.Show("Selecciona 1 AFN para Guardar en una quintupla");
                return;
            }

            int idx = listAFN.SelectedIndices[0];
            AFNo resultado = afns[idx];
            resultado.GuardarAFN("afn.txt");
            MessageBox.Show("Guardado");
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            if (listAFN.SelectedIndices.Count == 0)
            {
                MessageBox.Show("Selecciona al menos un AFN");
                return;
            }

            List<AFNo> seleccionados = new List<AFNo>();

            foreach (int idx in listAFN.SelectedIndices)
            {
                seleccionados.Add(afns[idx]);
            }

            FormUnirAFN f = new FormUnirAFN(seleccionados);
            f.AFNGenerado += (afnNuevo) =>
            {
                afns.Add(afnNuevo);
                listAFN.Items.Add($"AFN {afns.Count - 1}: Unión con tokens");
            };

            f.Show();
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            string regex = txtCadena.Text;

            try
            {
                var tokens = Tokenizar(regex);
                tokens = InsertarConcatenacion(tokens);
                var postfija = InfijaAPostfija(tokens);
                string resultado = EvaluarPostfija(postfija);

                var afn = ConstruirAFNDesdePostfija(postfija);
                afn.IdAFN = ++cont;


                // 🔥 guardar en lista
                afns.Add(afn);
                listAFN.Items.Add($"AFN {afns.Count - 1}: E.R");
                txtCadena.Clear();

                MessageBox.Show("AFN agregado a la lista.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnAnalizarTokens_Click(object sender, EventArgs e)
        {

        }
    }
}

/*
            try
            {
                if (listAFD.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona un AFD");
                    return;
                }

                afdActual = afds[listAFD.SelectedIndex];
                string cadena = txtCadena.Text;
                string resultado = EvaluadorAFD.Evaluar(afdActual, cadena);

                lblResultado.Text = resultado;
                if (resultado == "Cadena válida")
                    lblResultado.ForeColor = System.Drawing.Color.Green;
                else
                    lblResultado.ForeColor = System.Drawing.Color.Red;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            string Data = txtCadena.Text.Trim();
            if (string.IsNullOrEmpty(Data))
            {
                MessageBox.Show("Por favor ingresa una expresión regular.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var afn = ConstruirAFN(Data);

                // 3️⃣ Guardar AFN en un archivo
                afn.GuardarAFN("afn.txt");

                // 4️⃣ Mensaje de éxito
                MessageBox.Show("AFN generado correctamente en afn.txt", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Capturar errores si la regex no es válida
                MessageBox.Show("Error al generar AFN: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */
