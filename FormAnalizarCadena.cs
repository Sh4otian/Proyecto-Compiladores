using System;
using System.Windows.Forms;
using ConsoleApp1.Clases;

namespace ConsoleApp1
{
    public partial class FormAnalizarCadena : Form
    {
        AFD afd;

        public FormAnalizarCadena(AFD afd)
        {
            InitializeComponent();
            this.afd = afd;
            this.btnAnalizar.Click += btnAnalizar_Click;
            this.btnCerrar.Click += btnCerrar_Click;
            this.btnCargarAFD.Click += btnCargarAFD_Click;
            ActualizarEstadoAFD();
        }

        private void ActualizarEstadoAFD()
        {
            if (afd != null)
                lblEstadoAFD.Text = $"AFD cargado ({afd.EdosAFD.Count} estados)";
            else
                lblEstadoAFD.Text = "Sin AFD cargado";
        }

        // Cargar AFD desde archivo
        private void btnCargarAFD_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Archivos de texto|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    afd = AFD.CargarAFD(dlg.FileName);
                    ActualizarEstadoAFD();
                    MessageBox.Show("AFD cargado correctamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar AFD: " + ex.Message);
                }
            }
        }

        // Analizar la cadena ingresada
        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (afd == null)
                {
                    MessageBox.Show("Primero carga o genera un AFD");
                    return;
                }

                string cadena = txtCadena.Text;
                bool valida = afd.AnalizarCadena(cadena);

                if (valida)
                {
                    lblResultado.Text = "✔ Cadena VÁLIDA";
                    lblResultado.ForeColor = System.Drawing.Color.LimeGreen;
                }
                else
                {
                    lblResultado.Text = "✘ Cadena INVÁLIDA";
                    lblResultado.ForeColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}