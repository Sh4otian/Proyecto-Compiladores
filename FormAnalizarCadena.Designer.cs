namespace ConsoleApp1
{
    partial class FormAnalizarCadena
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblEstadoAFD = new System.Windows.Forms.Label();
            this.btnCargarAFD = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCadena = new System.Windows.Forms.TextBox();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Estado AFD:";
            // 
            // lblEstadoAFD
            // 
            this.lblEstadoAFD.AutoSize = true;
            this.lblEstadoAFD.Location = new System.Drawing.Point(226, 53);
            this.lblEstadoAFD.Name = "lblEstadoAFD";
            this.lblEstadoAFD.Size = new System.Drawing.Size(175, 25);
            this.lblEstadoAFD.TabIndex = 1;
            this.lblEstadoAFD.Text = "Sin AFD cargado";
            // 
            // btnCargarAFD
            // 
            this.btnCargarAFD.Location = new System.Drawing.Point(462, 45);
            this.btnCargarAFD.Name = "btnCargarAFD";
            this.btnCargarAFD.Size = new System.Drawing.Size(165, 40);
            this.btnCargarAFD.TabIndex = 2;
            this.btnCargarAFD.Text = "Cargar AFD";
            this.btnCargarAFD.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(64, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cadena a analizar: ";
            // 
            // txtCadena
            // 
            this.txtCadena.Location = new System.Drawing.Point(301, 136);
            this.txtCadena.Name = "txtCadena";
            this.txtCadena.Size = new System.Drawing.Size(100, 31);
            this.txtCadena.TabIndex = 4;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(462, 135);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(165, 39);
            this.btnAnalizar.TabIndex = 5;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(306, 234);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 25);
            this.lblResultado.TabIndex = 6;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(475, 357);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(137, 45);
            this.btnCerrar.TabIndex = 7;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // FormAnalizarCadena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lblResultado);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.txtCadena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCargarAFD);
            this.Controls.Add(this.lblEstadoAFD);
            this.Controls.Add(this.label1);
            this.Name = "FormAnalizarCadena";
            this.Text = "FormAnalizarCadena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEstadoAFD;
        private System.Windows.Forms.Button btnCargarAFD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCadena;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.Button btnCerrar;
    }
}