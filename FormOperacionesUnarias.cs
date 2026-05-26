using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class FormOperacionesUnarias : Form
    {
        List<AFNo> afns;
        string operacion; // "+" , "*" , "?"

        public FormOperacionesUnarias(List<AFNo> afns, string operacion)
        {
            InitializeComponent();
            this.afns = afns;
            this.operacion = operacion;
            this.btnAplicar.Click += btnAplicar_Click;
            this.btnCancelar.Click += btnCancelar_Click;

            // Cambiar título según operación
            switch (operacion)
            {
                case "+":
                    this.Text = "Cerradura (+)";
                    lblOperacion.Text = "Aplicar Cerradura Positiva (+)";
                    break;
                case "*":
                    this.Text = "Cerradura (*)";
                    lblOperacion.Text = "Aplicar Cerradura Kleene (*)";
                    break;
                case "?":
                    this.Text = "Opcional (?)";
                    lblOperacion.Text = "Aplicar Opcional (?)";
                    break;
            }

            CargarLista();
        }

        private void CargarLista()
        {
            listAFNs.Items.Clear();
            for (int i = 0; i < afns.Count; i++)
                listAFNs.Items.Add($"AFN {i}");
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listAFNs.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona un AFN");
                    return;
                }

                int idx = listAFNs.SelectedIndex;
                AFNo resultado = afns[idx];

                switch (operacion)
                {
                    case "+":
                        resultado.CerraduraPositiva();
                        break;

                    case "*":
                        resultado.CerraduraKleene();
                        break;

                    case "?":
                        resultado.Opcional();
                        break;

                    default:
                        MessageBox.Show("Operación no válida");
                        return;
                }

                afns.RemoveAt(idx);
                afns.Add(resultado);

                MessageBox.Show($"Operación '{operacion}' aplicada. Total AFNs: {afns.Count}");
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