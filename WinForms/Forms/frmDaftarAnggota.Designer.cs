namespace WinForms.Forms
{
    partial class frmDaftarAnggota
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
            this.dgvAnggota = new System.Windows.Forms.DataGridView();
            this.btnImport = new System.Windows.Forms.Button();
            this.tbFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnggota)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnggota
            // 
            this.dgvAnggota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnggota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnggota.Location = new System.Drawing.Point(12, 54);
            this.dgvAnggota.Name = "dgvAnggota";
            this.dgvAnggota.Size = new System.Drawing.Size(566, 391);
            this.dgvAnggota.TabIndex = 0;
            this.dgvAnggota.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAnggota_RowValidating);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(483, 12);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(64, 29);
            this.btnImport.TabIndex = 1;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // tbFile
            // 
            this.tbFile.Location = new System.Drawing.Point(358, 17);
            this.tbFile.Name = "tbFile";
            this.tbFile.Size = new System.Drawing.Size(108, 20);
            this.tbFile.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(288, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nama File";
            // 
            // frmDaftarAnggota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 457);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbFile);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.dgvAnggota);
            this.Name = "frmDaftarAnggota";
            this.Text = "Daftar Anggota";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnggota)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnggota;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.TextBox tbFile;
        private System.Windows.Forms.Label label1;
    }
}