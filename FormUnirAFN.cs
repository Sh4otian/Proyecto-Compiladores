using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class FormUnirAFN : Form
    {
        private List<AFNo> afnsRecibidos;
        public event Action<AFNo> AFNGenerado;

        public FormUnirAFN(List<AFNo> afns)
        {
            InitializeComponent();
            afnsRecibidos = afns;
        }

        private void FormUnirAFN_Load(object sender, EventArgs e)
        {
            // Limpiar por si acaso
            DatGV1.Columns.Clear();
            DatGV1.Rows.Clear();

            // Crear columnas
            DatGV1.Columns.Add("IdAFN", "IdAFN");
            DatGV1.Columns.Add("Token", "Token");

            // Configuración
            DatGV1.Columns["IdAFN"].ReadOnly = true; // no editable
            DatGV1.Columns["Token"].ReadOnly = false; // editable

            DatGV1.AllowUserToAddRows = false;

            // Llenar datos
            foreach (var afn in afnsRecibidos)
            {
                DatGV1.Rows.Add(afn.IdAFN, -1);
            }
        }

        // Validar que el token sea número
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1) // columna Token
            {
                if (!int.TryParse(e.FormattedValue.ToString(), out _))
                {
                    MessageBox.Show("El token debe ser numérico");
                    e.Cancel = true;
                }
            }
        }

        // Botón para guardar cambios y usar AFNs
        private void btnProcesar_Click(object sender, EventArgs e)
        {
            var lista = new List<(AFNo, int)>();

            for (int i = 0; i < DatGV1.Rows.Count; i++)
            {
                int nuevoToken = Convert.ToInt32(DatGV1.Rows[i].Cells[1].Value);
                lista.Add((afnsRecibidos[i], nuevoToken));
            }

            var nuevo = AFNo.UnirAFNs(lista);

            afnsRecibidos.Clear();
            afnsRecibidos.Add(nuevo);

            MessageBox.Show("AFNs unidos correctamente. Total AFNs: " + afnsRecibidos.Count);

            this.Close();
        }
    }
}