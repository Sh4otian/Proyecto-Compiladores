using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsoleApp1.Clases;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class FormAFNaAFD : Form
    {
        List<AFNo> afns;
        AFD afdGenerado = null;
        char[] arrAlfabeto = null;
        public event Action<AFD> AFDGenerado;

        public FormAFNaAFD(List<AFNo> afns)
        {
            InitializeComponent();
            this.afns = afns;
            this.btnGuardar.Click += btnGuardar_Click;
            this.btnConvertir.Click += btnConvertir_Click;
            this.btnCancelar.Click += btnCancelar_Click;
            CargarLista();
        }

        private void CargarLista()
        {
            listAFNs.Items.Clear();
            for (int i = 0; i < afns.Count; i++)
                listAFNs.Items.Add($"AFN {i}");
        }

        private void btnConvertir_Click(object sender, EventArgs e)
        {
            try
            {
                if (listAFNs.SelectedIndex < 0)
                {
                    MessageBox.Show("Selecciona un AFN");
                    return;
                }

                int idx = listAFNs.SelectedIndex;
                afdGenerado = afns[idx].ConvAFNaAFD();
                arrAlfabeto = new char[afdGenerado.Alfabeto.Count];
                int i = 0;
                foreach (char c in afdGenerado.Alfabeto)
                    arrAlfabeto[i++] = c;

                MostrarTabla();
                AFDGenerado?.Invoke(afdGenerado);
                MessageBox.Show("AFD generado correctamente");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void MostrarTabla()
        {
            dgvAFD.Columns.Clear();
            dgvAFD.Rows.Clear();

            // Columnas: Estado | Aceptación | Token | un símbolo por columna
            dgvAFD.Columns.Add("colEstado", "Estado");
            dgvAFD.Columns.Add("colAcept", "Acepta");
            dgvAFD.Columns.Add("colToken", "Token");

            foreach (char c in arrAlfabeto)
                dgvAFD.Columns.Add($"col_{c}", c.ToString());

            // Filas: una por cada estado AFD
            foreach (AFD.ConjIj edo in afdGenerado.EdosAFD)
            {
                List<object> fila = new List<object>();
                fila.Add(edo.j);
                fila.Add(edo.EsAceptacion ? "Sí" : "No");
                fila.Add(edo.Token == -1 ? "-" : edo.Token.ToString());

                for (int r = 0; r < arrAlfabeto.Length; r++)
                {
                    int dest = edo.TransicionesAFD[r];
                    fila.Add(dest == -1 ? "-1" : dest.ToString());
                }

                dgvAFD.Rows.Add(fila.ToArray());
            }

            dgvAFD.AllowUserToAddRows = false;
            dgvAFD.ReadOnly = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (afdGenerado == null)
            {
                MessageBox.Show("Primero convierte un AFN a AFD");
                return;
            }

            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Archivos de texto|*.txt";
            dlg.FileName = "afd.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                afdGenerado.GuardarAFD(dlg.FileName);
                MessageBox.Show("AFD guardado en:\n" + dlg.FileName);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}