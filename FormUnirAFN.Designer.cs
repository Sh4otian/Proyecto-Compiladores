namespace ConsoleApp1
{
    partial class FormUnirAFN
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
            this.DatGV1 = new System.Windows.Forms.DataGridView();
            this.Btn1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DatGV1)).BeginInit();
            this.SuspendLayout();
            // 
            // DatGV1
            // 
            this.DatGV1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DatGV1.Location = new System.Drawing.Point(226, 85);
            this.DatGV1.Name = "DatGV1";
            this.DatGV1.Size = new System.Drawing.Size(240, 150);
            this.DatGV1.TabIndex = 0;
            this.DatGV1.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridView1_CellValidating);
            // 
            // Btn1
            // 
            this.Btn1.Location = new System.Drawing.Point(277, 281);
            this.Btn1.Name = "Btn1";
            this.Btn1.Size = new System.Drawing.Size(114, 52);
            this.Btn1.TabIndex = 1;
            this.Btn1.Text = "button1";
            this.Btn1.UseVisualStyleBackColor = true;
            this.Btn1.Click += new System.EventHandler(this.btnProcesar_Click);
            // 
            // FormUnirAFN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Btn1);
            this.Controls.Add(this.DatGV1);
            this.Name = "FormUnirAFN";
            this.Text = "FormUnir";
            this.Load += new System.EventHandler(this.FormUnirAFN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DatGV1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DatGV1;
        private System.Windows.Forms.Button Btn1;
    }
}