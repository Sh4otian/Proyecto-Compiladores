namespace ConsoleApp1
{
    partial class FormAnalizadorLexico
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
            this.dgvTokens = new System.Windows.Forms.DataGridView();
            this.lblEstadoAFD = new System.Windows.Forms.Label();
            this.txtEntrada = new System.Windows.Forms.TextBox();
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnAnalizar = new System.Windows.Forms.Button();
            this.btnCargarAFD = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTokens
            // 
            this.dgvTokens.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTokens.Location = new System.Drawing.Point(62, 47);
            this.dgvTokens.Name = "dgvTokens";
            this.dgvTokens.RowHeadersWidth = 82;
            this.dgvTokens.RowTemplate.Height = 33;
            this.dgvTokens.Size = new System.Drawing.Size(676, 240);
            this.dgvTokens.TabIndex = 0;
            // 
            // lblEstadoAFD
            // 
            this.lblEstadoAFD.AutoSize = true;
            this.lblEstadoAFD.Location = new System.Drawing.Point(57, 332);
            this.lblEstadoAFD.Name = "lblEstadoAFD";
            this.lblEstadoAFD.Size = new System.Drawing.Size(162, 25);
            this.lblEstadoAFD.TabIndex = 1;
            this.lblEstadoAFD.Text = "Estado del AFD";
            // 
            // txtEntrada
            // 
            this.txtEntrada.Location = new System.Drawing.Point(568, 332);
            this.txtEntrada.Name = "txtEntrada";
            this.txtEntrada.Size = new System.Drawing.Size(100, 31);
            this.txtEntrada.TabIndex = 2;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Location = new System.Drawing.Point(668, 329);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(0, 25);
            this.lblTotal.TabIndex = 3;
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(62, 404);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(121, 52);
            this.btnAnalizar.TabIndex = 4;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            // 
            // btnCargarAFD
            // 
            this.btnCargarAFD.Location = new System.Drawing.Point(219, 404);
            this.btnCargarAFD.Name = "btnCargarAFD";
            this.btnCargarAFD.Size = new System.Drawing.Size(118, 52);
            this.btnCargarAFD.TabIndex = 5;
            this.btnCargarAFD.Text = "Cargar AFD";
            this.btnCargarAFD.UseVisualStyleBackColor = true;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(396, 404);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(107, 52);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(555, 404);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(113, 52);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // FormAnalizadorLexico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 508);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCargarAFD);
            this.Controls.Add(this.btnAnalizar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtEntrada);
            this.Controls.Add(this.lblEstadoAFD);
            this.Controls.Add(this.dgvTokens);
            this.Name = "FormAnalizadorLexico";
            this.Text = "FormAnalizadorLexico";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTokens)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTokens;
        private System.Windows.Forms.Label lblEstadoAFD;
        private System.Windows.Forms.TextBox txtEntrada;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnCargarAFD;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}