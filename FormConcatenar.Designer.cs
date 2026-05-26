namespace ConsoleApp1
{
    partial class FormConcatenar
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
            this.btnConcatenar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Selecciona 2 AFN\'S";
            // 
            // listAFNs
            // 
            this.listAFNs.FormattingEnabled = true;
            this.listAFNs.ItemHeight = 25;
            this.listAFNs.Location = new System.Drawing.Point(70, 123);
            this.listAFNs.Name = "listAFNs";
            this.listAFNs.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listAFNs.Size = new System.Drawing.Size(371, 254);
            this.listAFNs.TabIndex = 1;
            // 
            // btnConcatenar
            // 
            this.btnConcatenar.Location = new System.Drawing.Point(551, 123);
            this.btnConcatenar.Name = "btnConcatenar";
            this.btnConcatenar.Size = new System.Drawing.Size(171, 60);
            this.btnConcatenar.TabIndex = 2;
            this.btnConcatenar.Text = "Concatenar";
            this.btnConcatenar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(551, 214);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(171, 60);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // FormConcatenar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConcatenar);
            this.Controls.Add(this.listAFNs);
            this.Controls.Add(this.label1);
            this.Name = "FormConcatenar";
            this.Text = "FormConcatenar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listAFNs;
        private System.Windows.Forms.Button btnConcatenar;
        private System.Windows.Forms.Button btnCancelar;
    }
}