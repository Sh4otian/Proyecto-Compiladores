using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ConsoleApp1.Clases;

namespace ConsoleApp1
{
    public partial class FormLR0 : Form
    {
        private Grammar grammar;
        private Dictionary<string, HashSet<string>> firstSets;
        private Dictionary<string, HashSet<string>> followSets;
        private LL1TableResult ll1Result;

        public FormLR0(int startTabIndex = 0)
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
                parser.Validar(grammar);
                var builder = new LR0Builder();
                var states = builder.BuildStates(grammar);
                foreach (var state in states)
                {
                    Console.WriteLine(
                        $"============ I{state.Id} ============");

                    foreach (var item in state.Items)
                    {
                        Console.WriteLine(item);
                    }

                    Console.WriteLine();

                    foreach (var t in state.Transitions)
                    {
                        Console.WriteLine(
                            $"{t.Key} -> I{t.Value}");
                    }

                    Console.WriteLine();
                }

                // =====================================
                // TABLA LR(0)
                // =====================================

                var table =
                    builder.BuildParsingTable(
                        grammar,
                        states);

                Console.WriteLine(
                    "\n===== ACTION =====");

                foreach (var action
                    in table.Action)
                {
                    Console.WriteLine(
                        $"ACTION[{action.Key.Item1}, {action.Key.Item2}] = {action.Value}");
                }

                Console.WriteLine(
                    "\n===== GOTO =====");

                foreach (var gt
                    in table.Goto)
                {
                    Console.WriteLine(
                        $"GOTO[{gt.Key.Item1}, {gt.Key.Item2}] = {gt.Value}");
                }

                // conflictos
                if (table.Conflicts.Count > 0)
                {
                    Console.WriteLine(
                        "\n===== CONFLICTOS =====");

                    foreach (var c
                        in table.Conflicts)
                    {
                        Console.WriteLine(c);
                    }
                }
                var Tabla = builder.BuildParsingTable(grammar, states);

                // tabla unificada
                DisplayLR0UnifiedTable(Tabla, grammar);

                // explicación textual
                DisplayLR0Explanation(Tabla, grammar);
                /*
                var ff = new FirstFollow();
                firstSets = ff.ComputeFirst(grammar);
                followSets = ff.ComputeFollow(grammar, firstSets);
                var LL1 = new Tablasll1();
                ll1Result = LL1.BuildLL1Table(grammar, firstSets, followSets, ff);

                DisplayFirstFollow();
                DisplayLL1Table();
                lblStatus.Text = $"Gramática cargada. Símbolo inicial: {grammar.StartSymbol}.";
                tabControlResults.SelectedIndex = 0;
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar la gramática:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetResults()
        {
            txtAction.Clear();
            txtGoto.Clear();
            txtTableNotes.Clear();
            dataGridViewLR0.Columns.Clear();
            dataGridViewLR0.Rows.Clear();
            lblStatus.Text = "Archivo cargado. Haz clic en Procesar para calcular Action, Goto y la tabla de LR(0).";
        }

        private void DisplayLR0UnifiedTable(LR0ParsingTable table, Grammar grammar)
        {
            dataGridViewLR0.Columns.Clear();
            dataGridViewLR0.Rows.Clear();

            var terminals = grammar.Terminals.ToList();
            var Aumen = grammar.Productions[0].Left;
            var nonTerminals = grammar.NonTerminals.Where(nt => nt != Aumen).ToList();

            var allSymbols = terminals.Concat(nonTerminals).ToList();

            foreach (var s in allSymbols)
            {
                dataGridViewLR0.Columns.Add(s, s);
            }

            int maxState =
                Math.Max(
                    table.Action.Keys.Any() ? table.Action.Keys.Max(k => k.Item1) : 0,
                    table.Goto.Keys.Any() ? table.Goto.Keys.Max(k => k.Item1) : 0);

            for (int i = 0; i <= maxState; i++)
            {
                int rowIndex = dataGridViewLR0.Rows.Add();
                var row = dataGridViewLR0.Rows[rowIndex];
                row.HeaderCell.Value = $"{i}";

                for (int j = 0; j < allSymbols.Count; j++)
                {
                    var symbol = allSymbols[j];

                    string value = "";

                    // ACTION (terminales)
                    if (grammar.Terminals.Contains(symbol))
                    {
                        if (table.Action.TryGetValue((i, symbol), out var act))
                            value = act;
                    }
                    else // GOTO (no terminales)
                    {
                        if (table.Goto.TryGetValue((i, symbol), out var go))
                            value = $"{go}";
                    }

                    row.Cells[j].Value = value;
                }
            }

            dataGridViewLR0.AutoResizeRowHeadersWidth(
                DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders);
        }
        private void DisplayLR0Explanation(LR0ParsingTable table, Grammar grammar)
        {
            txtAction.Clear();
            txtGoto.Clear();

            txtAction.AppendText("===== ACTION =====\r\n");

            foreach (var a in table.Action.OrderBy(x => x.Key.Item1))
            {
                txtAction.AppendText(
                    $"[I{a.Key.Item1}, {a.Key.Item2}] = {a.Value}\r\n");
            }

            txtGoto.AppendText("\n===== GOTO =====\r\n");

            foreach (var g in table.Goto.OrderBy(x => x.Key.Item1))
            {
                txtGoto.AppendText(
                    $"[I{g.Key.Item1}, {g.Key.Item2}] = I{g.Value}\r\n");
            }

            txtAction.AppendText("\n===== CONFLICTOS =====\r\n");

            if (table.Conflicts.Count == 0)
            {
                txtAction.AppendText("No conflicts.\r\n");
            }
            else
            {
                foreach (var c in table.Conflicts)
                {
                    txtAction.AppendText(c + "\r\n");
                }
            }
        }
    }
}
