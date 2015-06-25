namespace WinForms.Forms
{
    partial class frmDaftarKegiatan
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
            this.dgvKegiatan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKegiatan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKegiatan
            // 
            this.dgvKegiatan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKegiatan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKegiatan.Location = new System.Drawing.Point(12, 12);
            this.dgvKegiatan.Name = "dgvKegiatan";
            this.dgvKegiatan.Size = new System.Drawing.Size(649, 413);
            this.dgvKegiatan.TabIndex = 0;
            this.dgvKegiatan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKegiatan_CellContentClick);
            // 
            // frmDaftarKegiatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 437);
            this.Controls.Add(this.dgvKegiatan);
            this.Name = "frmDaftarKegiatan";
            this.Text = "Daftar Kegiatan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKegiatan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKegiatan;
    }
}