namespace ConsoleApp1
{
    partial class FormUnir
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
            this.btnUnir = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona 2 AFN\'S";
            // 
            // listAFNs
            // 
            this.listAFNs.FormattingEnabled = true;
            this.listAFNs.ItemHeight = 25;
            this.listAFNs.Location = new System.Drawing.Point(74, 108);
            this.listAFNs.Name = "listAFNs";
            this.listAFNs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listAFNs.Size = new System.Drawing.Size(369, 254);
            this.listAFNs.TabIndex = 1;
            // 
            // btnUnir
            // 
            this.btnUnir.Location = new System.Drawing.Point(511, 108);
            this.btnUnir.Name = "btnUnir";
            this.btnUnir.Size = new System.Drawing.Size(98, 52);
            this.btnUnir.TabIndex = 2;
            this.btnUnir.Text = "Unir";
            this.btnUnir.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(511, 211);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(125, 50);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormUnir
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnUnir);
            this.Controls.Add(this.listAFNs);
            this.Controls.Add(this.label1);
            this.Name = "FormUnir";
            this.Text = "FormUnircs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listAFNs;
        private System.Windows.Forms.Button btnUnir;
        private System.Windows.Forms.Button btnCancelar;
    }
}