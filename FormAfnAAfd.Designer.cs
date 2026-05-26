namespace ConsoleApp1
{
    partial class FormAFNaAFD
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
            this.listAFNs = new System.Windows.Forms.ListBox();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dgvAFD = new System.Windows.Forms.DataGridView();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona un AFN a convertir";
            // 
            // listAFNs
            // 
            this.listAFNs.FormattingEnabled = true;
            this.listAFNs.ItemHeight = 25;
            this.listAFNs.Location = new System.Drawing.Point(71, 110);
            this.listAFNs.Name = "listAFNs";
            this.listAFNs.Size = new System.Drawing.Size(201, 254);
            this.listAFNs.TabIndex = 1;
            // 
            // btnConvertir
            // 
            this.btnConvertir.Location = new System.Drawing.Point(407, 112);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(172, 57);
            this.btnConvertir.TabIndex = 2;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(407, 193);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(172, 56);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar AFD";
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // dgvAFD
            // 
            this.dgvAFD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAFD.Location = new System.Drawing.Point(71, 411);
            this.dgvAFD.Name = "dgvAFD";
            this.dgvAFD.RowHeadersWidth = 82;
            this.dgvAFD.RowTemplate.Height = 33;
            this.dgvAFD.Size = new System.Drawing.Size(873, 308);
            this.dgvAFD.TabIndex = 4;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(407, 282);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 55);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormAFNaAFD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 767);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.dgvAFD);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.listAFNs);
            this.Controls.Add(this.label1);
            this.Name = "FormAFNaAFD";
            this.Text = "FormAfnAAfd";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAFD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listAFNs;
        private System.Windows.Forms.Button btnConvertir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dgvAFD;
        private System.Windows.Forms.Button btnCancelar;
    }
}