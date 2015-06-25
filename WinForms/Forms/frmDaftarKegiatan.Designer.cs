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
            this.btnTambah = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKegiatan)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKegiatan
            // 
            this.dgvKegiatan.AllowUserToAddRows = false;
            this.dgvKegiatan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKegiatan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKegiatan.Location = new System.Drawing.Point(12, 41);
            this.dgvKegiatan.Name = "dgvKegiatan";
            this.dgvKegiatan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKegiatan.Size = new System.Drawing.Size(649, 384);
            this.dgvKegiatan.TabIndex = 0;
            this.dgvKegiatan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKegiatan_CellContentClick);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(12, 12);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(75, 23);
            this.btnTambah.TabIndex = 1;
            this.btnTambah.Text = "&Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // frmDaftarKegiatan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 437);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.dgvKegiatan);
            this.Name = "frmDaftarKegiatan";
            this.Text = "Daftar Kegiatan";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKegiatan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvKegiatan;
        private System.Windows.Forms.Button btnTambah;
    }
}