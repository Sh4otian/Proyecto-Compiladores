using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class FormUnionLexico : Form
    {
        List<AFNo> afns;
        // Lista de pares (afn, token) que el usuario va armando
        List<(AFNo afn, int token)> seleccionados = new List<(AFNo, int)>();

        public FormUnionLexico(List<AFNo> afns)
        {
            InitializeComponent();
            this.afns = afns;
            this.btnCancelar.Click += btnCancelar_Click;
            this.btnAgregar.Click += btnAgregar_Click;
            this.btnUnir.Click += btnUnir_Click;
            CargarLista();
        }

        private void CargarLista()
        {
            listAFNs.Items.Clear();
            for (int i = 0; i < afns.Count; i++)
                listAFNs.Items.Add($"AFN {i}");
        }

        // Agregar AFN seleccionado con su token a la lista de seleccionados
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (listAFNs.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona un AFN");
                    return;
                }
                if (string.IsNullOrEmpty(txtToken.Text) || !int.TryParse(txtToken.Text, out int token))
                {
                    MessageBox.Show("Ingresa un número de token válido");
                    return;
                }

                int idx = listAFNs.SelectedIndex;
                seleccionados.Add((afns[idx], token));
                listSeleccionados.Items.Add($"AFN {idx} → Token {token}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        // Unir todos los AFNs seleccionados en uno solo
        private void btnUnir_Click(object sender, EventArgs e)
        {
            try
            {
                if (seleccionados.Count < 2)
                {
                    MessageBox.Show("Agrega al menos 2 AFNs");
                    return;
                }

                AFNo afnUnido = AFNo.UnirAFNs(seleccionados);
                afns.Add(afnUnido);

                MessageBox.Show($"Unión para analizador léxico creada. Total AFNs: {afns.Count}");
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