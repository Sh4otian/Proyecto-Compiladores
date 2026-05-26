namespace ConsoleApp1
{
    partial class FormUnionLexico
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtToken = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.listSeleccionados = new System.Windows.Forms.ListBox();
            this.btnUnir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "AFN\'S disponibles";
            // 
            // listAFNs
            // 
            this.listAFNs.FormattingEnabled = true;
            this.listAFNs.ItemHeight = 25;
            this.listAFNs.Location = new System.Drawing.Point(42, 139);
            this.listAFNs.Name = "listAFNs";
            this.listAFNs.Size = new System.Drawing.Size(182, 379);
            this.listAFNs.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(299, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Token: ";
            // 
            // txtToken
            // 
            this.txtToken.Location = new System.Drawing.Point(389, 46);
            this.txtToken.Name = "txtToken";
            this.txtToken.Size = new System.Drawing.Size(100, 31);
            this.txtToken.TabIndex = 3;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(561, 39);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(122, 38);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(309, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "AFN\'S seleccionados";
            // 
            // listSeleccionados
            // 
            this.listSeleccionados.FormattingEnabled = true;
            this.listSeleccionados.ItemHeight = 25;
            this.listSeleccionados.Location = new System.Drawing.Point(314, 216);
            this.listSeleccionados.Name = "listSeleccionados";
            this.listSeleccionados.Size = new System.Drawing.Size(211, 304);
            this.listSeleccionados.TabIndex = 6;
            // 
            // btnUnir
            // 
            this.btnUnir.Location = new System.Drawing.Point(622, 227);
            this.btnUnir.Name = "btnUnir";
            this.btnUnir.Size = new System.Drawing.Size(94, 40);
            this.btnUnir.TabIndex = 7;
            this.btnUnir.Text = "Unir";
            this.btnUnir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(622, 308);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(120, 36);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormUnionLexico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 544);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnUnir);
            this.Controls.Add(this.listSeleccionados);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtToken);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listAFNs);
            this.Controls.Add(this.label1);
            this.Name = "FormUnionLexico";
            this.Text = "FormUnionLexico";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listAFNs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtToken;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listSeleccionados;
        private System.Windows.Forms.Button btnUnir;
        private System.Windows.Forms.Button btnCancelar;
    }
}