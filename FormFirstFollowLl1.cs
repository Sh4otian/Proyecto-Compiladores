using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ConsoleApp1.Clases;

namespace ConsoleApp1
{
    public partial class FormFirstFollowLl1 : Form
    {
        private Grammar grammar;
        private Dictionary<string, HashSet<string>> firstSets;
        private Dictionary<string, HashSet<string>> followSets;
        private LL1TableResult ll1Result;

        public FormFirstFollowLl1(int startTabIndex = 0)
        {
            InitializeComponent();
            tabControlResults.SelectedIndex = startTabIndex;
        }

        private void btnCargarArchivo_Click(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog())
            {
                dialog.Filter = "Texto|*.txt|Todos los archivos|*.*";
                dialog.Title = "Seleccionar archivo de gramática";
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                txtArchivo.Text = dialog.FileName;
                txtGrammar.Text = File.ReadAllText(dialog.FileName);
                ResetResults();
            }
        }

        private void btnProcesar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtArchivo.Text))
                {
                    MessageBox.Show("Primero selecciona un archivo de gramática.", "Archivo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var parser = new ConversionGram();

                grammar = parser.Parse(txtGrammar.Text);
                var ff = new FirstFollow();
                firstSets = ff.ComputeFirst(grammar);
                followSets = ff.ComputeFollow(grammar, firstSets);
                var LL1 = new Tablasll1();
                ll1Result = LL1.BuildLL1Table(grammar, firstSets, followSets, ff);

                DisplayFirstFollow();
                DisplayLL1Table();
                lblStatus.Text = $"Gramática cargada. Símbolo inicial: {grammar.StartSymbol}.";
                tabControlResults.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la gramática:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetResults()
        {
            txtFirst.Clear();
            txtFollow.Clear();
            txtTableNotes.Clear();
            dataGridViewLL1.Columns.Clear();
            dataGridViewLL1.Rows.Clear();
            lblStatus.Text = "Archivo cargado. Haz clic en Procesar para calcular First, Follow y la tabla LL(1).";
        }

        private void DisplayFirstFollow()
        {
            txtFirst.Clear();
            txtFollow.Clear();

            foreach (var nonTerminal in grammar.NonTerminals)
            {
                var firstSet = firstSets.ContainsKey(nonTerminal) ? firstSets[nonTerminal] : new HashSet<string>();
                var followSet = followSets.ContainsKey(nonTerminal) ? followSets[nonTerminal] : new HashSet<string>();

                txtFirst.AppendText($"FIRST({nonTerminal}) = {{ {string.Join(", ", firstSet.OrderBy(x => x))} }}{Environment.NewLine}");
                txtFollow.AppendText($"FOLLOW({nonTerminal}) = {{ {string.Join(", ", followSet.OrderBy(x => x))} }}{Environment.NewLine}");
            }
        }

        private void DisplayLL1Table()
        {
            dataGridViewLL1.Columns.Clear();
            dataGridViewLL1.Rows.Clear();

            foreach (var terminal in ll1Result.Terminals)
            {
                var column = new DataGridViewTextBoxColumn
                {
                    HeaderText = terminal,
                    Name = terminal,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    SortMode = DataGridViewColumnSortMode.NotSortable
                };
                dataGridViewLL1.Columns.Add(column);
            }

            foreach (var nonTerminal in ll1Result.NonTerminals)
            {
                var rowIndex = dataGridViewLL1.Rows.Add();
                var row = dataGridViewLL1.Rows[rowIndex];
                row.HeaderCell.Value = nonTerminal;
                for (int colIndex = 0; colIndex < ll1Result.Terminals.Count; colIndex++)
                {
                    var terminal = ll1Result.Terminals[colIndex];
                    if (ll1Result.Table.TryGetValue(nonTerminal, out var rowTable) && rowTable.TryGetValue(terminal, out var production))
                    {
                        row.Cells[colIndex].Value = production;
                    }
                }
            }

            dataGridViewLL1.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
            txtTableNotes.Text = ll1Result.Conflicts.Any()
                ? string.Join(Environment.NewLine, ll1Result.Conflicts)
                : "La tabla LL(1) se generó sin conflictos detectados.";
        }

    }
}
