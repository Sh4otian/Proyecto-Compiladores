using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConsoleApp1.Clases;
using static ConsoleApp1.AFN;

namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        // Lista compartida entre todos los forms
        List<AFNo> afns = new List<AFNo>();
        AFD afdActual = null;

        public Form1()
        {
            InitializeComponent();
        }
        private void btnBasico_Click(object sender, EventArgs e)
        {
            FormAFNBasico f = new FormAFNBasico(afns);
            f.ShowDialog();

            MessageBox.Show("AFNs actuales: " + afns.Count);
        }

        private void btnUnir_Click(object sender, EventArgs e)
        {
            if(afns.Count < 2)
    {
                MessageBox.Show("Necesitas al menos 2 AFNs");
                return;
            }

            FormUnir f = new FormUnir(afns);
            f.ShowDialog();
        }

        private void btnConcatenar_Click(object sender, EventArgs e)
        {
            if (afns.Count < 2) { MessageBox.Show("Necesitas al menos 2 AFNs"); return; }
            FormConcatenar f = new FormConcatenar(afns);
            f.ShowDialog();
        }
        private void btnCerraduraPos_Click(object sender, EventArgs e)
        {
            FormOperacionesUnarias f = new FormOperacionesUnarias(afns, "+");
            f.ShowDialog();
        }

        private void btnCerraduraKleene_Click(object sender, EventArgs e)
        {
            FormOperacionesUnarias f = new FormOperacionesUnarias(afns, "*");
            f.ShowDialog();
        }

        private void btnOpcional_Click(object sender, EventArgs e)
        {
            FormOperacionesUnarias f = new FormOperacionesUnarias(afns, "?");
            f.ShowDialog();
        }
        private void btnExpresionRegular_Click(object sender, EventArgs e)
        {
            FormExpresionRegular f = new FormExpresionRegular(afns);
            f.ShowDialog();
        }

        private void btnUnionLexico_Click(object sender, EventArgs e)
        {
            if (afns.Count == 0) { MessageBox.Show("No hay AFNs creados"); return; }
            FormUnionLexico f = new FormUnionLexico(afns);
            f.ShowDialog();
        }

        private void btnAFNaAFD_Click(object sender, EventArgs e)
        {
            if (afns.Count == 0) { MessageBox.Show("No hay AFNs creados"); return; }
            FormAFNaAFD f = new FormAFNaAFD(afns);
            f.AFDGenerado += (afd) => afdActual = afd;
            f.ShowDialog();
        }

        private void btnAnalizarCadena_Click(object sender, EventArgs e)
        {
            if (afdActual == null) { MessageBox.Show("Primero carga o genera un AFD"); return; }
            FormAnalizarCadena f = new FormAnalizarCadena(afdActual);
            f.ShowDialog();
        }

        private void btnAnalizadorLexico_Click(object sender, EventArgs e)
        {
            if (afdActual == null) { MessageBox.Show("Primero carga o genera un AFD"); return; }
            FormAnalizadorLexico f = new FormAnalizadorLexico(afdActual);
            f.ShowDialog();
        }
    }
}