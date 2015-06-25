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
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnggota)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAnggota
            // 
            this.dgvAnggota.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAnggota.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnggota.Location = new System.Drawing.Point(12, 12);
            this.dgvAnggota.Name = "dgvAnggota";
            this.dgvAnggota.Size = new System.Drawing.Size(566, 433);
            this.dgvAnggota.TabIndex = 0;
            this.dgvAnggota.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAnggota_RowValidating);
            // 
            // frmDaftarAnggota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 457);
            this.Controls.Add(this.dgvAnggota);
            this.Name = "frmDaftarAnggota";
            this.Text = "Daftar Anggota";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnggota)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAnggota;
    }
}