using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsoleApp1.Clases;

namespace ConsoleApp1
{
    public partial class FormAnalizadorLexico : Form
    {
        AFD afd;

        public FormAnalizadorLexico(AFD afd)
        {
            InitializeComponent();
            this.afd = afd;
            this.btnAnalizar.Click += btnAnalizar_Click;
            this.btnCargarAFD.Click += btnCargarAFD_Click;
            this.btnCerrar.Click += btnCerrar_Click;
            this.btnLimpiar.Click += btnLimpiar_Click;
            ConfigurarTabla();
            ActualizarEstadoAFD();
        }

        private void ConfigurarTabla()
        {
            dgvTokens.Columns.Clear();
            dgvTokens.Columns.Add("colLexema", "Lexema");
            dgvTokens.Columns.Add("colToken", "Token");
            dgvTokens.Columns["colLexema"].Width = 200;
            dgvTokens.Columns["colToken"].Width = 100;
            dgvTokens.AllowUserToAddRows = false;
            dgvTokens.ReadOnly = true;
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

        // Analizar el texto ingresado y mostrar tokens en la tabla
        private void btnAnalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if (afd == null)
                {
                    MessageBox.Show("Primero carga o genera un AFD");
                    return;
                }

                string entrada = txtEntrada.Text;
                if (string.IsNullOrEmpty(entrada))
                {
                    MessageBox.Show("Ingresa un texto para analizar");
                    return;
                }

                List<(string lexema, int token)> resultado = afd.AnalizarLexico(entrada);

                dgvTokens.Rows.Clear();
                foreach (var (lexema, token) in resultado)
                {
                    string tokenStr = token == -1 ? "ERROR" : token.ToString();
                    dgvTokens.Rows.Add(lexema, tokenStr);
                }

                lblTotal.Text = $"Total tokens: {resultado.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtEntrada.Clear();
            dgvTokens.Rows.Clear();
            lblTotal.Text = "Total tokens: 0";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}