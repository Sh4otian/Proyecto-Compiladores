namespace ConsoleApp1
{

    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnBasico = new System.Windows.Forms.Button();
            this.btnUnir = new System.Windows.Forms.Button();
            this.btnConcatenar = new System.Windows.Forms.Button();
            this.btnCerraduraPos = new System.Windows.Forms.Button();
            this.btnCerraduraKleene = new System.Windows.Forms.Button();
            this.btnOpcional = new System.Windows.Forms.Button();
            this.btnExpresionRegular = new System.Windows.Forms.Button();
            this.btnUnionLexico = new System.Windows.Forms.Button();
            this.btnAFNaAFD = new System.Windows.Forms.Button();
            this.btnAnalizarCadena = new System.Windows.Forms.Button();
            this.btnAnalizadorLexico = new System.Windows.Forms.Button();
            this.btnFirstFollow = new System.Windows.Forms.Button();
            this.btnTablaLL1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBasico
            // 
            this.btnBasico.Location = new System.Drawing.Point(12, 12);
            this.btnBasico.Name = "btnBasico";
            this.btnBasico.Size = new System.Drawing.Size(386, 35);
            this.btnBasico.TabIndex = 0;
            this.btnBasico.Text = "AFN Básico";
            this.btnBasico.UseVisualStyleBackColor = true;
            this.btnBasico.Click += new System.EventHandler(this.btnBasico_Click);
            // 
            // btnUnir
            // 
            this.btnUnir.Location = new System.Drawing.Point(12, 53);
            this.btnUnir.Name = "btnUnir";
            this.btnUnir.Size = new System.Drawing.Size(386, 35);
            this.btnUnir.TabIndex = 1;
            this.btnUnir.Text = "Unir AFN\'S";
            this.btnUnir.UseVisualStyleBackColor = true;
            this.btnUnir.Click += new System.EventHandler(this.btnUnir_Click);
            // 
            // btnConcatenar
            // 
            this.btnConcatenar.Location = new System.Drawing.Point(12, 94);
            this.btnConcatenar.Name = "btnConcatenar";
            this.btnConcatenar.Size = new System.Drawing.Size(386, 35);
            this.btnConcatenar.TabIndex = 2;
            this.btnConcatenar.Text = "Concatenar";
            this.btnConcatenar.UseVisualStyleBackColor = true;
            this.btnConcatenar.Click += new System.EventHandler(this.btnConcatenar_Click);
            // 
            // btnCerraduraPos
            // 
            this.btnCerraduraPos.Location = new System.Drawing.Point(12, 135);
            this.btnCerraduraPos.Name = "btnCerraduraPos";
            this.btnCerraduraPos.Size = new System.Drawing.Size(386, 35);
            this.btnCerraduraPos.TabIndex = 3;
            this.btnCerraduraPos.Text = "Cerradura Positiva";
            this.btnCerraduraPos.UseVisualStyleBackColor = true;
            this.btnCerraduraPos.Click += new System.EventHandler(this.btnCerraduraPos_Click);
            // 
            // btnCerraduraKleene
            // 
            this.btnCerraduraKleene.Location = new System.Drawing.Point(12, 176);
            this.btnCerraduraKleene.Name = "btnCerraduraKleene";
            this.btnCerraduraKleene.Size = new System.Drawing.Size(386, 35);
            this.btnCerraduraKleene.TabIndex = 4;
            this.btnCerraduraKleene.Text = "Cerradura de Kleene";
            this.btnCerraduraKleene.UseVisualStyleBackColor = true;
            this.btnCerraduraKleene.Click += new System.EventHandler(this.btnCerraduraKleene_Click);
            // 
            // btnOpcional
            // 
            this.btnOpcional.Location = new System.Drawing.Point(12, 217);
            this.btnOpcional.Name = "btnOpcional";
            this.btnOpcional.Size = new System.Drawing.Size(386, 35);
            this.btnOpcional.TabIndex = 5;
            this.btnOpcional.Text = "Opcional";
            this.btnOpcional.UseVisualStyleBackColor = true;
            this.btnOpcional.Click += new System.EventHandler(this.btnOpcional_Click);
            // 
            // btnExpresionRegular
            // 
            this.btnExpresionRegular.Location = new System.Drawing.Point(12, 258);
            this.btnExpresionRegular.Name = "btnExpresionRegular";
            this.btnExpresionRegular.Size = new System.Drawing.Size(386, 35);
            this.btnExpresionRegular.TabIndex = 6;
            this.btnExpresionRegular.Text = "Expresión Regular";
            this.btnExpresionRegular.UseVisualStyleBackColor = true;
            this.btnExpresionRegular.Click += new System.EventHandler(this.btnExpresionRegular_Click);
            // 
            // btnUnionLexico
            // 
            this.btnUnionLexico.Location = new System.Drawing.Point(12, 299);
            this.btnUnionLexico.Name = "btnUnionLexico";
            this.btnUnionLexico.Size = new System.Drawing.Size(386, 35);
            this.btnUnionLexico.TabIndex = 7;
            this.btnUnionLexico.Text = "Unión Léxico";
            this.btnUnionLexico.UseVisualStyleBackColor = true;
            this.btnUnionLexico.Click += new System.EventHandler(this.btnUnionLexico_Click);
            // 
            // btnAFNaAFD
            // 
            this.btnAFNaAFD.Location = new System.Drawing.Point(12, 340);
            this.btnAFNaAFD.Name = "btnAFNaAFD";
            this.btnAFNaAFD.Size = new System.Drawing.Size(386, 35);
            this.btnAFNaAFD.TabIndex = 8;
            this.btnAFNaAFD.Text = "AFN a AFD";
            this.btnAFNaAFD.UseVisualStyleBackColor = true;
            this.btnAFNaAFD.Click += new System.EventHandler(this.btnAFNaAFD_Click);
            // 
            // btnAnalizarCadena
            // 
            this.btnAnalizarCadena.Location = new System.Drawing.Point(12, 381);
            this.btnAnalizarCadena.Name = "btnAnalizarCadena";
            this.btnAnalizarCadena.Size = new System.Drawing.Size(386, 35);
            this.btnAnalizarCadena.TabIndex = 9;
            this.btnAnalizarCadena.Text = "Analizar Cadena";
            this.btnAnalizarCadena.UseVisualStyleBackColor = true;
            this.btnAnalizarCadena.Click += new System.EventHandler(this.btnAnalizarCadena_Click);
            // 
            // btnAnalizadorLexico
            // 
            this.btnAnalizadorLexico.Location = new System.Drawing.Point(12, 422);
            this.btnAnalizadorLexico.Name = "btnAnalizadorLexico";
            this.btnAnalizadorLexico.Size = new System.Drawing.Size(386, 35);
            this.btnAnalizadorLexico.TabIndex = 10;
            this.btnAnalizadorLexico.Text = "Analizador Léxico";
            this.btnAnalizadorLexico.UseVisualStyleBackColor = true;
            this.btnAnalizadorLexico.Click += new System.EventHandler(this.btnAnalizadorLexico_Click);
            // 
            // btnFirstFollow
            // 
            this.btnFirstFollow.Location = new System.Drawing.Point(12, 463);
            this.btnFirstFollow.Name = "btnFirstFollow";
            this.btnFirstFollow.Size = new System.Drawing.Size(386, 35);
            this.btnFirstFollow.TabIndex = 11;
            this.btnFirstFollow.Text = "First-Follow";
            this.btnFirstFollow.UseVisualStyleBackColor = true;
            this.btnFirstFollow.Click += new System.EventHandler(this.btnFirstFollow_Click);
            // 
            // btnTablaLL1
            // 
            this.btnTablaLL1.Location = new System.Drawing.Point(12, 504);
            this.btnTablaLL1.Name = "btnTablaLL1";
            this.btnTablaLL1.Size = new System.Drawing.Size(386, 35);
            this.btnTablaLL1.TabIndex = 12;
            this.btnTablaLL1.Text = "Tabla LL(1)";
            this.btnTablaLL1.UseVisualStyleBackColor = true;
            this.btnTablaLL1.Click += new System.EventHandler(this.btnTablaLL1_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(418, 552);
            this.Controls.Add(this.btnTablaLL1);
            this.Controls.Add(this.btnFirstFollow);
            this.Controls.Add(this.btnAnalizadorLexico);
            this.Controls.Add(this.btnAnalizarCadena);
            this.Controls.Add(this.btnAFNaAFD);
            this.Controls.Add(this.btnUnionLexico);
            this.Controls.Add(this.btnExpresionRegular);
            this.Controls.Add(this.btnOpcional);
            this.Controls.Add(this.btnCerraduraKleene);
            this.Controls.Add(this.btnCerraduraPos);
            this.Controls.Add(this.btnConcatenar);
            this.Controls.Add(this.btnUnir);
            this.Controls.Add(this.btnBasico);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);

        }

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btnBasico;
        private System.Windows.Forms.Button btnUnir;
        private System.Windows.Forms.Button btnConcatenar;
        private System.Windows.Forms.Button btnCerraduraPos;
        private System.Windows.Forms.Button btnCerraduraKleene;
        private System.Windows.Forms.Button btnOpcional;
        private System.Windows.Forms.Button btnExpresionRegular;
        private System.Windows.Forms.Button btnUnionLexico;
        private System.Windows.Forms.Button btnAFNaAFD;
        private System.Windows.Forms.Button btnAnalizarCadena;
        private System.Windows.Forms.Button btnAnalizadorLexico;
        private System.Windows.Forms.Button btnFirstFollow;
        private System.Windows.Forms.Button btnTablaLL1;
    }
}
