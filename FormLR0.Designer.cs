namespace ConsoleApp1
{
    partial class FormLR0
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnCargarArchivo;
        private System.Windows.Forms.TextBox txtArchivo;
        private System.Windows.Forms.TextBox txtGrammar;
        private System.Windows.Forms.Button btnProcesar;
        private System.Windows.Forms.TabControl tabControlResults;
        private System.Windows.Forms.TabPage tabPageFirstFollow;
        private System.Windows.Forms.TabPage tabPageLL1;
        private System.Windows.Forms.TextBox txtAction;
        private System.Windows.Forms.TextBox txtGoto;
        private System.Windows.Forms.DataGridView dataGridViewLR0;
        private System.Windows.Forms.TextBox txtTableNotes;
        private System.Windows.Forms.Label labelArchivo;
        private System.Windows.Forms.Label labelGrammar;
        private System.Windows.Forms.Label labelFirst;
        private System.Windows.Forms.Label labelFollow;
        private System.Windows.Forms.Label labelNotas;
        private System.Windows.Forms.Label lblStatus;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnCargarArchivo = new System.Windows.Forms.Button();
            this.txtArchivo = new System.Windows.Forms.TextBox();
            this.txtGrammar = new System.Windows.Forms.TextBox();
            this.btnProcesar = new System.Windows.Forms.Button();
            this.tabControlResults = new System.Windows.Forms.TabControl();
            this.tabPageFirstFollow = new System.Windows.Forms.TabPage();
            this.labelFollow = new System.Windows.Forms.Label();
            this.labelFirst = new System.Windows.Forms.Label();
            this.txtGoto = new System.Windows.Forms.TextBox();
            this.txtAction = new System.Windows.Forms.TextBox();
            this.tabPageLL1 = new System.Windows.Forms.TabPage();
            this.labelNotas = new System.Windows.Forms.Label();
            this.txtTableNotes = new System.Windows.Forms.TextBox();
            this.dataGridViewLR0 = new System.Windows.Forms.DataGridView();
            this.labelArchivo = new System.Windows.Forms.Label();
            this.labelGrammar = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tabControlResults.SuspendLayout();
            this.tabPageFirstFollow.SuspendLayout();
            this.tabPageLL1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLR0)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCargarArchivo
            // 
            this.btnCargarArchivo.Location = new System.Drawing.Point(12, 12);
            this.btnCargarArchivo.Name = "btnCargarArchivo";
            this.btnCargarArchivo.Size = new System.Drawing.Size(138, 30);
            this.btnCargarArchivo.TabIndex = 0;
            this.btnCargarArchivo.Text = "Cargar gramática";
            this.btnCargarArchivo.UseVisualStyleBackColor = true;
            this.btnCargarArchivo.Click += new System.EventHandler(this.btnCargarArchivo_Click);
            // 
            // txtArchivo
            // 
            this.txtArchivo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArchivo.Location = new System.Drawing.Point(156, 17);
            this.txtArchivo.Name = "txtArchivo";
            this.txtArchivo.ReadOnly = true;
            this.txtArchivo.Size = new System.Drawing.Size(622, 20);
            this.txtArchivo.TabIndex = 1;
            // 
            // txtGrammar
            // 
            this.txtGrammar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrammar.Location = new System.Drawing.Point(12, 70);
            this.txtGrammar.Multiline = true;
            this.txtGrammar.Name = "txtGrammar";
            this.txtGrammar.ReadOnly = true;
            this.txtGrammar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGrammar.Size = new System.Drawing.Size(766, 170);
            this.txtGrammar.TabIndex = 3;
            // 
            // btnProcesar
            // 
            this.btnProcesar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcesar.Location = new System.Drawing.Point(640, 246);
            this.btnProcesar.Name = "btnProcesar";
            this.btnProcesar.Size = new System.Drawing.Size(138, 30);
            this.btnProcesar.TabIndex = 4;
            this.btnProcesar.Text = "Procesar gramática";
            this.btnProcesar.UseVisualStyleBackColor = true;
            this.btnProcesar.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // tabControlResults
            // 
            this.tabControlResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlResults.Controls.Add(this.tabPageFirstFollow);
            this.tabControlResults.Controls.Add(this.tabPageLL1);
            this.tabControlResults.Location = new System.Drawing.Point(12, 288);
            this.tabControlResults.Name = "tabControlResults";
            this.tabControlResults.SelectedIndex = 0;
            this.tabControlResults.Size = new System.Drawing.Size(766, 300);
            this.tabControlResults.TabIndex = 5;
            // 
            // tabPageFirstFollow
            // 
            this.tabPageFirstFollow.Controls.Add(this.labelFollow);
            this.tabPageFirstFollow.Controls.Add(this.labelFirst);
            this.tabPageFirstFollow.Controls.Add(this.txtGoto);
            this.tabPageFirstFollow.Controls.Add(this.txtAction);
            this.tabPageFirstFollow.Location = new System.Drawing.Point(4, 22);
            this.tabPageFirstFollow.Name = "tabPageFirstFollow";
            this.tabPageFirstFollow.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFirstFollow.Size = new System.Drawing.Size(758, 274);
            this.tabPageFirstFollow.TabIndex = 0;
            this.tabPageFirstFollow.Text = "Clousure-Goto";
            this.tabPageFirstFollow.UseVisualStyleBackColor = true;
            // 
            // labelFollow
            // 
            this.labelFollow.AutoSize = true;
            this.labelFollow.Location = new System.Drawing.Point(382, 12);
            this.labelFollow.Name = "labelFollow";
            this.labelFollow.Size = new System.Drawing.Size(88, 13);
            this.labelFollow.TabIndex = 3;
            this.labelFollow.Text = "Conjuntos GOTO";
            // 
            // labelFirst
            // 
            this.labelFirst.AutoSize = true;
            this.labelFirst.Location = new System.Drawing.Point(9, 12);
            this.labelFirst.Name = "labelFirst";
            this.labelFirst.Size = new System.Drawing.Size(149, 13);
            this.labelFirst.TabIndex = 2;
            this.labelFirst.Text = "Conjuntos Action // Conflictos";
            // 
            // txtGoto
            // 
            this.txtGoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGoto.Location = new System.Drawing.Point(385, 28);
            this.txtGoto.Multiline = true;
            this.txtGoto.Name = "txtGoto";
            this.txtGoto.ReadOnly = true;
            this.txtGoto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGoto.Size = new System.Drawing.Size(367, 238);
            this.txtGoto.TabIndex = 1;
            // 
            // txtAction
            // 
            this.txtAction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAction.Location = new System.Drawing.Point(12, 28);
            this.txtAction.Multiline = true;
            this.txtAction.Name = "txtAction";
            this.txtAction.ReadOnly = true;
            this.txtAction.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtAction.Size = new System.Drawing.Size(367, 238);
            this.txtAction.TabIndex = 0;
            // 
            // tabPageLL1
            // 
            this.tabPageLL1.Controls.Add(this.labelNotas);
            this.tabPageLL1.Controls.Add(this.txtTableNotes);
            this.tabPageLL1.Controls.Add(this.dataGridViewLR0);
            this.tabPageLL1.Location = new System.Drawing.Point(4, 22);
            this.tabPageLL1.Name = "tabPageLL1";
            this.tabPageLL1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLL1.Size = new System.Drawing.Size(758, 274);
            this.tabPageLL1.TabIndex = 1;
            this.tabPageLL1.Text = "Tabla LR(0)";
            this.tabPageLL1.UseVisualStyleBackColor = true;
            // 
            // labelNotas
            // 
            this.labelNotas.AutoSize = true;
            this.labelNotas.Location = new System.Drawing.Point(9, 173);
            this.labelNotas.Name = "labelNotas";
            this.labelNotas.Size = new System.Drawing.Size(118, 13);
            this.labelNotas.TabIndex = 2;
            this.labelNotas.Text = "Notas / conflictos LL(1)";
            // 
            // txtTableNotes
            // 
            this.txtTableNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTableNotes.Location = new System.Drawing.Point(12, 189);
            this.txtTableNotes.Multiline = true;
            this.txtTableNotes.Name = "txtTableNotes";
            this.txtTableNotes.ReadOnly = true;
            this.txtTableNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTableNotes.Size = new System.Drawing.Size(734, 77);
            this.txtTableNotes.TabIndex = 1;
            // 
            // dataGridViewLR0
            // 
            this.dataGridViewLR0.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewLR0.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLR0.Location = new System.Drawing.Point(12, 12);
            this.dataGridViewLR0.Name = "dataGridViewLR0";
            this.dataGridViewLR0.RowHeadersWidth = 80;
            this.dataGridViewLR0.Size = new System.Drawing.Size(734, 155);
            this.dataGridViewLR0.TabIndex = 0;
            // 
            // labelArchivo
            // 
            this.labelArchivo.AutoSize = true;
            this.labelArchivo.Location = new System.Drawing.Point(12, 51);
            this.labelArchivo.Name = "labelArchivo";
            this.labelArchivo.Size = new System.Drawing.Size(130, 13);
            this.labelArchivo.TabIndex = 6;
            this.labelArchivo.Text = "Contenido de la gramática";
            // 
            // labelGrammar
            // 
            this.labelGrammar.AutoSize = true;
            this.labelGrammar.Location = new System.Drawing.Point(153, 1);
            this.labelGrammar.Name = "labelGrammar";
            this.labelGrammar.Size = new System.Drawing.Size(60, 13);
            this.labelGrammar.TabIndex = 7;
            this.labelGrammar.Text = "Archivo .txt";
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStatus.Location = new System.Drawing.Point(12, 259);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(622, 23);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Selecciona un archivo para cargar la gramática.";
            // 
            // FormLR0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 600);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.labelGrammar);
            this.Controls.Add(this.labelArchivo);
            this.Controls.Add(this.tabControlResults);
            this.Controls.Add(this.btnProcesar);
            this.Controls.Add(this.txtGrammar);
            this.Controls.Add(this.txtArchivo);
            this.Controls.Add(this.btnCargarArchivo);
            this.Name = "FormLR0";
            this.Text = "Action-Goto y Tabla LR(0)";
            this.tabControlResults.ResumeLayout(false);
            this.tabPageFirstFollow.ResumeLayout(false);
            this.tabPageFirstFollow.PerformLayout();
            this.tabPageLL1.ResumeLayout(false);
            this.tabPageLL1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLR0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
