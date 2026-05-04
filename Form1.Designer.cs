namespace ConsoleApp1
{

    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtInicio;
        private System.Windows.Forms.TextBox txtFin;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnCrearAFN;
        private System.Windows.Forms.ListBox listAFN;
        private System.Windows.Forms.Button btnUnion;
        private System.Windows.Forms.Button btnConcatenacion;
        private System.Windows.Forms.Button btnCerraduraPositiva;
        private System.Windows.Forms.Button btnCerraduraKleene;
        private System.Windows.Forms.Button btnOpcional;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.ListBox listAFD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCadena;
        private System.Windows.Forms.Button btnERAFN;
        private System.Windows.Forms.Button btnAnalizarTokens;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Label lblTokens;

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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtInicio = new System.Windows.Forms.TextBox();
            this.txtFin = new System.Windows.Forms.TextBox();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnCrearAFN = new System.Windows.Forms.Button();
            this.listAFN = new System.Windows.Forms.ListBox();
            this.btnUnion = new System.Windows.Forms.Button();
            this.btnConcatenacion = new System.Windows.Forms.Button();
            this.btnCerraduraPositiva = new System.Windows.Forms.Button();
            this.btnCerraduraKleene = new System.Windows.Forms.Button();
            this.btnOpcional = new System.Windows.Forms.Button();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.listAFD = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCadena = new System.Windows.Forms.TextBox();
            this.btnERAFN = new System.Windows.Forms.Button();
            this.btnAnalizarTokens = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.lblTokens = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inicio:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(95, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fin:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Token:";
            // 
            // txtInicio
            // 
            this.txtInicio.Location = new System.Drawing.Point(50, 9);
            this.txtInicio.Name = "txtInicio";
            this.txtInicio.Size = new System.Drawing.Size(40, 20);
            this.txtInicio.TabIndex = 1;
            // 
            // txtFin
            // 
            this.txtFin.Location = new System.Drawing.Point(125, 9);
            this.txtFin.Name = "txtFin";
            this.txtFin.Size = new System.Drawing.Size(40, 20);
            this.txtFin.TabIndex = 3;
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(220, 9);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(40, 20);
            this.txtToken.TabIndex = 5;
            // 
            // btnCrearAFN
            // 
            this.btnCrearAFN.Location = new System.Drawing.Point(270, 9);
            this.btnCrearAFN.Name = "btnCrearAFN";
            this.btnCrearAFN.Size = new System.Drawing.Size(75, 23);
            this.btnCrearAFN.TabIndex = 6;
            this.btnCrearAFN.Text = "Crear AFN";
            this.btnCrearAFN.Click += new System.EventHandler(this.btnCrearAFN_Click);
            // 
            // listAFN
            // 
            this.listAFN.Location = new System.Drawing.Point(12, 40);
            this.listAFN.Name = "listAFN";
            this.listAFN.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listAFN.Size = new System.Drawing.Size(400, 82);
            this.listAFN.TabIndex = 7;
            // 
            // btnUnion
            // 
            this.btnUnion.Location = new System.Drawing.Point(12, 145);
            this.btnUnion.Name = "btnUnion";
            this.btnUnion.Size = new System.Drawing.Size(70, 25);
            this.btnUnion.TabIndex = 8;
            this.btnUnion.Text = "Unión";
            this.btnUnion.Click += new System.EventHandler(this.btnUnion_Click);
            // 
            // btnConcatenacion
            // 
            this.btnConcatenacion.Location = new System.Drawing.Point(85, 145);
            this.btnConcatenacion.Name = "btnConcatenacion";
            this.btnConcatenacion.Size = new System.Drawing.Size(70, 25);
            this.btnConcatenacion.TabIndex = 9;
            this.btnConcatenacion.Text = "Concat";
            this.btnConcatenacion.Click += new System.EventHandler(this.btnConcatenacion_Click);
            // 
            // btnCerraduraPositiva
            // 
            this.btnCerraduraPositiva.Location = new System.Drawing.Point(158, 145);
            this.btnCerraduraPositiva.Name = "btnCerraduraPositiva";
            this.btnCerraduraPositiva.Size = new System.Drawing.Size(70, 25);
            this.btnCerraduraPositiva.TabIndex = 10;
            this.btnCerraduraPositiva.Text = "Cerr+";
            this.btnCerraduraPositiva.Click += new System.EventHandler(this.btnCerraduraPositiva_Click);
            // 
            // btnCerraduraKleene
            // 
            this.btnCerraduraKleene.Location = new System.Drawing.Point(231, 145);
            this.btnCerraduraKleene.Name = "btnCerraduraKleene";
            this.btnCerraduraKleene.Size = new System.Drawing.Size(70, 25);
            this.btnCerraduraKleene.TabIndex = 11;
            this.btnCerraduraKleene.Text = "Cerr*";
            this.btnCerraduraKleene.Click += new System.EventHandler(this.btnCerraduraKleene_Click);
            // 
            // btnOpcional
            // 
            this.btnOpcional.Location = new System.Drawing.Point(304, 145);
            this.btnOpcional.Name = "btnOpcional";
            this.btnOpcional.Size = new System.Drawing.Size(70, 25);
            this.btnOpcional.TabIndex = 12;
            this.btnOpcional.Text = "Opcional";
            this.btnOpcional.Click += new System.EventHandler(this.btnOpcional_Click);
            // 
            // btnConvertir
            // 
            this.btnConvertir.Location = new System.Drawing.Point(12, 175);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(75, 23);
            this.btnConvertir.TabIndex = 13;
            this.btnConvertir.Text = "Unir AFNs";
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // listAFD
            // 
            this.listAFD.Location = new System.Drawing.Point(12, 210);
            this.listAFD.Name = "listAFD";
            this.listAFD.Size = new System.Drawing.Size(400, 43);
            this.listAFD.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 283);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "E.R";
            // 
            // txtCadena
            // 
            this.txtCadena.Location = new System.Drawing.Point(60, 280);
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.Size = new System.Drawing.Size(300, 20);
            this.txtCadena.TabIndex = 16;
            // 
            // btnERAFN
            // 
            this.btnERAFN.Location = new System.Drawing.Point(370, 280);
            this.btnERAFN.Name = "btnERAFN";
            this.btnERAFN.Size = new System.Drawing.Size(75, 23);
            this.btnERAFN.TabIndex = 17;
            this.btnERAFN.Text = "Transformar";
            this.btnERAFN.Click += new System.EventHandler(this.btnEvaluar_Click);
            // 
            // btnAnalizarTokens
            // 
            this.btnAnalizarTokens.Location = new System.Drawing.Point(12, 310);
            this.btnAnalizarTokens.Name = "btnAnalizarTokens";
            this.btnAnalizarTokens.Size = new System.Drawing.Size(75, 23);
            this.btnAnalizarTokens.TabIndex = 18;
            this.btnAnalizarTokens.Text = "Analizar Tokens";
            this.btnAnalizarTokens.Click += new System.EventHandler(this.btnAnalizarTokens_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.Location = new System.Drawing.Point(12, 340);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(400, 20);
            this.lblResultado.TabIndex = 19;
            this.lblResultado.Text = "Resultado:";
            // 
            // lblTokens
            // 
            this.lblTokens.Location = new System.Drawing.Point(12, 365);
            this.lblTokens.Name = "lblTokens";
            this.lblTokens.Size = new System.Drawing.Size(400, 40);
            this.lblTokens.TabIndex = 20;
            this.lblTokens.Text = "Tokens:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(275, 179);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 21;
            this.button1.Text = "Guardar AFN";
            this.button1.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(450, 420);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.btnCrearAFN);
            this.Controls.Add(this.listAFN);
            this.Controls.Add(this.btnUnion);
            this.Controls.Add(this.btnConcatenacion);
            this.Controls.Add(this.btnCerraduraPositiva);
            this.Controls.Add(this.btnCerraduraKleene);
            this.Controls.Add(this.btnOpcional);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.listAFD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtCadena);
            this.Controls.Add(this.btnERAFN);
            this.Controls.Add(this.btnAnalizarTokens);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.lblTokens);
            this.Name = "Form1";
            this.Text = "Evaluador de Autómatas Finitos";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button1;
    }
}
