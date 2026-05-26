using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ConsoleApp1.AFN;
using static ConsoleApp1.Clases.ER;

namespace ConsoleApp1
{
    public partial class FormExpresionRegular : Form
    {
        List<AFNo> afns;

        public FormExpresionRegular(List<AFNo> afns)
        {
            InitializeComponent();
            this.afns = afns;
            this.btnCancelar.Click += btnCancelar_Click;
            this.btnEvaluar.Click += btnEvaluar_Click;
        }

        private void btnEvaluar_Click(object sender, EventArgs e)
        {
            try
            {
                string regex = txtER.Text.Trim();
                if (string.IsNullOrEmpty(regex))
                {
                    MessageBox.Show("Ingresa una expresión regular");
                    return;
                }

                var tokens = Tokenizar(regex);
                tokens = InsertarConcatenacion(tokens);
                var postfija = InfijaAPostfija(tokens);
                AFNo afn = ConstruirAFNDesdePostfija(postfija);

                afns.Add(afn);
                MessageBox.Show($"AFN generado desde ER. Total AFNs: {afns.Count}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}