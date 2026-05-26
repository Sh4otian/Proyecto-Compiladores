using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class FormAFNBasico : Form
    {
        List<AFNo> afns;

        public FormAFNBasico(List<AFNo> afns)
        {
            InitializeComponent();
            this.afns = afns;
            this.btnCancelar.Click += (s, e) => this.Close();
            this.btnCrear.Click += btnCrear_Click;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtInferior.Text) || string.IsNullOrEmpty(txtSuperior.Text))
                {
                    MessageBox.Show("Ingresa ambos caracteres");
                    return;
                }

                char inicio = txtInferior.Text[0];
                char fin = txtSuperior.Text[0];

                if (inicio > fin)
                {
                    MessageBox.Show("El carácter inferior debe ser menor o igual al superior");
                    return;
                }

                AFNo afn = AFNo.CrearAFNBasico(inicio, fin);
                afns.Add(afn);

                MessageBox.Show($"AFN básico [{inicio}-{fin}] creado. Total AFNs: {afns.Count}");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}