using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class FormUnir : Form
    {
        List<AFNo> afns;

        public FormUnir(List<AFNo> afns)
        {
            InitializeComponent();
            this.afns = afns;
            btnUnir.Click += btnUnir_Click;
            btnCancelar.Click += btnCancelar_Click;
            CargarLista();
        }

        private void CargarLista()
        {
            listAFNs.Items.Clear();
            for (int i = 0; i < afns.Count; i++)
                listAFNs.Items.Add($"AFN {i}");
        }

        private void btnUnir_Click(object sender, EventArgs e)
        {
            try
            {
                if (listAFNs.SelectedIndices.Count != 2)
                {
                    MessageBox.Show("Selecciona exactamente 2 AFNs (usa Ctrl+Click)");
                    return;
                }

                int idx1 = listAFNs.SelectedIndices[0];
                int idx2 = listAFNs.SelectedIndices[1];

                AFNo afn1 = afns[idx1];
                AFNo afn2 = afns[idx2];

                AFNo resultado = afn1.UnirAFN(afn2);

                // Quitar primero el índice mayor para no mover posiciones
                if (idx1 > idx2)
                {
                    afns.RemoveAt(idx1);
                    afns.RemoveAt(idx2);
                }
                else
                {
                    afns.RemoveAt(idx2);
                    afns.RemoveAt(idx1);
                }

                afns.Add(resultado);

                MessageBox.Show(
                    $"Se unieron correctamente AFN {idx1} y AFN {idx2}.\n" +
                    $"Total de AFNs actuales: {afns.Count}"
                );

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al unir AFNs: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}